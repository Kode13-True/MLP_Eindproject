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
        public Location CreateLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
            return location;
        }

        public Location DeleteLocationById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetAllLocations()
        {
            throw new NotImplementedException();
        }

        public Location GetLocationById(int id)
        {
            throw new NotImplementedException();
        }

        public Location UpdateLocation(int id, Location location)
        {
            throw new NotImplementedException();
        }
    }
}
