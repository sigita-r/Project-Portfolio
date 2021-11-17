using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rawdata_Porfolio_2;
using Rawdata_Porfolio_2.Entity_Framework;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using Microsoft.AspNetCore.Routing;
using Webservice.ViewModels;
using System.Text;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        IDataService _dataService;
        LinkGenerator _linkGenerator;

        public UserController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        // works in a bad way, cant get it to work correctly
     //   [HttpGet("{id}", Name = nameof(GetUser))]
        [HttpGet("id", Name = nameof(GetUser))]

        public IActionResult GetUser(int ID)
        {
            var user = _dataService.GetUser(ID);

            if (user == null)
            {
                return NotFound("no user found");
            }

            return Ok(GetUserViewModel(user));
        }


        [HttpPost]
        public IActionResult CreateUser(string userName, string password, string email, DateTime dob)
        {
            // checks

            // convert pw string to byte[]
            byte[] pwBytes = Encoding.Unicode.GetBytes(password);


          var user = _dataService.CreateUser(userName, pwBytes, email, dob);

            

            // I dont know what else to put here, but it works and adds to database
            return Created("", user);
        }

        private UserViewModel GetUserViewModel(User user)
        {
            return new UserViewModel
            {
               // Url = _linkGenerator.GetUriByName(HttpContext, nameof(GetUser), new { user.Id }),
                Username = user.Username,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };
        }

    }
}