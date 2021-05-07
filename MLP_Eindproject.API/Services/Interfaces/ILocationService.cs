using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface ILocationService
    {
        Location CreateLocation(Location location);
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        Location UpdateLocation(int id, Location location);
        Location DeleteLocationById(int id);
    }
}
