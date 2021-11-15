
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
    [Route("api/bookmarks")] //??? dont remember
    public class BookmarkController : Controller
    {
        IDataService _dataService;
        LinkGenerator _linkGenerator;

        public BookmarkController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        ////////////////////////////////////////////////////////////
        //                      TitleBookmarks                    //
        ////////////////////////////////////////////////////////////

        [HttpGet("user/{userID}", Name = nameof(GetBookmarkTitlesForUser))]
        [ApiExplorerSettings(IgnoreApi = true)]

        public IActionResult GetBookmarkTitlesForUser(int userID)
        {
            var titleBMs = _dataService.GetTitleBMsByUserID(userID);

            if (titleBMs.Count == 0)
            {
                return NotFound();
            }

            return Ok(titleBMs.Select(x => GetBookmarkTitleViewModel(x)));
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult CreateBookmarkTitle(int userID, int titleID, string note)
        {
            // checks
            if (_dataService.GetUser(userID) == null)
            {
                return NotFound("No user found");
            }

            if (_dataService.GetTitleById(titleID) == null)
            {
                return NotFound("No title Found");
            }

            //Bookmarks_Title bookmark = new Bookmarks_Title();

            //bookmark.User_Id = userID;
            //bookmark.Title_Id = titleID;
            //bookmark.Note = note;
            //    and then having dataservice do this:
            //                                          public void CreateBookmarkTitle(BookmarkTitle bookmarkTitle)
            //                                          {
            //                                          context.BookmarkTitles.Add(bookmarkTitle);
            //                                          }


            _dataService.CreateTitleBM(userID, titleID, note);


            //  ending needs change

            return null;
        }

        private BookmarkTitleViewModel GetBookmarkTitleViewModel(Bookmarks_Title bookmarkTitle)
        {
            return new BookmarkTitleViewModel
            {
                // Url = _linkGenerator.GetUriByName(HttpContext, nameof(GetBookmarkTitlesForUser), new { bookmarkTitle.Title_Id }),
                UserID = bookmarkTitle.User_Id,
                TitleName = bookmarkTitle.Name
            };
        }

        ////////////////////////////////////////////////////////////
        //                  PersonalityBookmarks                  //
        ////////////////////////////////////////////////////////////

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]

        public IActionResult CreateBookmarkPersonality(int userID, int personalityID, string note)
        {

            // checks
            if (_dataService.GetUser(userID) == null)
            {
                return NotFound("No user found");
            }

            if (_dataService.GetTitleById(personalityID) == null)
            {
                return NotFound("No personality Found");
            }

            Bookmarks_Personality bookmark = new Bookmarks_Personality();
            bookmark.User_Id = userID;
            bookmark.Personality_Id = personalityID;
            bookmark.Note = note;


            //    not sure how else to end it, this is how i would end it
            //    and then having dataservice do this:
            //                                          public void CreateBookmarkTitle(BookmarkTitle bookmarkTitle)
            //                                          {
            //                                          context.BookmarkTitles.Add(bookmarkTitle);
            //                                          }




            //   _dataService.CreatePersonalityBM(bookmark);


            //  ending needs change

            return null;
        }




        ////////////////////////////////////////////////////////////




        //[HttpGet("{id}", Name = nameof(GetUser))]
        //public IActionResult GetBookmarks()
        //{
        //    var bookmark = _dataService.GetBookmarks(id);

        //    if (bookmark == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(GetBookmarkViewModel(bookmarks));
        //}


        //private BookmarkViewModel GetPersonalityViewModel(Bookmarks personality)
        //{
        //    return new PersonalityViewModel
        //    {
        //        Url = (_linkGenerator.GetUriByName(HttpContext, nameof(GetPersonality), new { personality.Id })).Replace("%20", ""),
        //        Name = personality.Name,
        //        Year_Birth = personality.Year_Birth,
        //        Year_Death = personality.Year_Death,
        //        // Profession = personality.Profession,
        //    };
        //}

    }


        //}
}
