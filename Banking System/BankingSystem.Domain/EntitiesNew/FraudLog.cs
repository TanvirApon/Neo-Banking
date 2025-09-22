using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Domain.EntitiesNew;

[Index("TransactionId", Name = "UQ__FraudLog__85C600AEA5D5E0E9", IsUnique = true)]
public partial class FraudLog
{
    [Key]
    [Column("fraud_id")]
    public long FraudId { get; set; }

    [Column("transaction_id")]
    public long TransactionId { get; set; }

    [Column("fraud_type")]
    [StringLength(50)]
    public string? FraudType { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("detected_at", TypeName = "datetime")]
    public DateTime? DetectedAt { get; set; }

    [ForeignKey("TransactionId")]
    [InverseProperty("FraudLog")]
    public virtual Transaction Transaction { get; set; } = null!;

    [InverseProperty("FraudLogNavigation")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
