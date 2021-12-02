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
        private int number;

        private IDataService _dataService;
        private LinkGenerator _linkGenerator;

        public CharacterController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

          [HttpGet("{id}")]
          public IActionResult GetCharactersFromTitle(int id)
          {
            
              List<Character> character = _dataService.GetCharactersFromTitleById(id);

              if (character == null)
              {
                  return NotFound();
              }

              return Ok(character.Select(x => GetCharacterViewModel(x)));
          }

         [HttpGet("KnownCharacters")]
          public IActionResult GetKnownCharactersFromTitle(int id)
          {
              List<Character> character = _dataService.GetKnownCharactersFromTitleById(id);

              if (character == null)
              {
                  return NotFound();
              }

              return Ok(character.Select(x => GetCharacterViewModel(x)));;
          }
        

        private CharacterViewModel GetCharacterViewModel(Character character)
        {
            return new CharacterViewModel
            {
                // Url = _linkGenerator.GetUriByName(HttpContext, nameof(GetCharactersFromTitle), new { x.Personality_Id }).Replace("%20", ""),
                Title_Id = character.Title_Id,
                Name = character.Name,
                Personality_Id = character.Personality_Id,
                CharacterOfPersonality = character.CharacterOfPersonality
            };
        }

        private CharacterViewModel GetKnownCharacterViewModel(Character character) 
        {
            return new CharacterViewModel
            {
                Title_Id = character.Title_Id,
                Name = character.Name,
                Personality_Id = character.Personality_Id,
                CharacterOfPersonality = character.CharacterOfPersonality,
                Known_For = character.Known_For
            };
        }
    }
}