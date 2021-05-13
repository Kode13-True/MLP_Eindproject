using Microsoft.EntityFrameworkCore;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class SearchService : ISearchService
    {
        private readonly MLPDbContext _context;
        public SearchService(MLPDbContext context)
        {
            _context = context;
        }

        public List<Lesson> SearchLessons(InstrumentName? instrumentName = null, InstrumentStyle? instrumentStyle = null, decimal? price = null, string postal = "", string teacherName = "")
        {
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
            if (instrumentName != null && instrumentStyle != null && price != null && postal != null)
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
            if (instrumentName != null && instrumentStyle != null && price != null)
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
            //option 04
            if (instrumentName != null && instrumentStyle != null)
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
            //option 05
            if (instrumentName != null)
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
            //option 06
            if (instrumentStyle != null && price != null && postal != null && teacherName != null)
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
            if (instrumentStyle != null && price != null && postal != null)
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
            //option 08
            if (instrumentStyle != null && price != null)
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
            //option 09
            if (instrumentStyle != null)
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
            //option 10
            if (price != null && postal != null && teacherName != null)
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
            //option 11
            if (price != null && postal != null)
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
            //option 12
            if (price != null)
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
            //option 13
            if (postal != null && teacherName != null)
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
            //option 14
            if (postal != null)
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
            //option 15
            if (teacherName != null)
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
            //option 16
            if (instrumentName != null && price != null && postal != null && teacherName != null)
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
            //option 17
            if (instrumentName != null && price != null && postal != null)
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
            //option 18
            if (instrumentName != null && price != null)
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
            if (instrumentName != null && instrumentStyle != null && postal != null && teacherName != null)
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
            //option 20
            if (instrumentName != null && instrumentStyle != null && postal != null)
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
            //option 21
            if (instrumentName != null && instrumentStyle != null && price != null && teacherName != null)
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
            //option 22
            if (instrumentStyle != null && price != null && postal != null)
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
            //option 23
            if (instrumentName != null && price != null && teacherName != null)
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
            //option 24
            if (instrumentName != null && teacherName != null)
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
            //option 25
            if (instrumentStyle != null && postal != null)
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
            //option 26
            if (instrumentName != null && instrumentStyle != null && teacherName != null)
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
            //option 27
            if (instrumentName != null && postal != null && teacherName != null)
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
            //option 28
            if (instrumentName != null && price != null && postal != null)
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
            //option 29
            if (instrumentStyle != null && price != null && teacherName != null)
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
            //option 30
            if (instrumentStyle != null && teacherName != null)
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
            //option 31
            if (price != null && teacherName != null)
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
