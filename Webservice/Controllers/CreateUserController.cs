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

namespace Webservice.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class CreateUserController : Controller
    {

        private IDataService _dataService;
        private IConfiguration _configuration;
        private LinkGenerator _linkGenerator;

        public CreateUserController(IDataService dataService, LinkGenerator linkGenerator, IConfiguration configuration)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _configuration = configuration;

        }

        [HttpPost("register")]
        public IActionResult Register(CreateUserViewModel dto)
        {
            byte[] pw = Encoding.Unicode.GetBytes(dto.Password);
            _dataService.CreateUser(dto.Username, pw, dto.Email, dto.DateOfBirth);
            return CreatedAtRoute(null, new {dto.Username});
        }
    }
}