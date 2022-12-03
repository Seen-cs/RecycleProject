﻿using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IdendityValidation.Abstract
{
    public interface ICustomerCheckService
    {
        bool CheckIfRealPerson(UserForRegisterDto userForRegister);
    }
}
