using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Seeding;
using MLP_Eindproject.API;
using NUnit.Framework;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;

namespace MLP_TestLibrary
{
    [SetUpFixture]
    public class TestFixture
    {
        private TestServer _server { get; set; }
        public static HttpClient Client { get; set; }
        public static ServiceProvider ServiceProvider { get; set; }
        public DbConnection Connection { get; set; }
        public static IConfiguration Configuration { get; set; }

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            SeedData.IsTest = true;
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();

            Connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True");
            Connection.Open();
            TestResetDb(Configuration.GetConnectionString("TheMubTest").ToString());

            var builder = new WebHostBuilder()
                .UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build())
                .ConfigureServices(InitializeServices)
                .UseStartup(typeof(Startup));

            _server = new TestServer(builder);
            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost");
        }

        [OneTimeTearDown]
        public void DisposeFixture()
        {
            Client.Dispose();
            _server.Dispose();
            Connection.Dispose();
        }
        public void InitializeServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<MLPDbContext>));
            services.Remove(descriptor);


            services.AddDbContext<MLPDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TheMubTest").ToString(),
                x => x.MigrationsAssembly("MLP_MigrationLibrary")));
            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                db.Database.Migrate();
                db.Database.EnsureCreated();
            }
            
            ServiceProvider = sp;
        }
        public void TestResetDb(string connectionString)
        {
            var startIndex = connectionString.IndexOf("Initial Catalog=") + 16;
            var dbName = connectionString.Substring(startIndex, connectionString.IndexOf(";", startIndex) - startIndex);
            DbCommand dbCommand = Connection.CreateCommand();
            dbCommand.CommandText = @$"IF EXISTS(SELECT * FROM sys.databases WHERE name='{dbName}') 
                    BEGIN
                    ALTER DATABASE[{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
                   DROP DATABASE[{dbName}]
                    END DECLARE @FILENAME AS VARCHAR(255) SET @FILENAME = CONVERT(VARCHAR(255), SERVERPROPERTY('instancedefaultdatapath')) + '{dbName}';
            EXEC('CREATE DATABASE [{dbName}] ON PRIMARY (NAME = 
            [{dbName}], FILENAME = ''' + @FILENAME + ''', SIZE = 25MB, MAXSIZE = 500MB, FILEGROWTH = 5MB)')";
            dbCommand.ExecuteReader();
        }
    }
}