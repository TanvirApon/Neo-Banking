using BankingSystem.Application.DTOs;
using BankingSystem.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.Interfaces.Notifications
{
    public interface INotificationService
    {
        Task<List<NotificationDto>> GetAllNotificationsAsync();
        Task<NotificationDto?> GetNotificationByIdAsync(long notificationId);
        Task AddNotificationAsync(CreateNotificationDto notification);
        Task UpdateNotificationAsync(long notificationId, UpdateNotificationDto notification);
        Task DeleteNotificationAsync(long notificationId);


    }
}
