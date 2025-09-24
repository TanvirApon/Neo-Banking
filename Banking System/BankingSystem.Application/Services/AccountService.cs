using AutoMapper;
using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Accounts;
using BankingSystem.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            this._accountRepository = accountRepository;
            this._mapper = mapper;
        }

        public async Task<List<AccountDto>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepository.GetAllAccountsAsync();
            return _mapper.Map<List<AccountDto>>(accounts);

        }

        public async Task<AccountDto?> GetAccountByIdAsync(long accountId)
        {
           var account = await _accountRepository.GetAccountByIdAsync(accountId);
            return account == null ? null : _mapper.Map<AccountDto>(account);

        }

        public async Task AddAccountAsync(CreateAccountDto createAccountDto)
        {
            var account =  _mapper.Map<Account>(createAccountDto);
            await  _accountRepository.AddAccountAsync(account);
        }


        public async Task UpdateAccountAsync(long accountId, UpdateAccountDto updateAccountDto)
        {
            var account = _accountRepository.GetAccountByIdAsync(accountId).Result;
            if (account == null) throw new Exception("Account not found");

            _mapper.Map(updateAccountDto, account);

            await _accountRepository.UpdateAccountAsync(account);
        }

        public async Task DeleteAccountAsync(long accountId)
        {
            var account = _accountRepository.GetAccountByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found");

            await _accountRepository.DeleteAccountAsync(accountId);
        }

        public async Task DepositAsync(DepostitDto depostitDto)
        {
            var account = await _accountRepository.GetAccountByIdAsync(depostitDto.AccountId);
            if (account == null)
                throw new Exception("Account not found");

        
            if (depostitDto.Amount <= 0)
                throw new Exception("Deposit amount must be greater than zero");

            account.Balance = (account.Balance ?? 0) + depostitDto.Amount;

          
            await _accountRepository.UpdateAccountAsync(account);

        }


        public async Task WithdrawAsync(WithdrawDto withdrawDto)
        {
            var account = await _accountRepository.GetAccountByIdAsync(withdrawDto.AccountId);
            if (account == null)
                throw new Exception("Account not found");

           
            if (withdrawDto.Amount <= 0)
                throw new Exception("Withdraw amount must be greater than zero");

            if ((account.Balance ?? 0) < withdrawDto.Amount)
                throw new Exception("Insufficient balance");

      
            account.Balance -= withdrawDto.Amount;

            
            await _accountRepository.UpdateAccountAsync(account);
        }
    }
}
