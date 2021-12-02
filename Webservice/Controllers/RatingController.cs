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
    [Route("api/ratings")]
    public class RatingController : Controller
    {
        private IDataService _dataService;
        private LinkGenerator _linkGenerator;
        
        public RatingController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id}")]
        public IActionResult GetRating(int id)
        {

            List<Rating> rating = _dataService.GetRating(id);

            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating.Select(x => GetRatingViewModel(x)));
        }
        private RatingViewModel GetRatingViewModel(Rating rating)
        {
            return new RatingViewModel
            {
                User_Id = rating.User_Id,
                Title_Id = rating.Title_Id,
                RatingOfTitle = rating.RatingOfTitle,
                Timestamp = rating.Timestamp
            };
        }

    }
}
