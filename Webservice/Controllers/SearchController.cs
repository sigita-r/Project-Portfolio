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
    [Route("api/Search")]
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

        /*
        [HttpGet("SSSearch/asd", Name = nameof(SS_Search))]
        public IActionResult SS_Search(int? userID, string title_Query, string plot_Query, string character_Query, string name_Query)
        {
            var result = _dataService.SS_Search(userID, title_Query, title_Query, character_Query, name_Query);

            return Ok(result);
        }
        */
    }
}