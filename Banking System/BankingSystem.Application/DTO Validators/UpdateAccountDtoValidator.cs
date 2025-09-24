using BankingSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTO_Validators
{
    public class UpdateAccountDtoValidator:AbstractValidator<UpdateAccountDto>
    {
        public UpdateAccountDtoValidator()
        {
            RuleFor(x => x.AccountNumber)
                 .MaximumLength(20).WithMessage("Account number cannot exceed 20 characters.")
                 .When(x => !string.IsNullOrEmpty(x.AccountNumber));

            RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Balance cannot be negative.")
                .When(x => x.Balance.HasValue);

            RuleFor(x => x.AccountType)
                .MaximumLength(20).WithMessage("Account type cannot exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.AccountType));
        }
    }
}
