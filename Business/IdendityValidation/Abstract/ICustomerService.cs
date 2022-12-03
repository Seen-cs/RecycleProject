using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IdendityValidation.Abstract
{
    public interface  ICustomerService
    {
        void Save(UserForRegisterDto userForRegister);
    }
}
