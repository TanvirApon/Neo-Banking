using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTOs
{
    public class TransactionDto
    {
        public long TransactionId { get; set; }
        public long AccountId { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionType { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? FraudLogId { get; set; }
    }

    public class CreateTransactionDto
    {
        public long AccountId { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionType { get; set; }
    }

    public class UpdateTransactionDto
    {
        public decimal? Amount { get; set; }
        public string? TransactionType { get; set; }
        public string? Status { get; set; }
    }
}
