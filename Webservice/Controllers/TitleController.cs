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
    [Route("api/titles")]
    public class TitleController : Controller
    {
        IDataService _dataService;
        LinkGenerator _linkGenerator;

        public TitleController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(int id)
        {
            var title = _dataService.GetTitles(id);

            if (title == null)
            {
                return NotFound();
            }

            return Ok(GetTitleViewModel(title));
        }
        /*
        [HttpGet("{id}", Name = nameof(GetCharactersFromTitle))]
        public IActionResult GetCharactersFromTitle(int id)
        {
            var title = _dataService.GetTitles(id);

            if (title == null)
            {
                return NotFound();
            }

            return Ok(GetTitleViewModel(title)); //idk what we should return here
        }
        */

        [HttpGet]
        public IActionResult GetTitles()
        {
            var titles = _dataService.GetTitles();

            return Ok(titles.Select(x => GetTitleViewModel(x)));
        }
        
        private TitleViewModel GetTitleViewModel(Title title)
        {
            return new TitleViewModel
            {
               // Url = (_linkGenerator.GetUriByName(HttpContext, ),
                Type = title.Type,
              //  Genre = title.Genre,
               // Primary_Title = title.Primary_Title,
                Is_Adult = title.IsAdult,
                Year_Start = title.Year_Start,
                Year_End = title.Year_End,
                Runtime = title.Runtime,
              //  Avg_Rating = title.AvgRating,
                Poster = title.Poster,
                Plot = title.Plot,
                Awards = title.Awards,
               // Language = title.Language,
                //Region = title.Region,
                
            };
        }
    }
}
