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

        [HttpGet("titles/{userID}/{titleString}")]
        public IActionResult GetTitlesFromSearchResults(int? userID, string titleString)
        {
            Console.WriteLine(userID);
            Console.WriteLine(titleString);
            var result = _dataService.StringSearch(userID, titleString);

            if (result == null)
            {
                return NotFound();
            }    
            
            return Ok(result.Select(x => GetSearchResultsViewModel(x)));
        }

        /*
        [HttpGet("SSSearch/asd", Name = nameof(SS_Search))]
        public IActionResult SS_Search(int? userID, string title_Query, string plot_Query, string character_Query, string name_Query)
        {
            var result = _dataService.SS_Search(userID, title_Query, title_Query, character_Query, name_Query);

            return Ok(result);
        }
        */
        private SearchResultsViewModel GetSearchResultsViewModel(Search_results results)
        {
            return new SearchResultsViewModel
            {
                Title_ID = results.Title_ID,
                Plot = results.Plot,
                Type = results.Type,
                Name = results.Name,
                IsAdult = results.IsAdult,
                Year_Start = results.Year_Start,
                Year_End = results.Year_End,
                Runtime = results.Runtime,
                Avg_Rating = results.Avg_Rating,
                Poster = results.Poster,
                Awards = results.Awards,
                Genres = results.Genres
            };
        }
    }
}