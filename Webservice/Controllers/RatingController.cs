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

        [HttpPost("rate")]
        public IActionResult UpdateTitleRating(RatingViewModel model)
        {
            _dataService.UpdateRating(model.User_Id, model.Title_Id, model.RatingOfTitle);
            return CreatedAtRoute(null, new {model.Title_Id});
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
