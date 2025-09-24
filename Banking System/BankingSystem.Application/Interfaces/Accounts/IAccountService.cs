using BankingSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.Interfaces.Accounts
{
    public interface IAccountService
    {
        Task<List<AccountDto>> GetAllAccountsAsync();
        Task<AccountDto?> GetAccountByIdAsync(long accountId);
        Task AddAccountAsync(CreateAccountDto createAccountDto);
        
        Task UpdateAccountAsync(long accountId, UpdateAccountDto updateAccountDto);

        Task DeleteAccountAsync(long accountId);

        Task DepositAsync(DepostitDto depostitDto);

        Task WithdrawAsync(WithdrawDto withdrawDto);
    }
}
