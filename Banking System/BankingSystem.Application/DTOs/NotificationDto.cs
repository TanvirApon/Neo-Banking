using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTOs
{
    public class NotificationDto
    {
        public long NotificationId { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; } = null!;
        public string? Type { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }


    public class CreateNotificationDto
    {
        public long UserId { get; set; }
        public string Message { get; set; } = null!;
        public string? Type { get; set; }
    }


    public class UpdateNotificationDto
    {
        public string? Message { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
    }
}
