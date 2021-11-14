using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.IO;
using Rawdata_Porfolio_2.Pages.Entity_Framework;
using System.Reflection;

namespace Rawdata_Porfolio_2.Entity_Framework
{
    public interface IDataService
    {

        ////////////////////////////////////////////////////////////
        //                        TITLES                          //
        ////////////////////////////////////////////////////////////

        IEnumerable<Title> GetTitles();

        Title GetTitleById(int Id);

        // public List<Character> GetCharactersFromTitleById(int title_Id);

        // public List<Episode> GetEpisode(int titleID);

        //Title_Genre ReadTG();

        //Title_Localization ReadTL();


        ////////////////////////////////////////////////////////////
        //                      PERSONALITY                       //
        ////////////////////////////////////////////////////////////

          Personality GetPersonalityById(int personality_Id);

        //  Personality_Profession GetPersonalityProfession();

         List<Character> GetCharactersFromPersonalityById(int personality_Id);


        ////////////////////////////////////////////////////////////
        //                       BOOKMARKS                        //
        ////////////////////////////////////////////////////////////

        public bool CreatePersonalityBM(int userID, int personalityID, string note);

        public List<Bookmarks_Personality> GetPersonalityBMByUserID(int userID);

        public bool DeletePersonalityBM(int userID, int personalityID);

        public bool UpdatePersonalityBM(int userID, int personalityID, string note);

        public bool CreateTitleBM(int userID, int titleID, string note);

        public List<Bookmarks_Title> GetTitleBMByUserID(int userID);

        public bool DeleteTitleBM(int userID, int titleID);

        public bool UpdateTitleBM(int userID, int titleID, string note);


        ////////////////////////////////////////////////////////////
        //                          User                          //
        ////////////////////////////////////////////////////////////

        //User CreateUser();
        //User GetUser();
        //User UpdateUser();

        ////////////////////////////////////////////////////////////
        //                         RATINGS                        //
        ////////////////////////////////////////////////////////////

        //Rating CreateRating();
        //Rating GetRating();
        //Rating UpdateRating();
        //Rating DeleteRating();

        ////////////////////////////////////////////////////////////
        //                          SEARCH                        //
        ////////////////////////////////////////////////////////////

        //Search_Queries CreateSQ();
        //Search_Queries GetSQ();
        //Search_Queries DeleteSQ();


        ////////////////////////////////////////////////////////////
        //                          OTHER                         //
        ////////////////////////////////////////////////////////////

        //  Role GetRole();

       // Wi GettWi();

        ////////////////////////////////////////////////////////////

    }
    public class DataService : IDataService
    {

        // making our context so we can add to it all the time
        // instead of createing a new one in each method, which is kinda sus
        public OurMDB_Context ctx = new OurMDB_Context();
        public ConnString connection = new ConnString();

        public class ConnString
        {
            public NpgsqlConnection Connect()
            {
                string connStringFromFile;
                using (StreamReader readtext = new StreamReader("C:/Login/Login.txt"))
                {
                    connStringFromFile = readtext.ReadLine();
                }
                var connection = new NpgsqlConnection(connStringFromFile);
                connection.Open();
                return connection;
            }
        }

        ////////////////////////////////////////////////////////////
        //                        TITLES                          //
        ////////////////////////////////////////////////////////////

        public Title GetTitleById(int Id)
        {
            return ctx.Titles.Find(Id);
        }

        public IEnumerable<Title> GetTitles()
        {
            return ctx.Titles.ToList();
        }

