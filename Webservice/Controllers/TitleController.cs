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

        [HttpGet("{id}", Name = nameof(GetTitleById))]
        public IActionResult GetTitleById(int id)
        {
            var title = _dataService.GetTitleById(id);

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



        private object CreateResultModel(QueryString queryString, int total, IEnumerable<TitleViewModel> model)
        {
            return new
            {
                total,
                prev = CreateNextPageLink(queryString),
                cur = CreateCurrentPageLink(queryString),
                next = CreateNextPageLink(queryString, total),
                items = model
            };
        }

        private string CreateNextPageLink(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetTitlesUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy);
        }


        private string CreateCurrentPageLink(QueryString queryString)
        {
            return GetTitlesUrl(queryString.Page, queryString.PageSize, queryString.OrderBy);
        }

        private string CreateNextPageLink(QueryString queryString)
        {
            return queryString.Page <= 0 ? null : GetTitlesUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy);
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private string GetTitlesUrl(int page, int pageSize, string orderBy)
        {
            return _linkGenerator.GetUriByName(
                HttpContext,
                nameof(GetTitles),
                new { page, pageSize, orderBy });
        }

        private TitleViewModel GetTitleViewModel(Title title)
        {
            return new TitleViewModel
            {
                Url = _linkGenerator.GetUriByName(HttpContext, nameof(GetTitleById), new { title.Id }).Replace("%20", ""),
                Type = title.Type,
              //  Genre = title.Genre,
              //  Primary_Title = title.Primary_Title,
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
