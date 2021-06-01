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
    public class AdminService : IAdminService
    {
        private readonly MLPDbContext _context;

        public AdminService(MLPDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> CreateAdmin(Admin admin)
        {
            admin.DOC = DateTime.Now;
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
        }
        public async Task<Admin> GetAdmin(int personId)
        {
            var admin = await _context.Admins.FindAsync(personId);
            return admin;
        }

        public List<Admin> GetAllAdmins()
        {
            var listOfAdmins = _context.Admins.ToList();
            return listOfAdmins;
        }

        public async Task<Admin> UpdateAdminById(int personIdToEdit, Admin adminEditValue)
        {
            var personToEdit = await _context.Admins.FindAsync(personIdToEdit);
            personToEdit.FirstName = adminEditValue.FirstName;
            personToEdit.LastName = adminEditValue.LastName;
            personToEdit.Email = adminEditValue.Email;
            _context.Admins.Update(personToEdit);
            await _context.SaveChangesAsync();
            return personToEdit;
        }

        public async Task DeleteAdminById(int personId)
        {
            var AdminToDelete = _context.Admins.Find(personId);
            _context.Admins.Remove(AdminToDelete);
            await _context.SaveChangesAsync();
        }

        public int [] GetNumberOfUsers() 
        {
            var countList = new int[] { _context.Students.Count(), 
                                        _context.Teachers.Count(), 
                                        _context.Admins.Count() };
            return countList;
        }
        public int [] GetNumberOfLessons()
        {
            var countList = new int[] { _context.Lessons.Count(), 
                                        _context.Lessons.Where(x => x.StudentId != null).Count(), 
                                        _context.Lessons.Where(x => x.StudentId != null).Where(x => x.Start > DateTime.Now).Count() };
            return countList;
        }
        public int [] GetNumberOfLevels()
        {
            var countList = new int[] { _context.Lessons.Where(x => x.LessonLevel == LessonLevel.Novice).Count(), 
                                        _context.Lessons.Where(x => x.LessonLevel == LessonLevel.Intermediate).Count(), 
                                        _context.Lessons.Where(x => x.LessonLevel == LessonLevel.Expert).Count() };
            return countList;
        }
        public int[] GetNumberOfStyles()
        {
            var countList = new int[] { _context.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Classic).Count(),
                                        _context.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Rock).Count(),
                                        _context.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Jazz).Count(),
                                        _context.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Pop).Count(),
                                        _context.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Reggae).Count()};
            return countList;
        }
        public int[] GetNumberOfInstruments()
        {
            var countlist = new int[] { _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Vocals).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Piano).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Guitar).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Violin).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Drums).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Saxophone).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Fluit).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Cello).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Clarinet).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Trumpet).Count(),
                                        _context.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Harp).Count()
            };
            return countlist;
        }

    }
}
