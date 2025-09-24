using BankingSystem.Application.DTOs;
using FluentValidation;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTO_Validators
{
    public class DepositeDtoValidator:AbstractValidator<DepostitDto>
    {
        public DepositeDtoValidator()
        {
            RuleFor(x => x.AccountId)
                .GreaterThan(0).WithMessage("AccountId must be greater than 0");

            RuleFor(x => x.Amount) 
                .GreaterThan(0).WithMessage("Deposit amount must be greater than zero");
        }
    }
}
