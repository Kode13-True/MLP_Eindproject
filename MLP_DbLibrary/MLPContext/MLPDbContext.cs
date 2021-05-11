using Microsoft.EntityFrameworkCore;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.MLPContext
{
    public class MLPDbContext : DbContext
    {
        public MLPDbContext(DbContextOptions options) : base(options)
        {

        }

        public MLPDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>(p =>
            {
                p.HasKey(x => x.Id);
                p.Property(x => x.Email).IsRequired(true);
                p.Property(x => x.Password).IsRequired(true);
                p.Property(x => x.LastName).IsRequired(true);
                p.HasMany(x => x.Alerts).WithOne(p => p.Person).HasForeignKey(x => x.PersonId);
                p.ToTable("Persons");
                            });
            modelBuilder.Entity<Teacher>(t => 
            {
                t.HasMany(x => x.Lessons).WithOne(t => t.Teacher).HasForeignKey(x => x.TeacherId);
                t.HasMany(x => x.Instruments).WithOne(t => t.Teacher).HasForeignKey(x => x.TeacherId);
            });
            modelBuilder.Entity<Student>(s =>
            {
                s.HasMany(x => x.Lessons).WithOne(s => s.Student).HasForeignKey(x => x.StudentId);
            });
            modelBuilder.Entity<Admin>(a =>
            {  
            });

            modelBuilder.Entity<Instrument>(i => 
            {
                i.HasKey(i => i.Id);
            });
            modelBuilder.Entity<Lesson>(l =>
            {
                l.HasKey(l => l.Id);
                l.Property(l => l.Price).IsRequired(true);
                l.Property(l => l.Start).IsRequired(true);
                l.Property(l => l.Stop).IsRequired(true);
                l.HasOne(l => l.Location).WithMany(l => l.Lessons).HasForeignKey(l => l.LocationId);                
            });
            modelBuilder.Entity<Location>(l =>
            {
                l.HasKey(l => l.Id);
            });
        }
        public DbSet<Instrument> Instruments {get; set;}
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Lesson> Lessons {get; set;}
        public DbSet<Location> Locations {get; set;}
        public DbSet<Alert> Alerts { get; set; }       

    }
}
