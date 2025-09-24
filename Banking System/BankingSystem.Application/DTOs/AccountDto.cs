using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTOs
{
    public class AccountDto
    {
            public long AccountId { get; set; }
            public long UserId { get; set; }
            public string AccountNumber { get; set; } = null!;
            public decimal? Balance { get; set; }
            public string? AccountType { get; set; }
            public DateTime? CreatedAt { get; set; }
     
    }

    public class CreateAccountDto
    {
        public long UserId { get; set; }
        public string AccountNumber { get; set; } = null!;
        public decimal? Balance { get; set; }
        public string? AccountType { get; set; }
    }


    public class UpdateAccountDto
    {
        public string? AccountNumber { get; set; }
        public decimal? Balance { get; set; }
        public string? AccountType { get; set; }
    }

    public class DepostitDto
    {
        public long AccountId { get; set; }
        public decimal Amount { get; set; }
    }

    public class WithdrawDto
    {
        public long AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
