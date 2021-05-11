using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.Seeding
{
    public static class SeedData
    {
        static public void DatabaseSeeding(MLPDbContext db)
        {
            db.Database.EnsureCreated();
            if (!db.Admins.Any())
            {
                db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "abubakr.Boone@gmail.com", FirstName = "Abubakr", LastName = "Boone", Password = "Test1234" });
                db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "dougie.caseygmail.com", FirstName = "Dougie", LastName = "Casey", Password = "Test1234" });
                db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "duncan.schultz@hotmail.com", FirstName = "Duncan", LastName = "Schultz", Password = "Test1234" });
                db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "martine.matthams@skynet.be", FirstName = "Martine", LastName = "Matthams", Password = "Test1234" });
                db.SaveChanges();
            }
            if (!db.Teachers.Any())
            {
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "zaine.rodrigues@hotmail.com",
                    Password = "Test1234",
                    FirstName = "Zaine",
                    LastName = "Rodrigues",
                    Description = "Darker Zach Effron, better singer too!",
                    Rating = 0
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "mallory.kearns@outlook.com",
                    Password = "Test1234",
                    FirstName = "Mallory",
                    LastName = "Kearns",
                    Description = "Pretty not so young thing!",
                    Rating = 0
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "rehaan.hamer@telenet.be",
                    Password = "Test1234",
                    FirstName = "Rehaan",
                    LastName = "Hamer",
                    Description = "Den enigen echte!",
                    Rating = 0
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "ferne.woolley@hotmail.com",
                    Password = "Test1234",
                    FirstName = "Ferne",
                    LastName = "Woolley",
                    Description = "I'm cuddly!",
                    Rating = 0
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "usman.mata@skynet.be",
                    Password = "Test1234",
                    FirstName = "Usman",
                    LastName = "Mata",
                    Description = "I always Mata!",
                    Rating = 0
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "nicole.nunez@hotmail.com",
                    Password = "Test1234",
                    FirstName = "Nicole",
                    LastName = "Nunez",
                    Description = "I'm the old harsh spanish teacher lady!",
                    Rating = 0
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "claire.soto@gmail.com",
                    Password = "Test1234",
                    FirstName = "Claire",
                    LastName = "Soto",
                    Description = "Its a pleasure to meet you!",
                    Rating = 0
                });
                db.SaveChanges();
            }
            if (!db.Students.Any())
            {
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "lillie.delaney@hotmail.com", Password = "Test1234", FirstName = "Lillie", LastName = "Delaney" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "brodie.dunn@gmail.com", Password = "Test1234", FirstName = "Brodie", LastName = "Dunn" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "kayia.summons@telenet.be", Password = "Test1234", FirstName = "Kayia", LastName = "Summons" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "bill.york@newyork.com", Password = "Test1234", FirstName = "Bill", LastName = "York" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "keanu.beard@gmail.com", Password = "Test1234", FirstName = "Keanu", LastName = "Beard" });
                db.SaveChanges();
            }
            if (!db.Locations.Any())
            {
                db.Locations.Add(new Location { Street = "Augustijnenstraat", Number = "5", Postal = "2800", Township = "Mechelen" });
                db.Locations.Add(new Location { Street = "Kerkstraat", Number = "127", Postal = "2000", Township = "Antwerpen" });
                db.Locations.Add(new Location { Street = "Perklaan", Number = "562", Postal = "1800", Township = "Vilvoorde" });
                db.Locations.Add(new Location { Street = "Dorplaan", Number = "25", Postal = "1860", Township = "Meise" });
                db.Locations.Add(new Location { Street = "Duffelsesteenweg", Number = "101", Postal = "2550", Township = "Kontich" });
                db.Locations.Add(new Location { Street = "Jordaenskaai", Number = "26", Postal = "2000", Township = "Antwerpen" });
                db.Locations.Add(new Location { Street = "Vilvoordsesteenweg", Number = "230", Postal = "1800", Township = "Vilvoorde" });
                db.SaveChanges();
            }
            if (!db.Instruments.Any()) 
            {
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Cello, InstrumentStyle = InstrumentStyle.Classic, TeacherId = 5 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Classic, TeacherId = 5 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Fluit, InstrumentStyle = InstrumentStyle.Classic, TeacherId = 5 });
                
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Saxophone, InstrumentStyle = InstrumentStyle.Jazz, TeacherId = 6 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Trumpet, InstrumentStyle = InstrumentStyle.Jazz, TeacherId = 6 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Jazz, TeacherId = 6 });
                
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Pop, TeacherId = 7 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Pop, TeacherId = 7 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Pop, TeacherId = 7 });
                
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Reggae, TeacherId = 8 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Reggae, TeacherId = 8 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Trumpet, InstrumentStyle = InstrumentStyle.Reggae, TeacherId = 8 });
                
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Rock, TeacherId = 9 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Rock, TeacherId = 9 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Rock, TeacherId = 9 });
                
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Cello, InstrumentStyle = InstrumentStyle.Classic, TeacherId = 10 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Reggae, TeacherId = 10 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Fluit, InstrumentStyle = InstrumentStyle.Pop, TeacherId = 10 });
                
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Harp, InstrumentStyle = InstrumentStyle.Reggae, TeacherId = 11 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Rock, TeacherId = 11 });
                db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Violin, InstrumentStyle = InstrumentStyle.Jazz, TeacherId = 11 });

                db.SaveChanges();
            }
            if (!db.Lessons.Any())
            {
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 1,
                    TeacherId = 5
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-25),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 1,
                    TeacherId = 5,
                    Booked = DateTime.Now.AddHours(-24),
                    StudentId = 12
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-48),
                    Start = DateTime.Now.AddHours(-1),
                    Stop = DateTime.Now.AddHours(0),
                    Price = 25,
                    LessonLevel = LessonLevel.Expert,
                    LocationId = 1,
                    TeacherId = 5,
                    Booked = DateTime.Now.AddHours(-24),
                    StudentId = 13,
                    Completed = true
                });

                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 5,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 2,
                    TeacherId = 6
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-48),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 15,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 2,
                    TeacherId = 6,
                    Booked = DateTime.Now.AddHours(-24),
                    StudentId = 13
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-72),
                    Start = DateTime.Now.AddHours(-2),
                    Stop = DateTime.Now.AddHours(-1),
                    Price = 25,
                    LessonLevel = LessonLevel.Expert,
                    LocationId = 2,
                    TeacherId = 6,
                    Booked = DateTime.Now.AddHours(-48),
                    StudentId = 14,
                    Completed = true
                });
                    
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 3,
                    TeacherId = 7
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 3,
                    TeacherId = 7,
                    Booked = DateTime.Now.AddHours(-13),
                    StudentId = 14
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-72),
                    Start = DateTime.Now.AddHours(-2),
                    Stop = DateTime.Now.AddHours(-1),
                    Price = 25,
                    LessonLevel = LessonLevel.Expert,
                    LocationId = 3,
                    TeacherId = 7,
                    Booked = DateTime.Now.AddHours(-48),
                    StudentId = 15,
                    Completed = true
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 4,
                    TeacherId = 8
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-48),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 4,
                    TeacherId = 8,
                    Booked = DateTime.Now.AddHours(-12),
                    StudentId = 15
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-72),
                    Start = DateTime.Now.AddHours(-5),
                    Stop = DateTime.Now.AddHours(-4),
                    Price = 25,
                    LessonLevel = LessonLevel.Expert,
                    LocationId = 4,
                    TeacherId = 8,
                    Booked = DateTime.Now.AddHours(-48),
                    StudentId = 16,
                    Completed = true
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-12),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 5,
                    TeacherId = 9
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 5,
                    TeacherId = 9,
                    Booked = DateTime.Now.AddHours(-5),
                    StudentId = 16
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-72),
                    Start = DateTime.Now.AddHours(-6),
                    Stop = DateTime.Now.AddHours(-5),
                    Price = 25,
                    LessonLevel = LessonLevel.Expert,
                    LocationId = 5,
                    TeacherId = 9,
                    Booked = DateTime.Now.AddHours(-44),
                    StudentId = 12,
                    Completed = true
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 6,
                    TeacherId = 10
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 6,
                    TeacherId = 10,
                    Booked = DateTime.Now.AddHours(-4),
                    StudentId = 12
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-96),
                    Start = DateTime.Now.AddHours(-9),
                    Stop = DateTime.Now.AddHours(-8),
                    Price = 25,
                    LessonLevel = LessonLevel.Expert,
                    LocationId = 6,
                    TeacherId = 10,
                    Booked = DateTime.Now.AddHours(-72),
                    StudentId = 13,
                    Completed = true
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 7,
                    TeacherId = 11
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-96),
                    Start = DateTime.Now.AddHours(120),
                    Stop = DateTime.Now.AddHours(121),
                    Price = 25,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 7,
                    TeacherId = 11,
                    Booked = DateTime.Now.AddHours(-3),
                    StudentId = 13
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-120),
                    Start = DateTime.Now.AddHours(-3),
                    Stop = DateTime.Now.AddHours(-1),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 7,
                    TeacherId = 11,
                    Booked = DateTime.Now.AddHours(-96),
                    StudentId = 14,
                    Completed = true
                });
                db.SaveChanges();
            }
            
        }
    }
}
