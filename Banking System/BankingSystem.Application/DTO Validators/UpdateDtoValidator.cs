using BankingSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTO_Validators
{
    public class UpdateDtoValidator: AbstractValidator<UpdateUserDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Email) 
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Phone)
                .MaximumLength(11).WithMessage("Phone number cannot exceed 15 characters.")
                .When(x => !string.IsNullOrEmpty(x.Phone));
        }
    }
}