        public List<Character> GetCharactersFromTitleById(int title_Id)
        {
            //Get characters and Personalities from Title_ID
            using (var cmd = new NpgsqlCommand("SELECT character FROM public.characters WHERE \"title_ID\" = @TID", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("PID", title_Id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Character> result = new List<Character>();
                while (reader.Read())
                {
                    Character row = new Character()
                    {
                        CharacterOfPersonality = reader["character"].ToString(),
                    };
                    result.Add(row);
                }
                return result;
            }
        }

        /*
       public List<Episode> ReadEpisode(int titleID)
       {
           using (var cmd = new NpgsqlCommand("SELECT name, ep_number, season FROM public.title, public.title_localization, public.episode WHERE title.type = 'tvEpisode' AND title.\"ID\" = @TID AND title.\"ID\" = title_localization.\"title_ID\" AND title.\"ID\" = episode.\"title_ID\" AND primary_title = true", connection.Connect()))
           {

               cmd.Parameters.AddWithValue("TID", titleID);


               NpgsqlDataReader reader = cmd.ExecuteReader();
               List<Episode> result = new List<Episode>();
               while (reader.Read())
               {
                   Episode row = new Episode()
                   {
                       Ep_Number = (int)reader["ep_number"],
                       Season = (int)reader["season"],


                   };
                   result.Add(row);

               }
               return result;
           }
       }
       */



        ////////////////////////////////////////////////////////////
        //                      PERSONALITY                       //
        ////////////////////////////////////////////////////////////

       public Personality GetPersonalityById(int personality_Id)
        {
            return ctx.Personalities.Find(personality_Id);
        }

        public List<Character> GetCharactersFromPersonalityById(int personality_Id)
        {
            using (var cmd = new NpgsqlCommand("SELECT * FROM public.characters WHERE \"personality_ID\" = @PID", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("PID", personality_Id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Character> result = new List<Character>();
                while (reader.Read())
                {
                    Character row = new Character()
                    {
                        CharacterOfPersonality = reader["character"].ToString(),
                    };
                    result.Add(row);
                }
                return result;
            }
        }

      //  Personality_Profession ReadPersonalityProfession() { }



        ////////////////////////////////////////////////////////////
        //                       BOOKMARKS                        //
        ////////////////////////////////////////////////////////////

        public bool CreatePersonalityBM(int userID, int personalityID, string note)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('n', 'p', @ID, @PID, @note)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("PID", personalityID);
                cmd.Parameters.AddWithValue("note", note);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
            return true;
        }

        public List<Bookmarks_Personality> GetPersonalityBMByUserID(int userID)
        {
            var cmd = new NpgsqlCommand("select * FROM select_user_bookmarks('p', @ID)", connection.Connect());

            cmd.Parameters.AddWithValue("ID", userID);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Bookmarks_Personality> result = new List<Bookmarks_Personality>();
            while (reader.Read())
            {
                Bookmarks_Personality row = new Bookmarks_Personality()
                {
                    Name = reader["name"].ToString(),
                    Note = reader["note"].ToString(),
                    Timestamp = (DateTime)reader["timestamp"]
                };
                result.Add(row);
            }
            connection.Connect().Close();
            return result;
        }

        public bool DeletePersonalityBM(int UserId, int PersonalityId)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('d','p', @ID, @PID)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", UserId);
                cmd.Parameters.AddWithValue("PID", PersonalityId);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            return true;
        }

        public bool UpdatePersonalityBM(int UserId, int PersonalityId, string note)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('u','p', @ID, @PID, @NOTE)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", UserId);
                cmd.Parameters.AddWithValue("PID", PersonalityId);
                cmd.Parameters.AddWithValue("NOTE", note);

                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            return true;
        }

        public bool CreateTitleBM(int userID, int titleID, string note)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('n', 't', @ID, @PID, @note)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("PID", titleID);
                cmd.Parameters.AddWithValue("note", note);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
            return true;
        }

        public List<Bookmarks_Title> GetTitleBMByUserID(int userID)
        {
            var cmd = new NpgsqlCommand("select * FROM select_user_bookmarks('t', @ID)", connection.Connect());
            cmd.Parameters.AddWithValue("ID", userID);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Bookmarks_Title> result = new List<Bookmarks_Title>();
            while (reader.Read())
            {
                Bookmarks_Title row = new Bookmarks_Title()
                {
                    Name = reader["name"].ToString(),
                    Note = reader["note"].ToString(),
                    Timestamp = (DateTime)reader["timestamp"]
                };
                result.Add(row);
            }
            return result;
        }

        public bool DeleteTitleBM(int userID, int titleID)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('d','t', @ID, @PID)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("PID", titleID);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            return true;
        }

        public bool UpdateTitleBM(int userID, int titleID, string note)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('u','t', @ID, @PID, @NOTE)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("PID", titleID);
                cmd.Parameters.AddWithValue("NOTE", note);

                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            return true;
        }


        ////////////////////////////////////////////////////////////
        //                          User                          //
        ////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////////////////
        //                         RATINGS                        //
        ////////////////////////////////////////////////////////////

        //Rating CreateRating() { }
        //Rating ReadRating() { }
        //Rating UpdateRating() { }
        //Rating DeleteRating() { }

        ////////////////////////////////////////////////////////////
        //                          SEARCH                        //
        ////////////////////////////////////////////////////////////

        //Search_Queries CreateSQ() { }
        //Search_Queries ReadSQ() { }
        //Search_Queries DeleteSQ() { }

        ////////////////////////////////////////////////////////////
        //                          OTHER                         //
        ////////////////////////////////////////////////////////////

        /*
        Personality ReadPersonality(int userID) 
        {
            using (var cmd = new NpgsqlCommand("Select username, password, email, dob, created FROM user WHERE \"ID\" = @ID"))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Personality> personalities = new List<Personality>();
                while (reader.Read())
                {
                    Personality Row = new Personality()
                    {
                        Username = reader.GetString["username"],
                        passwor
                    }
                }
            }   
        }
        */

        //   Role ReadRole() { }

        ////////////////////////////////////////////////////////////
    }
}