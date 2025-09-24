using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Domain.EntitiesNew;

[Index("AccountNumber", Name = "UQ__Accounts__AF91A6AD0EB30CE3", IsUnique = true)]
public partial class Account
{
    [Key]
    [Column("account_id")]
    public long AccountId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("account_number")]
    [StringLength(20)]
    public string AccountNumber { get; set; } = null!;

    [Column("balance", TypeName = "decimal(15, 2)")]
    public decimal? Balance { get; set; }

    [Column("account_type")]
    [StringLength(20)]
    public string? AccountType { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Account")]
    public virtual ICollection<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();

    [ForeignKey("UserId")]
    [InverseProperty("Accounts")]
    public virtual User User { get; set; } = null!;
}
