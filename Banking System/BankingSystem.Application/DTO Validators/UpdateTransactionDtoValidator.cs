using BankingSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTO_Validators
{
    public class UpdateTransactionDtoValidator:AbstractValidator<UpdateTransactionDto>
    {
        public UpdateTransactionDtoValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0).When(x => x.Amount.HasValue)
                .WithMessage("Amount must be greater than 0");

            RuleFor(x => x.TransactionType)
                .MaximumLength(10);

            RuleFor(x => x.Status)
                .MaximumLength(20);
        }
    }
}
