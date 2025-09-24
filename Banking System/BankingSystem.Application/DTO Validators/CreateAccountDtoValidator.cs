using BankingSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTO_Validators
{
    public class CreateAccountDtoValidator:AbstractValidator<CreateAccountDto>
    {
        public CreateAccountDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.AccountNumber)
                .NotEmpty().WithMessage("AccountNumber is required")
               .MaximumLength(20).WithMessage("AccountNumber must not exceed 20 characters");

            RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Balance must be greater than or equal to 0");


            RuleFor(x => x.AccountType)
                .NotEmpty().WithMessage("AccountType is required")
                .MaximumLength(20).WithMessage("AccountType must not exceed 20 characters");
        }
    }
}
