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
            modelBuilder.Entity<PersonInstrument>(pi =>
            {
                pi.HasKey(pi => new { pi.PersonId, pi.InstrumentId });
                pi.HasOne(p => p.Person).WithMany(i => i.PersonInstruments).HasForeignKey(pi => pi.PersonId);
                pi.HasOne(i => i.Instrument).WithMany(p => p.PersonInstruments).HasForeignKey(pi => pi.InstrumentId);
            });
            modelBuilder.Entity<PersonLesson>(pl => 
            {
                pl.HasKey(pl => new { pl.PersonId, pl.LessonId });
                pl.HasOne(p => p.Person).WithMany(li => li.PersonLessons).HasForeignKey(pi => pi.PersonId);
                pl.HasOne(l => l.Lesson).WithMany(li => li.PersonLessons).HasForeignKey(li => li.LessonId);
            });
            modelBuilder.Entity<Person>(p => 
            {
                p.HasKey(x => x.Id);
                p.Property(x => x.Email).IsRequired(true);
                p.Property(x => x.Password).IsRequired(true);
                p.Property(x => x.LastName).IsRequired(true);

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
        public DbSet<Person> Persons {get; set;}
        public DbSet<Lesson> Lessons {get; set;}
        public DbSet<Location> Locations {get; set;}
        public DbSet<PersonInstrument> PersonInstruments {get; set;}

    }
}
