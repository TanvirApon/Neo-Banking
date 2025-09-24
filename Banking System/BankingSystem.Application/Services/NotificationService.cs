using AutoMapper;
using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.Services
{
    public class NotificationService : INotificationService
    {
         private readonly INotificationRepository _notificationRepository;
         private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            this._notificationRepository = notificationRepository;
            this._mapper = mapper;
        }

        public async Task<List<NotificationDto>> GetAllNotificationsAsync()
        {
            var notifications = await _notificationRepository.GetAllNotificationsAsync();
            return _mapper.Map<List<NotificationDto>>(notifications);
        }

        public async Task<NotificationDto?> GetNotificationByIdAsync(long notificationId)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(notificationId);
            return notification == null ? null : _mapper.Map<NotificationDto>(notification);
        }

        public async Task AddNotificationAsync(CreateNotificationDto notification)
        {
            var newNotification = _mapper.Map<Domain.EntitiesNew.Notification>(notification);
            await _notificationRepository.AddNotificationAsync(newNotification);

        }

        public async Task UpdateNotificationAsync(long notificationId, UpdateNotificationDto dto)
        {
            var existingNotification = await _notificationRepository.GetNotificationByIdAsync(notificationId);

            if (existingNotification == null) throw new Exception("Notification not found");

            _mapper.Map(dto, existingNotification);

            await _notificationRepository.UpdateNotificationAsync(existingNotification);
        }


        public async Task DeleteNotificationAsync(long notificationId)
        {
            var notification =  _notificationRepository.GetNotificationByIdAsync(notificationId);
            
            if (notification == null) throw new Exception("Notification not found");
            
            await _notificationRepository.DeleteNotificationAsync(notificationId);

        }

      
    }
}
