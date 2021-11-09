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

        [HttpGet]
        public IActionResult GetTitles()
        {
            var titles = DataService.GetTitles();

            return Ok(titles.Select(x => GetTitleViewModel(x)));
        }

        private TitleViewModel GetTitleViewModel(Title title)
        {
            return new TitleViewModel
            {
                // Some IDs have a space encoded as %20. Here we remove the encoding from the URL
                Url = (_linkGenerator.GetUriByName(HttpContext, nameof(GetTitle), new { title.Id })).Replace("%20", ""),
                TitleType = title.TitleType,
                PrimaryTitle = title.PrimaryTitle,
                OriginalTitle = title.OriginalTitle,
                IsAdult = title.IsAdult,
                StartYear = title.StartYear,
                EndYear = title.EndYear,
                RunTimeMinutes = title.RunTimeMinutes,
                Poster = title.Poster,
                Awards = title.Awards,
                Plot = title.Plot
            };
        }

    }
}
