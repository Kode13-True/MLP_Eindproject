using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Location> CreateLocation(Location location);
        List<Location> GetAllLocations();
        Task<Location> GetLocationById(int id);
        Task<Location> UpdateLocation(int id, Location location);
        Task<Location> DeleteLocationById(int id);
    }
}
