using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Domain.EntitiesNew;

public partial class Notification
{
    [Key]
    [Column("notification_id")]
    public long NotificationId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("message")]
    public string Message { get; set; } = null!;

    [Column("type")]
    [StringLength(20)]
    public string? Type { get; set; }

    [Column("status")]
    [StringLength(10)]
    public string? Status { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Notifications")]
    public virtual User User { get; set; } = null!;
}
