using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieService.Core.Business;
using MovieService.Core.Models.Results;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieService.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region CTOR
        private readonly IConfiguration _configuration;
        private readonly IUserService  _userService;
        public LoginController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        #endregion
        [HttpPost("gettoken")]
        public IActionResult GetToken(LoginForm loginParam)
        {
            var result = _userService.GetUser(loginParam.UserName,loginParam.Password);
            if (result.Success)
            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtParameters:SecretKey"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, result.Data.Username.ToString())
                };


                foreach (var item in result.Data.Rights)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, item));
                }

                var expire = DateTime.Now.AddYears(1);

                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration["JwtParameters:issuer"],
                    audience: _configuration["JwtParameters:audience"],
                    claims: authClaims,
                    expires: expire,
                    notBefore: DateTime.Now,
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new SuccessDataResult<object>(new { Token = tokenString, Expiration = expire }));
            }
            return Unauthorized(new ErrorResult("Kullanıcı bulunamadı!"));
        }
    }
    public class LoginForm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
