using Entities.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MernisValidator: AbstractValidator<UserForRegisterDto>
    {
        public MernisValidator()
        {
            RuleFor(p => p.NationalityId).Length(11);
        }
    }
}
