using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IAlertService
    {
        Task<Alert> CreateAlert(Alert alert, int personId);
        Task<Alert> GetAlert(int alertId);
        List<Alert> GetAllAlerts();
        Task DeleteAlertById(int alertId);
    }
}
