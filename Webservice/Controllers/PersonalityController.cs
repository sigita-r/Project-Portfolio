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
    [Route("api/personalities")]
    public class PersonalityController : Controller
    {
        IDataService _dataService;
        LinkGenerator _linkGenerator;

        public PersonalityController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id}", Name = nameof(GetPersonalityByID))]
        public IActionResult GetPersonalityByID(int id)
        {
            var personality = _dataService.GetPersonalityById(id);
            if (personality == null)
            {
                return NotFound();
            }
            return Ok(GetPersonalityViewModel(personality));
        }

        /*
        [HttpGet("{id}", Name = nameof(GetCharactersFromPersonality))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetCharactersFromPersonality(int id)
        {
            var characters = _dataService.GetCharactersFromPersonalityById(id);
            if (characters == null)
            {
                return NotFound();
            }
            return Ok(characters);
        }
        */

        private PersonalityViewModel GetPersonalityViewModel(Personality personality)
        {
            return new PersonalityViewModel
            {
                Url = (_linkGenerator.GetUriByName(HttpContext, nameof(GetPersonalityByID), new { personality.Id })).Replace("%20", ""),
                Name = personality.Name,
                Year_Birth = personality.Year_Birth,
                Year_Death = personality.Year_Death,
               // Profession = personality.Profession,
            };
        }

    } 
}
