
using Business.IdendityValidation.Abstract;
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
        
        public bool  CheckIfRealPerson(UserForRegisterDto userForRegister)
        {
           
            var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var result=  client.TCKimlikNoDogrulaAsync(Convert.ToInt64(userForRegister.NationalityId), userForRegister.FirstName.ToUpper(), userForRegister.LastName.ToUpper(),userForRegister.DateOfBirth);   
            return result.Result.Body.TCKimlikNoDogrulaResult;

        }
    }
}
