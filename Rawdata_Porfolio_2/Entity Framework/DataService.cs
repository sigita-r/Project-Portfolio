using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
namespace Rawdata_Porfolio_2.Entity_Framework
{
    interface IDataService
    {
        Bookmarks_Personality CreatePersonalityBM(int userID, int personalityID);
        Bookmarks_Personality ReadPersonalityBM();
        Bookmarks_Personality DeletePersonalityBM();
        Bookmarks_Personality UpdatePersonalityBM();

        Bookmarks_Title CreateTitleBM();
        Bookmarks_Title ReadTitleBM();
        Bookmarks_Title DeleteTitleBM();
        Bookmarks_Title UpdateTitleBM();

        Character ReadCharacter();
       
        Episode ReadEpisode();

        Personality ReadPersonality();

        Personality_Profession ReadPersonalityProfession();

        Rating CreateRating();
        Rating ReadRating();
        Rating UpdateRating();
        Rating DeleteRating();

        Role ReadRole();

        Search_Queries CreateSQ();
        Search_Queries ReadSQ();
        Search_Queries DeleteSQ();

        Title ReadTitles(int Id);

        Title_Genre ReadTG();

        Title_Localization ReadTL();

        User CreateUser();
        User ReadUser();
        User UpdateUser();

        Wi ReadWi();

    }
    public class DataService : IDataService 
    {
        Bookmarks_Personality CreatePersonalityBM(int userID, int personalityID) 
        {
            //tag personligheds id og brugerens id og indsæt en række med informationerne.
            var ctx = new OurMDB_Context();
            var updatePersonalityBM = ctx.

             
        }
        Bookmarks_Personality ReadPersonalityBM() { }
        Bookmarks_Personality DeletePersonalityBM() { }
        Bookmarks_Personality UpdatePersonalityBM() { }

        Bookmarks_Title CreateTitleBM() { }
        Bookmarks_Title ReadTitleBM() { }
        Bookmarks_Title DeleteTitleBM() { }
        Bookmarks_Title UpdateTitleBM() { }

        Character ReadCharacter() { }

        Episode ReadEpisode() { }

        Personality ReadPersonality() { }

        Personality_Profession ReadPersonalityProfession() { }

        Rating CreateRating() { }
        Rating ReadRating() { }
        Rating UpdateRating() { }
        Rating DeleteRating() { }

        Role ReadRole() { }

        Search_Queries CreateSQ() { }
        Search_Queries ReadSQ() { }
        Search_Queries DeleteSQ() { }
        public Title ReadTitles (int Id)
        {
     
            var ctx = new OurMDB_Context();
            return ctx.Titles.Find(Id);
        }
        
    }
}
*/