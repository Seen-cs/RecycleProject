using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IdendityValidation.Abstract
{
    public abstract class BaseCustomerManager : ICustomerService
    {
        public virtual void Save(UserForRegisterDto userForRegister)
        {
            Console.WriteLine("veri tabanına kaydedildi: " + userForRegister.FirstName);
        }
    }
}
