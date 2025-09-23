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
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            
           RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");
            
            RuleFor(x => x.Phone)
                .MaximumLength(11).WithMessage("Phone number cannot exceed 15 characters.")
                .When(x => !string.IsNullOrEmpty(x.Phone));

           
        }

    }
}