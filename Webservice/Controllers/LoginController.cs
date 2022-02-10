using Rawdata_Porfolio_2.Entity_Framework;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using Microsoft.AspNetCore.Routing;
using Webservice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {

        private IDataService _dataService;
        private IConfiguration _configuration;
        private LinkGenerator _linkGenerator;

        public LoginController(IDataService dataService, LinkGenerator linkGenerator, IConfiguration configuration)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _configuration = configuration;

        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel dto)
        {
            byte[] pwBytes = Encoding.Unicode.GetBytes(dto.Password);
            string secret = _configuration.GetSection("Auth:Secret").Value;
            var user = _dataService.GetUserByName(dto.Username);
            if (user == null || !_dataService.Login(dto.Username, pwBytes))
            {
                return BadRequest("Invalid username or password");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.Unicode.GetBytes(secret);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new [] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddSeconds(45),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescription);
            var token = tokenHandler.WriteToken(securityToken);
            
            return Ok(new {dto.Username, token});
        }


    }
}