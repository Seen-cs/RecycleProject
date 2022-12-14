using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOS;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace TestProject
{
    

    [TestClass]
    public class AuthManagerTest
    {
        [TestMethod]
        public void TestingRegister()
        {
            IConfiguration config = new ConfigurationBuilder().Build();
            IAuthService authService = new AuthManager(new UserManager(new EfUserDal()), new JwtHelper(config));
            UserForRegisterDto userForRegisterDto = new UserForRegisterDto();
            userForRegisterDto.FirstName = "Emre";
            userForRegisterDto.LastName = "kurt";
            userForRegisterDto.NationalityId = "11111";
            userForRegisterDto.Email = "emre@gmail.com";
            var sifre = userForRegisterDto.Password = "1234";
             var result=authService.Register(userForRegisterDto,sifre);
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void TestingLogin()
        {
            IConfiguration config = new ConfigurationBuilder().Build();
            IAuthService authService = new AuthManager(new UserManager(new EfUserDal()), new JwtHelper(config));
            UserForLoginDto userForLoginDto = new UserForLoginDto();
            userForLoginDto.Email= "emre@gmail.com";
            userForLoginDto.Password = "1234";
            var result = authService.Login(userForLoginDto);
            Assert.AreEqual(true, result.Success);

         //   authService.Login();
        }
    }
}
