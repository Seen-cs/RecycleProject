using Business.Contants;
using Business.IdendityValidation.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using Entities.DTOS;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Business.IdendityValidation.Adapter
{
    public class MernisServiceAdapter : ICustomerCheckService
    {
        [ValidationAspect(typeof(MernisValidator))]
        public IResult CheckIfRealPerson(UserForRegisterDto userForRegister)
        {
            var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var result = client.TCKimlikNoDogrulaAsync(Convert.ToInt64(userForRegister.NationalityId), userForRegister.FirstName.ToUpper(), userForRegister.LastName.ToUpper(), userForRegister.DateOfBirth);
            var a = result.Result.Body.TCKimlikNoDogrulaResult;
            if (a)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotIdendity);

        }
       
    }
}
