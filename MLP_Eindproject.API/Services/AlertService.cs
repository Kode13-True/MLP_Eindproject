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
    public class AlertService : IAlertService
    {
        private readonly MLPDbContext _context;

        public AlertService(MLPDbContext context)
        {
            _context = context;
        }
        public async Task<Alert> CreateAlert(Alert alert)
        {
            alert.DOC = DateTime.Now;
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
            return alert;
        }

        public Alert GetAlert(int alertId)
        {
            var alert =  _context.Alerts.Where(x => x.Id == alertId).FirstOrDefault();
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

        public List<Alert> GetAlertsByPersonId(int id)
        {
            var alerts = _context.Alerts.Where(x => x.PersonId == id).ToList();
            return alerts;
        }

        public async Task<Alert> ReportUser(Alert newAlert)
        {
            var admin = _context.Admins.First();
            newAlert.PersonId = admin.Id;
            _context.Alerts.Add(newAlert);
            await _context.SaveChangesAsync();
            return newAlert;
        }

        public object GetAlertsByAdmin()
        {
            var admin = _context.Admins.First();
            var alerts = _context.Alerts.Where(x => x.PersonId == admin.Id).ToList();
            return alerts;
        }
    }
}
