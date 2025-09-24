using BankingSystem.Application.Interfaces.Notifications;
using BankingSystem.Domain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly BankingSystemContext _context;

        public NotificationRepository(BankingSystemContext context)
        {
            this._context = context;

        }

        public async Task<List<Notification>> GetAllNotificationsAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification?> GetNotificationByIdAsync(long notificationId)
        {
            return await _context.Notifications.FindAsync(notificationId);

        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(long notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

    
        
    }
}
