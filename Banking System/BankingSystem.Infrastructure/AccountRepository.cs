using BankingSystem.Application.Interfaces.Accounts;
using BankingSystem.Domain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure
{
    public class AccountRepository : IAccountRepository
    {

        private readonly BankingSystemContext _context;

        public AccountRepository(BankingSystemContext context)
        {
            this._context = context;
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
           return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(long accountId)
        {
            return await _context.Accounts.FindAsync(accountId);
        }


        public async Task AddAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(long accountId)
        {
            var account = _context.Accounts.Find(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
               await _context.SaveChangesAsync();
            }
        }

    }
}
