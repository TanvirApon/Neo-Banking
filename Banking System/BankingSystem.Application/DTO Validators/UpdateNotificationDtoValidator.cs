using BankingSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTO_Validators
{
   public class UpdateNotificationDtoValidator:AbstractValidator<UpdateNotificationDto>
    {
        public UpdateNotificationDtoValidator()
        {
            RuleFor(x => x.Message).MaximumLength(500);
            RuleFor(x => x.Type).MaximumLength(20);
            RuleFor(x => x.Status).MaximumLength(10);
        }
    }
}
