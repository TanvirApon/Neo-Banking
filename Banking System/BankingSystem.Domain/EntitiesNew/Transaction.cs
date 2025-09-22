using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Domain.EntitiesNew;

public partial class Transaction
{
    [Key]
    [Column("transaction_id")]
    public long TransactionId { get; set; }

    [Column("account_id")]
    public long AccountId { get; set; }

    [Column("amount", TypeName = "decimal(15, 2)")]
    public decimal Amount { get; set; }

    [Column("transaction_type")]
    [StringLength(10)]
    public string? TransactionType { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string? Status { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("fraud_log_id")]
    public long? FraudLogId { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("Transactions")]
    public virtual Account Account { get; set; } = null!;

    [InverseProperty("Transaction")]
    public virtual FraudLog? FraudLog { get; set; }

    [ForeignKey("FraudLogId")]
    [InverseProperty("Transactions")]
    public virtual FraudLog? FraudLogNavigation { get; set; }
}
