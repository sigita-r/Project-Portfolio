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
    [Route("api/characters")]
    public class CharacterController : Controller
    {
        IDataService _dataService;
        LinkGenerator _linkGenerator;
        public CharacterController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("Characters")]
        public IActionResult GetCharactersFromTitle(int id)
        {
             Character character = _dataService.GetCharactersFromTitleById(id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(GetCharacterViewModel(character)); 
        }



      /*  [HttpGet("KnownCharacters")]
        public IActionResult GetKnownCharactersFromTitle(int id)
        {
            Character character = _dataService.GetKnownCharactersFromTitleById(id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(GetCharacterViewModel(character));
        }
      */

        private CharacterViewModel GetCharacterViewModel(Character character)
        {

            return new CharacterViewModel
            {
                Url = _linkGenerator.GetUriByName(HttpContext, nameof(GetKnownCharactersFromTitle), new { character.Id }).Replace("%20", ""),
                Name = character.Name,
                Personality_Id = character.Personality_Id,
                Title_Id = character.Title_Id,
                Id = character.Id,
                CharacterOfPersonality = character.CharacterOfPersonality,
                Known_For = character.Known_For,

            };
        }
    }
}
