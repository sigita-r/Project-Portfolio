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

namespace Webservice.Controllers
{
    
    [ApiController]
    [Route("api/searchHistory")]
    public class SearchHistoryController : Controller
    {
        IDataService _dataService;
        LinkGenerator _linkGenerator;

        public SearchHistoryController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }



        [HttpGet("user/userId")]
        public IActionResult GetSearchHistoryFromUser(int userID)
        {

            var searchHistory = _dataService.GetSQ(userID);

            if (searchHistory.Count() == 0)
            {
                return NotFound("no searches");
            }

            return Ok(searchHistory);
        }

        //[HttpGet("user/userId")]
        //public IActionResult DeleteSearchHistoryFromUser(int ID)
        //{

        //    var searchHistory = _dataService.GetSQ(ID);

        //    if (searchHistory.Count() == 0)
        //    {
        //        return NotFound("no search matching that ID");
        //    }

        //    return Ok(searchHistory);
        //}

    }
    
}
