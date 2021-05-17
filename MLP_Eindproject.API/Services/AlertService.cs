using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class AlertService : IAlertService
    {
        private readonly MLPDbContext _context;

        public AlertService(MLPDbContext context)
        {
            _context = context;
        }
        public async Task<Alert> CreateAlert(Alert alert, int personId)
        {
            alert.DOC = DateTime.Now;
            //alert.PersonId = personId;
            await _context.Alerts.AddAsync(alert);
            await _context.SaveChangesAsync();
            return alert;
        }

        public async Task<Alert> GetAlert(int alertId)
        {
            var alert = await _context.Alerts.FindAsync(alertId);
            return alert;
        }

        public List<Alert> GetAllAlerts()
        {
            var listOfAlerts = _context.Alerts.ToList();
            return listOfAlerts;
        }

        public async Task DeleteAlertById(int alertId)
        {
            var AlertToDelete = _context.Alerts.Find(alertId);
            _context.Alerts.Remove(AlertToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
