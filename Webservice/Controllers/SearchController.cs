using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Rawdata_Porfolio_2.Entity_Framework;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webservice.ViewModels;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("api/PersonalitySearch")]
    public class SearchController : Controller
    {
        private IDataService _dataService;
        private LinkGenerator _linkGenerator;

        public SearchController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("personalities/{personalityString}", Name = nameof(GetPersonalitiesFromSearchResults))]
        public IActionResult GetPersonalitiesFromSearchResults(int? userID, string personalityString)
        {
            var result = _dataService.ActorSearch(userID, personalityString);

            return Ok(result);
        }

        [HttpGet("titles/{titleString}", Name = nameof(GetTitlesFromSearchResults))]
        public IActionResult GetTitlesFromSearchResults(int? userID, string titleString)
        {
            var result = _dataService.StringSearch(userID, titleString);

            return Ok(result);
        }
    }
}