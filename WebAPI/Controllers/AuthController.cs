using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Contants;
using Business.IdendityValidation.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        ICustomerCheckService _CustomerCheckService;

        public AuthController(IAuthService authService, ICustomerCheckService customerCheckService)
        {
            _authService = authService;
            _CustomerCheckService = customerCheckService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            if (_CustomerCheckService.CheckIfRealPerson(userForRegisterDto).Success)
            {
                var userExists = _authService.UserExists(userForRegisterDto.Email);
                if (!userExists.Success)
                {
                    return BadRequest(userExists.Message);
                }

                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            else
            {
                return BadRequest(Messages.UserNotFound);
            }


        }
    }
}
