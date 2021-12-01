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
             List<Character> character = _dataService.GetCharactersFromTitleById(id);

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

        private List<CharacterViewModel> GetCharacterViewModel(List<Character> character)
        {

            List<CharacterViewModel> cvm = new List<CharacterViewModel>();

            cvm = (List<CharacterViewModel>)character.Select(x => new CharacterViewModel()
            {
                Url = _linkGenerator.GetUriByName(HttpContext, nameof(GetCharactersFromTitle), new { x.Personality_Id }).Replace("%20", ""),
                Name = x.Name,
                Personality_Id = x.Personality_Id,
                CharacterOfPersonality = x.CharacterOfPersonality
            });

            return cvm;            
        }
        
    }
}
