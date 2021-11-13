using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Rawdata_Porfolio_2.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webservice.Controllers
{
    public class BookmarkViewController : Controller
    { /*
        [ApiController]
        [Route("api/user/bookmarks")] //??? dont remember
        public class PersonalityViewController : Controller
        {
            IDataService _dataService;
            LinkGenerator _linkGenerator;

            public BookmarkViewController(IDataService dataService, LinkGenerator linkGenerator)
            {
                _dataService = dataService;
                _linkGenerator = linkGenerator;
            }
            
                        [HttpGet("{id}", Name = nameof(GetUser))]
                        public IActionResult GetBookmarks()
                        {
                            var bookmark = _dataService.GetBookmarks(id);

                            if (bookmark == null)
                            {
                                return NotFound();
                            }

                            return Ok(GetBookmarkViewModel(bookmarks));
                        }


                        private BookmarkViewModel GetPersonalityViewModel(Bookmarks personality)
                        {
                            return new PersonalityViewModel
                            {
                                Url = (_linkGenerator.GetUriByName(HttpContext, nameof(GetPersonality), new { personality.Id })).Replace("%20", ""),
                                Name = personality.Name,
                                Year_Birth = personality.Year_Birth,
                                Year_Death = personality.Year_Death,
                                // Profession = personality.Profession,
                            };
                        }
                    }
                }
            
        }*/
    }
}