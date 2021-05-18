using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MLP_TestLibrary.Extensions
{
    public static class SearchExtensions
    {
        public static List<Lesson> Searchfunction(this ServiceProvider serviceProvider, InstrumentName? instrumentName = null, InstrumentStyle? instrumentStyle = null, decimal? price = null, string postal = "", string teacherName = "")
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var _context = scopedServices.GetRequiredService<MLPDbContext>();

                //option 01
                if (instrumentName != null && instrumentStyle != null && price != null && postal != null && teacherName != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName && x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 02
                else if (instrumentName != null && instrumentStyle != null && price != null && postal != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName && x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 03
                else if (instrumentName != null && instrumentStyle != null && price != null && teacherName != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName && x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 04
                else if (instrumentName != null && instrumentStyle != null && postal != null && teacherName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName && x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 05
                else if (instrumentName != null && price != null && postal != null && teacherName != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 06
                else if (instrumentStyle != null && price != null && postal != null && teacherName != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 07
                else if (instrumentName != null && instrumentStyle != null && price != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName && x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 08
                else if (instrumentName != null && instrumentStyle != null && postal != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName && x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 09
                else if (instrumentName != null && instrumentStyle != null && teacherName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName && x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 10
                else if (instrumentName != null && price != null && postal != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 11
                else if (instrumentName != null && price != null && teacherName != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 12
                else if (instrumentName != null && postal != null && teacherName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 13
                else if (instrumentStyle != null && price != null && postal != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 14
                else if (instrumentStyle != null && price != null && teacherName != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 15
                else if (instrumentStyle != null && postal != null && teacherName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 16
                else if (price != null && postal != null && teacherName != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 17
                else if (instrumentName != null && instrumentStyle != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName && x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 18
                else if (instrumentName != null && price != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 19
                else if (instrumentName != null && postal != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 20
                else if (instrumentName != null && teacherName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 21
                else if (instrumentStyle != null && price != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 22
                else if (instrumentStyle != null && postal != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 23
                else if (instrumentStyle != null && teacherName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 24
                else if (price != null && postal != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 25
                else if (price != null && teacherName != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 26
                else if (postal != null && teacherName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 27
                else if (instrumentName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentName == instrumentName)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 28
                else if (instrumentStyle != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Where(x => x.Instrument.InstrumentStyle == instrumentStyle)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 29
                else if (price != null)
                {
                    return _context.Lessons
                   .Where(x => x.Price <= price)
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 30
                else if (postal != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Where(x => x.Location.Postal == postal)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 31
                else if (teacherName != null)
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Where(x => x.Teacher.LastName == teacherName)
                   .Include(x => x.Instrument)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }
                //option 32
                else
                {
                    return _context.Lessons
                   .Include(x => x.Location)
                   .Include(x => x.Teacher)
                   .Include(x => x.Instrument)
                   .Include(x => x.Student)
                   .Where(x => x.StudentId == null)
                   .ToList();
                }

            }
                
        }
    }
}
