using Rawdata_Porfolio_2.Entity_Framework;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using Microsoft.AspNetCore.Routing;
using Webservice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {

        private IDataService _dataService;
        private LinkGenerator _linkGenerator;

        public LoginController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;

        }

        [HttpGet("login")]
        public IActionResult Login(string username, string password)
        {
            byte[] pwBytes = Encoding.Unicode.GetBytes(password);
            
            var usercheck = _dataService.Login(username, pwBytes);
            if (usercheck == "Username not found")
            {
                return NotFound();
            }
            return Ok();
        }

    }
}