using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var tokenResult = _authService.CreateAccessToken(userToLogin.Data);
            if (!tokenResult.Success)
            {
                return BadRequest(tokenResult);
            }
            AuthDto authDto = new AuthDto
            {
                UserId=userToLogin.Data.Id,
                FirstName = userToLogin.Data.FirstName,
                LastName = userToLogin.Data.LastName,
                Token = tokenResult.Data.Token,
                Expiration = tokenResult.Data.Expiration,
            };
            var result = new SuccessDataResult<AuthDto>(authDto, userToLogin.Message);
            return Ok(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var tokenResult = _authService.CreateAccessToken(registerResult.Data);
            if (!tokenResult.Success)
            {
                return BadRequest(tokenResult);
            }
            var loginDto = new UserForLoginDto
            {
                Email = userForRegisterDto.Email,
                Password = userForRegisterDto.Password
            };
            var userToLogin = _authService.Login(loginDto).Data.Id;
            AuthDto authDto = new AuthDto
            {
                UserId=userToLogin,
                FirstName = registerResult.Data.FirstName,
                LastName = registerResult.Data.LastName,
                Token = tokenResult.Data.Token,
                Expiration = tokenResult.Data.Expiration
            };
            var result = new SuccessDataResult<AuthDto>(authDto,registerResult.Message);
            return Ok(result);
        }
    }
}