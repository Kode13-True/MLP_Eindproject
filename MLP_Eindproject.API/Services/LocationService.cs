 using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class LocationService : ILocationService
    {
        private readonly MLPDbContext _context;
        public LocationService(MLPDbContext context)
        {
            _context = context;
        }
        public async Task<Location> CreateLocation(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> DeleteLocationById(int id)
        {
            var locationToRemove = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(locationToRemove);
            await _context.SaveChangesAsync();
            return locationToRemove;
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public async Task<Location> GetLocationById(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<Location> UpdateLocation(int id, Location location)
        {
            var locationToEdit = await _context.Locations.FindAsync(id);
            locationToEdit.Street = location.Street;
            locationToEdit.Number = location.Number;
            locationToEdit.Postal = location.Postal;
            locationToEdit.Township = location.Township;
            await _context.SaveChangesAsync();
            return locationToEdit;
        }
    }
}
