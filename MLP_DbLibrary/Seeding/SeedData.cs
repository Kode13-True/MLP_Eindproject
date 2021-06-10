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
        public static bool IsTest;
        static public void DatabaseSeeding(MLPDbContext db)
        {
            //password = test1234
            if (IsTest == false) 
            {
                db.Database.EnsureCreated();                
                if (!db.Admins.Any())
                {
                    db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "keith@mub", FirstName = "Keith", LastName = "Voorhelst", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=" });
                    db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "ko@mub", FirstName = "Ko", LastName = "De Schepper", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=" });
                    db.SaveChanges();
                }
                if (!db.Teachers.Any()) //20 waarvan 5 met lessen
                {
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-150.2),
                        Email = "nico.duquesne@hotmail.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Nico",
                        LastName = "Duquesne",
                        Description = "Nico Duquesne is a professional Guitarist and Singer-Songwriter. He has been teaching music to students of all ages, privately and in groups, since 1997.  After graduating from William Paterson University with a Bachelors Degree in Jazz Performance , Matt spent 10 years in New York City working as a freelance musician and operating the Macaulay Guitar Studio. With a comprehensive background in Jazz, Classical and Rock guitar as well as electric bass, piano, arranging and voice, Matt is uniquely qualified to teach students of all ages and levels.   He has also released three albums of original songs under his own name.",
                        Rating = 4.4,
                        RatingCount = 5
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-548.7),
                        Email = "pianolove74@gmail.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Debbie",
                        LastName = "Pollet",
                        Description = "I have been teaching private music lessons for over 20 years. Having studied under some amazing professionals throughout primary and secondary school, and then at Ohio University, I learned the value of positive reinforcement in music education. No two students are the same - nor do they learn the same way or at the same pace.  Therefore, I make no comparisons from student to student. I structure each student’s program to his/her specific needs and talents. I believe in a well-rounded approach that includes music theory.",
                        Rating = 4.2,
                        RatingCount = 8
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-748.3),
                        Email = "jvc_music@yahoo.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Janne",
                        LastName = "Van Crudsem",
                        Description = "Janne is a graduate of the University of Northern Iowa's instrumental music education program and is an inductee of Pi Kappa Lambda, the national music education honor society. Currently, she maintains a private lesson studio in the Twin Cities and coaches rockers of all ages at She Rock She Rock summer camps.",
                        Rating = 3.8,
                        RatingCount = 1
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-353.2),
                        Email = "timmermansgilles@gmail.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Gilles",
                        LastName = "Timmermans",
                        Description = "guitar, piano, ukulele, voice, banjo, songwriting.  Gilles graduated Cum Laude from Berklee College of Music as a guitar principle with a B.A. in Songwriting.  He plays and teaches rock, jazz, blues, classical, pop, folk, bluegrass and other traditional music genres. A guitarist, pianist, songwriter, and multi-instrumentalist who has been teaching for 10 years, his specialities include classical guitar, acoustic guitar, electric guitar, piano, ukulele, voice, banjo, and songwriting.  Teaching all ages and all levels",
                        Rating = 4.0,
                        RatingCount = 7
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-642.6),
                        Email = "frenson@yahoo.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Felix",
                        LastName = "Renson",
                        Description = "Electric guitar player, composer and producer (Shwesmo, HAGO, Distorted Harmony), Conservatorium(Antwerp) graduate (Summa Cum Laude) Felix Renson is known for blending musical styles such as Progressive Metal, Jazz, Fusion, Electronic and Middle Eastern music.",
                        Rating = 4.8,
                        RatingCount = 8
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-320.6),
                        Email = "kareldminor@google.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Karel",
                        LastName = "Deramoudt",
                        Description = "An active musician for the past 19 years, Karel has been teaching  Guitar and Music Theory privately for the past 8. After earning a Masters Degree in Ethnomusicology from the University of Ghent",
                        Rating = 3.7,
                        RatingCount = 5
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-603.0),
                        Email = "lydie.de.wolf@gmail.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Lydie",
                        LastName = "De Wolf",
                        Description = "vocals, piano, violin, fluit, trumpet, you name it, I teach it",
                        Rating = 4.0,
                        RatingCount = 10
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-159.9),
                        Email = "liza@marissens.be",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Liza",
                        LastName = "Marissens",
                        Description = "Artist Development, Voice, Singing, Musical Theatre, Pop Voice, Singing for Actors, Audition Prep, Country Voice, Jazz Voice, Opera, Classical Voice, Audition Prep from Broadway Performer, Stage Training, Audition Prep for Actors, College Audition Prep, College Audition Prep for Actors, Music Theory, R&B Voice, Rock Voice, Self Taping for Actors, Self Taping for Musical Theatre",
                        Rating = 3.2,
                        RatingCount = 4
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-412.2),
                        Email = "efe007@pandora.be",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Efe",
                        LastName = "Sparks",
                        Description = "Metal, Jazz, Fusion, Electronic and Middle Eastern music.",
                        Rating = 4.6,
                        RatingCount = 9
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-20),
                        Email = "pacer@hotmail.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Anisha",
                        LastName = "Pace",
                        Description = "Voice, Singing, Ukulele, Acoustic Guitar, Musical Theatre, Classical Voice, Rock Voice, Music Theory, Recorder, Pop Voice, Singing for Actors, Country Voice, Guitar, Opera",
                        Rating = 3.2,
                        RatingCount = 3
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-90.7),
                        Email = "naturalmystic@pandora.be",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Blake",
                        LastName = "Flynn",
                        Description = "Born and Raised in Jamaica, Reggae is flowing threw my vaines",
                        Rating = 4.5,
                        RatingCount = 2
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-270.9),
                        Email = "cecil@belgacom.be",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Cecil",
                        LastName = "Decker",
                        Description = "Piano, flute, harp teacher for 20 years",
                        Rating = 4.5,
                        RatingCount = 3
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-95.2),
                        Email = "kieren.maynard@hotmail.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Kieren",
                        LastName = "Maynard",
                        Description = "Metal, Jazz, Fusion, Electronic and Middle Eastern music.",
                        Rating = 2.4,
                        RatingCount = 1
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-40.4),
                        Email = "musicislife@gmail.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Clarisse",
                        LastName = "Maynard",
                        Description = "I am an experienced music teacher of piano and voice for over 12 years with a degree in music",
                        Rating = 0,
                        RatingCount = 0
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-172.4),
                        Email = "smart.flora@jawadde.be",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Flora",
                        LastName = "Smart",
                        Description = "is a fun, experienced, and patient teacher. She has taught over 13,000 lessons in various instruments to over 250 students in private lessons and small groups in person and online. Her students range from age 3 through adults. ",
                        Rating = 4.0,
                        RatingCount = 5
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-100),
                        Email = "oamuziek@yahoo.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Omer",
                        LastName = "Aguirre",
                        Description = "is a 26 year old father of 1 who has a passion for teaching and performing music. A Berklee College of Music Alumnus (class of 2017), Rich has spent much of the last few years teaching flute, saxophone, clarinet, and music theory lessons to students of all ages,",
                        Rating = 4.1,
                        RatingCount = 6
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-320.6),
                        Email = "graham@google.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Hailie",
                        LastName = "Graham",
                        Description = "Accepting new students for new availability for summer schedule beginning July!",
                        Rating = 0,
                        RatingCount = 0
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-58),
                        Email = "a.guzman@gmail.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Aniela",
                        LastName = "Guzman",
                        Description = "I have been playing music for 18 years over a variety of instruments including piano, bass guitar, vocals, kit, trumpet, flute, and many more.  I have recently finished my Music Degree with a specialization in Education. ",
                        Rating = 3.1,
                        RatingCount = 7
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-403.6),
                        Email = "ryad.mercer@music.com",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Ryad",
                        LastName = "Mercer",
                        Description = "Reggae, Rock, Fusion, Electronic and Middle Eastern music.",
                        Rating = 4.7,
                        RatingCount = 3
                    });
                    db.Teachers.Add(new Teacher
                    {
                        DOC = DateTime.Now.AddDays(-287.4),
                        Email = "susan@vdh.be",
                        Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                        FirstName = "Susan",
                        LastName = "Van Den Heuvel",
                        Description = "Welcome to my profile and I can't wait to make music together!",
                        Rating = 0,
                        RatingCount = 0
                    });
                    db.SaveChanges();

                }
                if (!db.Students.Any()) //20
                {
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-105), Email = "hannes.lint@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Hannes", LastName = "Lint" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-115), Email = "antje.diercks@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Antje", LastName = "Diercks" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-125), Email = "bjorn.leick@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Bjorn", LastName = "Leick" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-95), Email = "marlies.kleinjan@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Marlies", LastName = "Kleinjan" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-85), Email = "karen.kates@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Karen", LastName = "Kates" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-75), Email = "Judith.Bogard@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Judith", LastName = "Bogard" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-57), Email = "henk.vliet@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Henk", LastName = "Vliet" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-102), Email = "robbert.verhaeghe@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Robbert", LastName = "Verhaeghe" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-99), Email = "mariska.lier@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Mariska", LastName = "Lier" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-22), Email = "miranda.deremer@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Miranda", LastName = "Deremer" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-53), Email = "jo.schei@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Jo", LastName = "Schei" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-45), Email = "olga.peerman@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Olga", LastName = "Peerman" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-68), Email = "thomas.provine@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Thomas", LastName = "Provine" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-69), Email = "lammert.manes@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Lammert", LastName = "Manes" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-47), Email = "marloes.winand@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Marloes", LastName = "Winand" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-97), Email = "wilco.kin@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Wilco", LastName = "Kin" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-83), Email = "heidi.marris@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Heidi", LastName = "Marris" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-10), Email = "josephina.roos@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Josephina", LastName = "Roos" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-120), Email = "bert.vanbrunt@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Bert", LastName = "Van Brunt" });
                    db.Students.Add(new Student { DOC = DateTime.Now.AddHours(-135), Email = "rie.lem@student.mub", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Rie", LastName = "Lem" });
                    db.SaveChanges();
                }
                if (!db.Locations.Any()) //5 voor de lessen
                {
                    db.Locations.Add(new Location { Street = "Augustijnenstraat", Number = "5", Postal = "2800", Township = "Mechelen" });
                    db.Locations.Add(new Location { Street = "Nationalestraat", Number = "127", Postal = "2000", Township = "Antwerpen" });
                    db.Locations.Add(new Location { Street = "Dorplaan", Number = "25", Postal = "1860", Township = "Meise" });
                    db.Locations.Add(new Location { Street = "Turnhoutsebaan", Number = "286", Postal = "2140", Township = "Borgerhout" });
                    db.Locations.Add(new Location { Street = "Duffelsesteenweg", Number = "101", Postal = "2550", Township = "Kontich" });
                    db.SaveChanges();
                }
                /*  type lessons: 40
                        Unbooked lessons future: start: add(x<24) not deletable: 5
                        Unbooked lessons future: start: add(x>24) deletable: 5
                        Unbooked lessons future: start: add(x>48) book to cancel: 5
                        Booked lessons future: start: add(x<48) uncancelable: 5 --> yes
                        Booked lessons future: start: add(x>48) cancelable: 5 --> yes
                        
                        Unbooked lessons passed: stop: add(x<0) reference: 5
                        booked lessons passed: stop: add(x<0) Rating: 5
                        booked lessons passed: stop: add(x<0) Rated:  5 --> yes
                 */
                if (!db.Lessons.Any())
                {
                    //Unbooked lessons future: start: add(x < 24) not deletable: 5
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-72),
                        Start = DateTime.Now.AddHours(8),
                        Stop = DateTime.Now.AddHours(9),
                        Price = 0,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 1,
                        TeacherId = 3
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-144),
                        Start = DateTime.Now.AddHours(12),
                        Stop = DateTime.Now.AddHours(13),
                        Price = 22,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 2,
                        TeacherId = 4
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-80),
                        Start = DateTime.Now.AddHours(2),
                        Stop = DateTime.Now.AddHours(3),
                        Price = 25,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 3,
                        TeacherId = 5
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-120),
                        Start = DateTime.Now.AddHours(6),
                        Stop = DateTime.Now.AddHours(6.5),
                        Price = 12,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 4,
                        TeacherId = 6
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-60),
                        Start = DateTime.Now.AddHours(18),
                        Stop = DateTime.Now.AddHours(19),
                        Price = 20,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 5,
                        TeacherId = 7
                    });
                    //Unbooked lessons future: start: add(x > 24) deletable: 5
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-72),
                        Start = DateTime.Now.AddHours(72),
                        Stop = DateTime.Now.AddHours(72.5),
                        Price = 30,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 1,
                        TeacherId = 3
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-144),
                        Start = DateTime.Now.AddHours(108),
                        Stop = DateTime.Now.AddHours(109),
                        Price = 22,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 2,
                        TeacherId = 4
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-80.5),
                        Start = DateTime.Now.AddHours(112),
                        Stop = DateTime.Now.AddHours(113),
                        Price = 25,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 3,
                        TeacherId = 5
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-120),
                        Start = DateTime.Now.AddHours(56),
                        Stop = DateTime.Now.AddHours(56.5),
                        Price = 15,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 4,
                        TeacherId = 6
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-60),
                        Start = DateTime.Now.AddHours(70),
                        Stop = DateTime.Now.AddHours(71),
                        Price = 23,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 5,
                        TeacherId = 7
                    });
                    // Unbooked lessons future: start: add(x > 48) book to cancel: 5
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-72.2),
                        Start = DateTime.Now.AddHours(144),
                        Stop = DateTime.Now.AddHours(144.5),
                        Price = 30,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 1,
                        TeacherId = 3
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-144.2),
                        Start = DateTime.Now.AddHours(216),
                        Stop = DateTime.Now.AddHours(217),
                        Price = 22.5M,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 2,
                        TeacherId = 4
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-80.7),
                        Start = DateTime.Now.AddHours(113),
                        Stop = DateTime.Now.AddHours(114),
                        Price = 25,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 3,
                        TeacherId = 5
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-120.2),
                        Start = DateTime.Now.AddHours(58),
                        Stop = DateTime.Now.AddHours(58.5),
                        Price = 15.9M,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 4,
                        TeacherId = 6
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-60.2),
                        Start = DateTime.Now.AddHours(140),
                        Stop = DateTime.Now.AddHours(141),
                        Price = 23,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 5,
                        TeacherId = 7
                    });
                    // Booked lessons future: start: add(x < 48) uncancelable: 5
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-25),
                        Start = DateTime.Now.AddHours(24),
                        Stop = DateTime.Now.AddHours(25),
                        Price = 25,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 1,
                        TeacherId = 3,
                        Booked = DateTime.Now.AddHours(-24),
                        StudentId = 23
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-48),
                        Start = DateTime.Now.AddHours(25),
                        Stop = DateTime.Now.AddHours(26),
                        Price = 22.5M,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 2,
                        TeacherId = 4,
                        Booked = DateTime.Now.AddHours(-24),
                        StudentId = 24
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-48),
                        Start = DateTime.Now.AddHours(30),
                        Stop = DateTime.Now.AddHours(30.5),
                        Price = 22,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 3,
                        TeacherId = 5,
                        Booked = DateTime.Now.AddHours(-26),
                        StudentId = 25
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-48),
                        Start = DateTime.Now.AddHours(36),
                        Stop = DateTime.Now.AddHours(37),
                        Price = 22,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 3,
                        TeacherId = 5,
                        Booked = DateTime.Now.AddHours(-27),
                        StudentId = 25
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-48),
                        Start = DateTime.Now.AddHours(30),
                        Stop = DateTime.Now.AddHours(30.5),
                        Price = 22,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 2,
                        TeacherId = 4,
                        Booked = DateTime.Now.AddHours(-21),
                        StudentId = 23
                    });                   

                    //Booked lessons future: start: add(x > 48) cancelable: 5
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-125),
                        Start = DateTime.Now.AddHours(220),
                        Stop = DateTime.Now.AddHours(221),
                        Price = 30,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 1,
                        TeacherId = 3,
                        Booked = DateTime.Now.AddHours(-75),
                        StudentId = 23
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-124),
                        Start = DateTime.Now.AddHours(340),
                        Stop = DateTime.Now.AddHours(341),
                        Price = 15,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 2,
                        TeacherId = 4,
                        Booked = DateTime.Now.AddHours(-55),
                        StudentId = 24
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-123),
                        Start = DateTime.Now.AddHours(280),
                        Stop = DateTime.Now.AddHours(281),
                        Price = 40,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 3,
                        TeacherId = 5,
                        Booked = DateTime.Now.AddHours(-22),
                        StudentId = 25
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-122),
                        Start = DateTime.Now.AddHours(265),
                        Stop = DateTime.Now.AddHours(266),
                        Price = 0,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 4,
                        TeacherId = 6,
                        Booked = DateTime.Now.AddHours(-37),
                        StudentId = 23
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddHours(-121),
                        Start = DateTime.Now.AddHours(210),
                        Stop = DateTime.Now.AddHours(210.5),
                        Price = 75,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 5,
                        TeacherId = 7,
                        Booked = DateTime.Now.AddHours(-44),
                        StudentId = 25
                    });

                    //    Unbooked lessons passed: stop: add(x < 0) reference: 5
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-10),
                        Start = DateTime.Now.AddHours(-120),
                        Stop = DateTime.Now.AddHours(-119),
                        Price = 10,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 1,
                        TeacherId = 3
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-14),
                        Start = DateTime.Now.AddHours(-140),
                        Stop = DateTime.Now.AddHours(-139),
                        Price = 25,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 2,
                        TeacherId = 4
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-25),
                        Start = DateTime.Now.AddHours(-160),
                        Stop = DateTime.Now.AddHours(-159),
                        Price = 25,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 3,
                        TeacherId = 5
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-26),
                        Start = DateTime.Now.AddHours(-145),
                        Stop = DateTime.Now.AddHours(-144),
                        Price = 19.99M,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 4,
                        TeacherId = 6
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-15),
                        Start = DateTime.Now.AddHours(-125),
                        Stop = DateTime.Now.AddHours(-123),
                        Price = 100,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 5,
                        TeacherId = 7
                    });
                    //    booked lessons passed: stop: add(x < 0) Rating: 5
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-15),
                        Start = DateTime.Now.AddDays(-10).AddHours(2),
                        Stop = DateTime.Now.AddDays(-10).AddHours(3),
                        Price = 0,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 1,
                        TeacherId = 3,
                        Booked = DateTime.Now.AddDays(-12).AddHours(5),
                        StudentId = 23
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-17),
                        Start = DateTime.Now.AddDays(-12).AddHours(2),
                        Stop = DateTime.Now.AddDays(-12).AddHours(3),
                        Price = 14,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 2,
                        TeacherId = 4,
                        Booked = DateTime.Now.AddDays(-14).AddHours(5),
                        StudentId = 25
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-19),
                        Start = DateTime.Now.AddDays(-14).AddHours(2),
                        Stop = DateTime.Now.AddDays(-14).AddHours(3),
                        Price = 24.99M,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 3,
                        TeacherId = 5,
                        Booked = DateTime.Now.AddDays(-16).AddHours(5),
                        StudentId = 24
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-21),
                        Start = DateTime.Now.AddDays(-16).AddHours(2),
                        Stop = DateTime.Now.AddDays(-16).AddHours(3),
                        Price = 30,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 4,
                        TeacherId = 6,
                        Booked = DateTime.Now.AddDays(-18).AddHours(5),
                        StudentId = 23
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-23),
                        Start = DateTime.Now.AddDays(-18).AddHours(2),
                        Stop = DateTime.Now.AddDays(-18).AddHours(3),
                        Price = 5,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 5,
                        TeacherId = 7,
                        Booked = DateTime.Now.AddDays(-20).AddHours(5),
                        StudentId = 25
                    });

                    //    booked lessons passed: stop: add(x < 0) Rated: 5
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-15),
                        Start = DateTime.Now.AddDays(-9).AddHours(2),
                        Stop = DateTime.Now.AddDays(-9).AddHours(3),
                        Price = 0,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 1,
                        TeacherId = 3,
                        Booked = DateTime.Now.AddDays(-10).AddHours(5),
                        StudentId = 25,
                        Completed = true
                        
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-17),
                        Start = DateTime.Now.AddDays(-11).AddHours(2),
                        Stop = DateTime.Now.AddDays(-11).AddHours(3),
                        Price = 19.99M,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 2,
                        TeacherId = 4,
                        Booked = DateTime.Now.AddDays(-12).AddHours(5),
                        StudentId = 23,
                        Completed = true
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-19),
                        Start = DateTime.Now.AddDays(-13).AddHours(2),
                        Stop = DateTime.Now.AddDays(-13).AddHours(3),
                        Price = 24.99M,
                        LessonLevel = LessonLevel.Expert,
                        LocationId = 3,
                        TeacherId = 5,
                        Booked = DateTime.Now.AddDays(-14).AddHours(5),
                        StudentId = 24,
                        Completed = true
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-21),
                        Start = DateTime.Now.AddDays(-17).AddHours(2),
                        Stop = DateTime.Now.AddDays(-17).AddHours(3),
                        Price = 35,
                        LessonLevel = LessonLevel.Intermediate,
                        LocationId = 4,
                        TeacherId = 6,
                        Booked = DateTime.Now.AddDays(-18).AddHours(5),
                        StudentId = 24,
                        Completed = true
                    });
                    db.Lessons.Add(new Lesson
                    {
                        DOC = DateTime.Now.AddDays(-23),
                        Start = DateTime.Now.AddDays(-18).AddHours(2),
                        Stop = DateTime.Now.AddDays(-18).AddHours(3),
                        Price = 5,
                        LessonLevel = LessonLevel.Novice,
                        LocationId = 5,
                        TeacherId = 7,
                        Booked = DateTime.Now.AddDays(-19).AddHours(5),
                        StudentId = 25,
                        Completed = true
                    });
                    db.SaveChanges();
                }
                if (!db.Instruments.Any())
                {
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Cello, InstrumentStyle = InstrumentStyle.Classic, LessonId = 1 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Classic, LessonId = 2 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Classic, LessonId = 3 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Fluit, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 4 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 5 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Harp, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 6 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Pop, LessonId = 7 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Saxophone, InstrumentStyle = InstrumentStyle.Pop, LessonId = 8 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Trumpet, InstrumentStyle = InstrumentStyle.Pop, LessonId = 9 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Violin, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 10 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Vocals, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 11 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Cello, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 12 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Rock, LessonId = 13 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Rock, LessonId = 14 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Fluit, InstrumentStyle = InstrumentStyle.Rock, LessonId = 15 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Classic, LessonId = 16 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Harp, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 17 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Pop, LessonId = 18 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Saxophone, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 19 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Trumpet, InstrumentStyle = InstrumentStyle.Rock, LessonId = 20 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Violin, InstrumentStyle = InstrumentStyle.Classic, LessonId = 21 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Vocals, InstrumentStyle = InstrumentStyle.Classic, LessonId = 22 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Cello, InstrumentStyle = InstrumentStyle.Classic, LessonId = 23 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 24 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 25 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Fluit, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 26 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Pop, LessonId = 27 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Harp, InstrumentStyle = InstrumentStyle.Pop, LessonId = 28 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Pop, LessonId = 29 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Saxophone, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 30 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Trumpet, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 31 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Violin, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 32 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Vocals, InstrumentStyle = InstrumentStyle.Rock, LessonId = 33 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Cello, InstrumentStyle = InstrumentStyle.Rock, LessonId = 34 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Rock, LessonId = 35 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Classic, LessonId = 36 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Fluit, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 37 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Pop, LessonId = 38 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Harp, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 39 });
                    db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Rock, LessonId = 40 });
                    db.SaveChanges();
                }
                if (!db.Alerts.Any())
                {
                    //Booked lessons future: start: add(x < 48) uncancelable: 5-- > yes
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-24),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(24).ToShortDateString()} has been booked.",
                        PersonId = 3
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-24),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(25).ToShortDateString()} has been booked.",
                        PersonId = 4
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-26),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(30).ToShortDateString()} has been booked.",
                        PersonId = 5
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-27),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(36).ToShortDateString()} has been booked.",
                        PersonId = 5
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-21),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(30).ToShortDateString()} has been booked.",
                        PersonId = 4
                    });
                    //Booked lessons future: start: add(x > 48) cancelable: 5-- > yes
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-75),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(220).ToShortDateString()} has been booked.",
                        PersonId = 3
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-55),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(340).ToShortDateString()} has been booked.",
                        PersonId = 4
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-22),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(280).ToShortDateString()} has been booked.",
                        PersonId = 5
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-37),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(265).ToShortDateString()} has been booked.",
                        PersonId = 6
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-44),
                        AlertType = AlertType.Booked,
                        Message = $"Your lesson on {DateTime.Now.AddHours(210).ToShortDateString()} has been cancelled.",
                        PersonId = 7
                    });
                    //booked lessons passed: stop: add(x < 0) Rated: 5 --> yes
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(3),
                        AlertType = AlertType.Rate,
                        Message = $"Your lesson on {DateTime.Now.AddDays(-9).ToShortDateString()} has been rated 4/5.",
                        PersonId = 3
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-8).AddHours(3),
                        AlertType = AlertType.Rate,
                        Message = $"Your lesson on {DateTime.Now.AddDays(-11).ToShortDateString()} has been rated 3/5.",
                        PersonId = 4
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-10).AddHours(3),
                        AlertType = AlertType.Rate,
                        Message = $"Your lesson on {DateTime.Now.AddDays(-13).ToShortDateString()} has been rated 2/5.",
                        PersonId = 5
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-12).AddHours(3),
                        AlertType = AlertType.Rate,
                        Message = $"Your lesson on {DateTime.Now.AddDays(-17).ToShortDateString()} has been rated 5/5.",
                        PersonId = 6
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-15).AddHours(3),
                        AlertType = AlertType.Rate,
                        Message = $"Your lesson on {DateTime.Now.AddDays(-18).ToShortDateString()} has been rated 1/5.",
                        PersonId = 7
                    });

                    //Report Alerts Students
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 27: Student : was reported for: Multiple No-Shows. With the extra message: Student hasn't showed up last three times.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 27: Student : was reported for: Refused to pay. With the extra message: Student didn't want to pay the price.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 28: Student : was reported for: Multiple No-Shows. With the extra message: Student hasn't showed up last three times.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 29: Student : was reported for: Multiple No-Shows. With the extra message: Student hasn't showed up last three times.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 30: Student : was reported for: Multiple No-Shows. With the extra message: Student hasn't showed up last three times.",
                        PersonId = 1
                    });

                    //Report Alerts teachers
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 8: Teacher : was reported for: Multiple No-Shows. With the extra message: Teacher hasn't showed up last three times.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 8: Teacher : was reported for: Inadequate. With the extra message: This teacher was bad.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 9: Teacher : was reported for: Multiple No-Shows. With the extra message: Teacher hasn't showed up last three times.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 10: Teacher : was reported for: Multiple No-Shows. With the extra message: Teacher hasn't showed up last three times.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddDays(-6).AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 11: Teacher : was reported for: Multiple No-Shows. With the extra message: Teacher hasn't showed up last three times.",
                        PersonId = 1
                    });


                    //savechanges
                    db.SaveChanges();
                }
            }           
        }





        static public void TestDatabaseSeeding(MLPDbContext db)
        {
            //password = test1234
            //password = test voor id = 2,9,17

            db.Database.EnsureCreated();
            if (!db.Admins.Any())
            {
                db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "admin@mub", FirstName = "admin", LastName = "admin", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=" });
                db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "dougie.casey@gmail.com", FirstName = "Dougie", LastName = "Casey", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=" });
                db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "duncan.schultz@hotmail.com", FirstName = "Duncan", LastName = "Schultz", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=" });
                db.Admins.Add(new Admin { DOC = DateTime.Now, Email = "martine.matthams@skynet.be", FirstName = "Martine", LastName = "Matthams", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=" });
                db.SaveChanges();
            }
            if (!db.Teachers.Any())
            {
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "zaine.rodrigues@hotmail.com",
                    Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                    FirstName = "Zaine",
                    LastName = "Rodrigues",
                    Description = "Now enrolling in Music Theory for Everyday Guitarists, a group class especially for guitarists eager to understand music and the guitar at a deeper level.  You'll learn to find the notes on the fretboard and how to construct chords and scales independently of charts and diagrams.",
                    Rating = 4.2,
                    RatingCount = 5 
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "mallory.kearns@outlook.com",
                    Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                    FirstName = "Mallory",
                    LastName = "Kearns",
                    Description = "Mallory Kearns guitar, piano, ukulele, voice, banjo, songwriting.  Mallory graduated Cum Laude from Berklee College of Music as a guitar principle with a B.A. in Songwriting.  He plays and teaches rock, jazz, blues, classical, pop, folk, bluegrass and other traditional music genres.",
                    Rating = 4.6,
                    RatingCount = 7
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "rehaan.hamer@telenet.be",
                    Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                    FirstName = "Rehaan",
                    LastName = "Hamer",
                    Description = "Den enigen echte!",
                    Rating = 3.8,
                    RatingCount = 2
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "ferne.woolley@hotmail.com",
                    Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                    FirstName = "Ferne",
                    LastName = "Woolley",
                    Description = "I'm cuddly!",
                    Rating = 4.8,
                    RatingCount = 4
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "usman.mata@skynet.be",
                    Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                    FirstName = "Usman",
                    LastName = "Mata",
                    Description = "I always Mata!",
                    Rating = 4.1,
                    RatingCount = 3
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "nicole.nunez@hotmail.com",
                    Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                    FirstName = "Nicole",
                    LastName = "Nunez",
                    Description = "I'm the old harsh spanish teacher lady!",
                    Rating = 3.7,
                    RatingCount = 9
                });
                db.Teachers.Add(new Teacher
                {
                    DOC = DateTime.Now,
                    Email = "claire.soto@gmail.com",
                    Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                    FirstName = "Claire",
                    LastName = "Soto",
                    Description = "Its a pleasure to meet you!",
                    Rating = 4.5,
                    RatingCount = 15
                });
                db.Teachers.Add(new Teacher
                {
                    
                    DOC = DateTime.Now,
                    Email = "sean.jean@gmail.com",
                    Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=",
                    FirstName = "Sean",
                    LastName = "Jean",
                    Description = "99 problems but piano ain't one",
                    Rating = 3.9,
                    RatingCount = 54
                });
                db.SaveChanges();
            }
            if (!db.Students.Any())
            {
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "lillie.delaney@hotmail.com", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Lillie", LastName = "Delaney" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "brodie.dunn@gmail.com", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Brodie", LastName = "Dunn" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "kayia.summons@telenet.be", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Kayia", LastName = "Summons" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "bill.york@newyork.com", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Bill", LastName = "York" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "keanu.beard@gmail.com", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Keanu", LastName = "Beard" });
                db.Students.Add(new Student { DOC = DateTime.Now, Email = "dick.tracey@syntra.be", Password = "Zb/gaeRgKLHUewP6srisQqI/7gjThAx0Yhnz+3uV4oQ=", FirstName = "Dick", LastName = "Tracey" });
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
                    Start = DateTime.Now.AddHours(220),
                    Stop = DateTime.Now.AddHours(221),
                    Price = 25,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 1,
                    TeacherId = 5,
                    Booked = DateTime.Now.AddHours(-24),
                    StudentId = 13
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
                    StudentId = 14,
                    
                });

                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(320),
                    Stop = DateTime.Now.AddHours(321),
                    Price = 5,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 2,
                    TeacherId = 6
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-48),
                    Start = DateTime.Now.AddHours(420),
                    Stop = DateTime.Now.AddHours(421),
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
                    
                });

                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(520),
                    Stop = DateTime.Now.AddHours(521),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 3,
                    TeacherId = 7
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(620),
                    Stop = DateTime.Now.AddHours(621),
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
                    
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(720),
                    Stop = DateTime.Now.AddHours(721),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 4,
                    TeacherId = 8
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-48),
                    Start = DateTime.Now.AddHours(820),
                    Stop = DateTime.Now.AddHours(921),
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
                    
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-12),
                    Start = DateTime.Now.AddHours(170),
                    Stop = DateTime.Now.AddHours(171),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 5,
                    TeacherId = 9
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(118),
                    Stop = DateTime.Now.AddHours(119),
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
                    StudentId = 17,
                    
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(245),
                    Stop = DateTime.Now.AddHours(246),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 6,
                    TeacherId = 10
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(130),
                    Stop = DateTime.Now.AddHours(131),
                    Price = 25,
                    LessonLevel = LessonLevel.Intermediate,
                    LocationId = 6,
                    TeacherId = 10,
                    Booked = DateTime.Now.AddHours(-4),
                    StudentId = 17
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
                    
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-24),
                    Start = DateTime.Now.AddHours(250),
                    Stop = DateTime.Now.AddHours(251),
                    Price = 25,
                    LessonLevel = LessonLevel.Novice,
                    LocationId = 7,
                    TeacherId = 11
                });
                db.Lessons.Add(new Lesson
                {
                    DOC = DateTime.Now.AddHours(-96),
                    Start = DateTime.Now.AddHours(430),
                    Stop = DateTime.Now.AddHours(431),
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
                    
                });
                db.SaveChanges();
                if (!db.Alerts.Any())
                {
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-24),
                        AlertType = AlertType.Booked,
                        Message = "Your lesson on 03/02/2021 has been booked.",
                        PersonId = 5
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-48),
                        AlertType = AlertType.Cancelled,
                        Message = "Your lesson on 05/04/2021 has been cancelled.",
                        PersonId = 6
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-8),
                        AlertType = AlertType.Rate,
                        Message = "Your lesson on 22/05/2021 has been rated 4/5.",
                        PersonId = 8
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-4),
                        AlertType = AlertType.Booked,
                        Message = "Your lesson on 21/05/2021 has been booked.",
                        PersonId = 7
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-1),
                        AlertType = AlertType.Report,
                        Message = "User 5: Teacher : was reported for: Multiple No-Shows. With the extra message: Teacher hasn't showed up last three times.",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-72),
                        AlertType = AlertType.Cancelled,
                        Message = "Your lesson on 17/05/2021 has been cancelled.",
                        PersonId = 8
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-26),
                        AlertType = AlertType.Cancelled,
                        Message = "Your lesson on 05/04/2021 has been cancelled.",
                        PersonId = 5
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-24),
                        AlertType = AlertType.Report,
                        Message = "User 7: Teacher : was reported for: Inadequate. With the extra message: Teacher claimed to be expert, which he clearly wasn't",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-24),
                        AlertType = AlertType.Rate,
                        Message = "Your lesson on 22/05/2021 has been rated 2/5.",
                        PersonId = 6
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-58),
                        AlertType = AlertType.Booked,
                        Message = "Your lesson on 02/02/2021 has been booked.",
                        PersonId = 9
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-36),
                        AlertType = AlertType.Booked,
                        Message = "Your lesson on 23/04/2021 has been booked.",
                        PersonId = 10
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-4),
                        AlertType = AlertType.Booked,
                        Message = "Your lesson on 08/03/2021 has been booked.",
                        PersonId = 7
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-42),
                        AlertType = AlertType.Cancelled,
                        Message = "Your lesson on 05/04/2021 has been cancelled.",
                        PersonId = 17
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-18),
                        AlertType = AlertType.Booked,
                        Message = "Your lesson on 13/03/2021 has been booked.",
                        PersonId = 6
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-24),
                        AlertType = AlertType.Report,
                        Message = "User 5 : Teacher : was reported for: Inadequate. With the extra message: The dude was bad, like really bad",
                        PersonId = 1
                    });
                    db.Alerts.Add(new Alert
                    {
                        DOC = DateTime.Now.AddHours(-24),
                        AlertType = AlertType.Booked,
                        Message = "Your lesson on 18/04/2021 has been booked.",
                        PersonId = 6
                    });
                    db.SaveChanges();
                    if (!db.Instruments.Any())
                    {
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Cello, InstrumentStyle = InstrumentStyle.Classic, LessonId = 1 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Classic, LessonId = 2 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Fluit, InstrumentStyle = InstrumentStyle.Classic, LessonId = 3 });

                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Saxophone, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 4 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Trumpet, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 5 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 6 });

                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Pop, LessonId = 7 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Pop, LessonId = 8 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Pop, LessonId = 9 });

                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 10 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 11 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Trumpet, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 12 });

                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Drums, InstrumentStyle = InstrumentStyle.Rock, LessonId = 13 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Guitar, InstrumentStyle = InstrumentStyle.Rock, LessonId = 14 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Rock, LessonId = 15 });

                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Cello, InstrumentStyle = InstrumentStyle.Classic, LessonId = 16 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 17 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Fluit, InstrumentStyle = InstrumentStyle.Pop, LessonId = 18 });

                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Harp, InstrumentStyle = InstrumentStyle.Reggae, LessonId = 19 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Piano, InstrumentStyle = InstrumentStyle.Rock, LessonId = 20 });
                        db.Instruments.Add(new Instrument { InstrumentName = InstrumentName.Violin, InstrumentStyle = InstrumentStyle.Jazz, LessonId = 21 });

                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
