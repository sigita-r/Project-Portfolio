using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Rawdata_Porfolio_2.Entity_Framework
{
    public interface IDataService
    {
        // This is 1 too many interfaces, this is just extra that was inserted by mistake we think.
        // We didnt have access to any of the methods
       // interface IDataService
     //   {

            IEnumerable<Title> GetTitles();
            /*
            Bookmarks_Personality CreatePersonalityBM(int userID, int personalityID, string note);
            Bookmarks_Personality ReadPersonalityBM(int userID);
            */

            public bool DeletePersonalityBM(int userID);
            public bool UpdatePersonalityBM(int userID, string note, DateTime timestamp);

            /*
            Bookmarks_Title CreateTitleBM(int userID, int personalityID, string note);
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

            */

            // Should also be renamed to getTitle(int id)
            Title ReadTitles(int Id);

            /*
            Title_Genre ReadTG();

            Title_Localization ReadTL();

            User CreateUser();
            User ReadUser();
            User UpdateUser();

            Wi ReadWi();
            */
        }
        public class DataService : IDataService
        {
            // making our context so we can add to it all the time
            // instead of createing a new one in each method, which is kinda sus
            OurMDB_Context ctx = new OurMDB_Context();

            Bookmarks_Personality CreatePersonalityBM(int userID, int personalityID, string note)
            {

                var ctx = new OurMDB_Context();
                var c = new Bookmarks_Personality();

                c.User_Id = userID; //use this one for authentification
                c.Personality_Id = personalityID;
                c.Note = note;
                c.Timestamp = DateTime.Now;
                ctx.Add(c);
                ctx.SaveChanges();
                return c;
            }
            Bookmarks_Personality ReadPersonalityBM(int UserId)
            {
                var ctx = new OurMDB_Context();
                return ctx.Bookmark_Personalities.Find(UserId);

            }
            public bool DeletePersonalityBM(int UserId)
            {
                var ctx = new OurMDB_Context();
                var bookmark = ctx.Bookmark_Personalities.Find(UserId);

                if (bookmark == null)

                {
                    return false;
                }
                else
                {
                    ctx.Remove(bookmark);
                    ctx.SaveChanges();
                    return true;
                }

            }
            public bool UpdatePersonalityBM(int UserId, string note, DateTime timestamp)
            {
                var ctx = new OurMDB_Context();
                var bookmark = ctx.Bookmark_Personalities.Find(UserId);

                if (bookmark == null)
                {
                    return false;
                }
                else
                {
                    bookmark.Note = note;
                    bookmark.Timestamp = DateTime.Now;
                    return true;
                }
            }

            /*
        Bookmarks_Title CreateTitleBM(int userID, int personalityID, string note) 
        {
            var ctx = new OurMDB_Context();
            var bookmark = new Bookmarks_Title();
            bookmark.User_Id = userID; //use for authentication            
        }
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

            */

            // should be renames to gettitle(int id) and then just return what it returns
            // Sigita and I think that we shouldnt create a new ctx each time
            public Title ReadTitles(int Id)
            {

                var ctx = new OurMDB_Context();
                return ctx.Titles.Find(Id);
            }

            // getting all the titles from context and putting them
            // into a list
            public IEnumerable<Title> GetTitles()
            {
                return ctx.Titles.ToList();
            }

        }
    }
