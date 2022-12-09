using Core.Utilities.Results;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IdendityValidation.Abstract
{
    public interface ICustomerCheckService
    {
        IResult CheckIfRealPerson(UserForRegisterDto userForRegister);
    }
}
