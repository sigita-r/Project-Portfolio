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
        private IDataService _dataService;
        private LinkGenerator _linkGenerator;

        public UserController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{ID}", Name = nameof(GetUser))]
        public IActionResult GetUser(int ID)
        {
            var user = _dataService.GetUser(ID);

            if (user == null)
            {
                return NotFound();
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

        [HttpGet("userUpdated", Name = nameof(UpdateUser))]
        public IActionResult UpdateUser(int userID, string email, string username, string password, DateTime? dob)
        {
            // convert pw string to byte[]
            byte[] pwBytes = Encoding.Unicode.GetBytes(password);
            _dataService.UpdateUser(userID, email, username, pwBytes, dob);
            return Ok();
        }

        [HttpGet("userDeleted", Name = nameof(DeleteUser))]
        public IActionResult DeleteUser(int userID)
        {
            _dataService.DeleteUser(userID);
            return Ok();
        }

        private UserViewModel GetUserViewModel(User user)
        {
            return new UserViewModel
            {
                Url = _linkGenerator.GetUriByName(HttpContext, nameof(GetUser), new { user.Id }),
                Username = user.Username,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };
        }
    }
}