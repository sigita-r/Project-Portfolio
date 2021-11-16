using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.IO;
using Rawdata_Porfolio_2.Pages.Entity_Framework;
using System.Reflection;
using System.Text;

namespace Rawdata_Porfolio_2.Entity_Framework
{
    public interface IDataService
    {

        ////////////////////////////////////////////////////////////
        //                        TITLES                          //
        ////////////////////////////////////////////////////////////

        IEnumerable<Title> GetTitles();

        Title GetTitleById(int Id);

        List<Character> GetKnownCharactersFromPersonalityById(int personality_Id);

         public List<Character> GetCharactersFromTitleById(int title_Id);

        public List<Episode> GetEpisode(int titleID);
        public List<Episode> GetAllEpisodes(int titleID);
        public List<Title_Genre> GetTitleGenre(int title_Id);

        public List<Title_Localization> GetTitleLocalization(int title_id);


        ////////////////////////////////////////////////////////////
        //                      PERSONALITY                       //
        ////////////////////////////////////////////////////////////

        Personality GetPersonalityById(int personality_Id);

        public List<Personality_Profession> GetPersonalityProfession(int personality_Id);

        List<Character> GetCharactersFromPersonalityById(int personality_Id);
       


        ////////////////////////////////////////////////////////////
        //                       BOOKMARKS                        //
        ////////////////////////////////////////////////////////////

        public void CreatePersonalityBM(int userID, int personalityID, string note);

        public List<Bookmarks_Personality> GetPersonalityBMsByUserID(int userID);

        public void DeletePersonalityBM(int userID, int personalityID);

        public void UpdatePersonalityBM(int userID, int personalityID, string note);

        public void CreateTitleBM(int userID, int titleID, string note);

        public List<Bookmarks_Title> GetTitleBMsByUserID(int userID);

        public void DeleteTitleBM(int userID, int titleID);

        public void UpdateTitleBM(int userID, int titleID, string note);


        ////////////////////////////////////////////////////////////
        //                          User                          //
        ////////////////////////////////////////////////////////////

        public void CreateUser(string username, byte [] password, string email, DateTime dob);
        User GetUser(int userID);
        public void DeleteUser(int userID);
       //Waiting with this one till i get how to do bytea, since users should be able to change passwords.
       public void UpdateUser(int userID, string email, string username, Byte[] password, DateTime dob);

        ////////////////////////////////////////////////////////////
        //                         RATINGS                        //
        ////////////////////////////////////////////////////////////

        public List<Title> GetAvgRatingFromTitleId(int title_ID);
        public void CreateRating(int user_ID, int title_ID, Int16 rating);
        List<Rating> GetRating(int userID);
        public void UpdateRating(int user_ID, int title_ID, Int16 rating);
        public void DeleteRating(int user_ID, int title_ID);

        ////////////////////////////////////////////////////////////
        //                          SEARCH                        //
        ////////////////////////////////////////////////////////////

        List<Personality> ActorSearch(int user_Id, string query); 
        List<Search_Queries> GetSQ(int userID);
        public void DeleteSQ(int queryID);



        ////////////////////////////////////////////////////////////
        //                          OTHER                         //
        ////////////////////////////////////////////////////////////


        List<Role> GetRole(int titleID, int personalityID);

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
            
            using (var cmd = new NpgsqlCommand("SELECT DISTINCT personality.\"ID\", personality.\"name\", " +
                "\"character\" FROM public.title_localization, public.characters left join personality on characters.\"personality_ID\" = personality.\"ID\" " +
                "WHERE characters.\"title_ID\" = @TID AND title_localization.primary_title = true ", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("TID", title_Id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Character> result = new List<Character>();
                while (reader.Read())
                {
                    Character row = new Character()
                    {
                        CharacterOfPersonality = reader["character"].ToString(),
                        Name = reader["name"].ToString(),
                        Personality_Id = (int)reader["ID"],

                    };
                    result.Add(row);
                }
                connection.Connect().Close();
                return result;
            }
        }

        public List<Character> GetKnownCharactersFromPersonalityById(int title_Id)
        {

            using (var cmd = new NpgsqlCommand("SELECT DISTINCT personality.\"ID\", personality.\"name\", " +
                "\"character\" FROM public.title_localization, public.characters left join personality on characters.\"personality_ID\" = personality.\"ID\" " +
                "WHERE characters.\"title_ID\" = @TID AND title_localization.primary_title = true AND known_for = true ", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("TID", title_Id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Character> result = new List<Character>();
                while (reader.Read())
                {
                    Character row = new Character()
                    {
                        CharacterOfPersonality = reader["character"].ToString(),
                        Name = reader["name"].ToString(),
                        Personality_Id = (int)reader["ID"],

                    };
                    result.Add(row);
                }
                connection.Connect().Close();
                return result;
            }
        }

     
       public List<Episode> GetEpisode(int titleID)
       {
           using (var cmd = new NpgsqlCommand("SELECT title_localization.name, episode.ep_number, episode.season FROM public.title_localization, public.episode WHERE episode.\"ID\" = @TID AND title_localization.\"title_ID\" = @TID AND title_localization.primary_title = true", connection.Connect()))
           {
                cmd.Parameters.AddWithValue("TID", titleID);
               NpgsqlDataReader reader = cmd.ExecuteReader();
               List<Episode> result = new List<Episode>();
               while (reader.Read())
               {
                    Episode row = new Episode()
                    {
                        Name = reader["name"].ToString(),
                        Ep_Number = (int)reader["ep_number"],
                        Season = (int)reader["season"],
                   };
                   result.Add(row);
               }
               return result;
           }
       }

        public List<Episode> GetAllEpisodes(int titleID)
        {
            using (var cmd = new NpgsqlCommand("SELECT title_localization.name, episode.\"ID\", episode.ep_number, episode.season FROM public.title_localization, public.episode WHERE episode.\"parent_ID\" = @TID AND title_localization.\"title_ID\" = episode.\"ID\" AND title_localization.primary_title = true", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("TID", titleID);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Episode> result = new List<Episode>();
                while (reader.Read())
                {
                    Episode row = new Episode()
                    {
                        Name = reader["name"].ToString(),
                        Ep_Number = (int)reader["ep_number"],
                        Season = (int)reader["season"],
                        Id = (int)reader["ID"],
                    };
                    result.Add(row);
                }
                return result;
            }
        }

        public List<Title_Genre> GetTitleGenre(int title_id)
        {
            using (var cmd = new NpgsqlCommand("Select * From public.title_genres where \"title_ID\" = @TID;", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("TID", title_id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Title_Genre> result = new List<Title_Genre>();
                while (reader.Read())
                {
                    Title_Genre row = new Title_Genre()
                    {
                        Genre = reader["genre"].ToString(),
                    };
                    result.Add(row);
                }
                connection.Connect().Close();
                return result;
            }
         
        }
         

        public List<Title_Localization> GetTitleLocalization(int title_id)
        {
            using (var cmd = new NpgsqlCommand("SELECT * FROM title_localization WHERE @TID = \"title_ID\"", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("TID", title_id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Title_Localization> result = new List<Title_Localization>();
                while (reader.Read())
                {
                    Title_Localization row = new Title_Localization()
                    {
                        Id = (int)reader["ID"],
                        Name = reader["ID"].ToString(),
                        Language = reader["langauge"].ToString(),
                        Region = reader["region"].ToString(),
                        Type = reader["type"].ToString(),
                        Attribute = reader["attribute"].ToString(),
                        PrimaryTitle = (bool)reader["primary_title"],
                    };
                    result.Add(row);
                }
                connection.Connect().Close();
                return result;
                
            }
           
        }
        
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
                connection.Connect().Close();
                return result;
            }
     
        }

        public List<Personality_Profession> GetPersonalityProfession(int personality_Id) 
        {
            using (var cmd = new NpgsqlCommand("SELECT profession FROM public.personality_professions WHERE \"personality_ID\" = @PID", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("PID", personality_Id);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                List<Personality_Profession> result = new List<Personality_Profession>();
                while (reader.Read())
                {
                    Personality_Profession row = new Personality_Profession()
                    {
                        Profession = reader["profession"].ToString(),
                    };
                    result.Add(row);
                }
                connection.Connect().Close();   
                return result;
            }
        }



        ////////////////////////////////////////////////////////////
        //                       BOOKMARKS                        //
        ////////////////////////////////////////////////////////////

        public void CreatePersonalityBM(int userID, int personalityID, string note)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('n', 'p', @ID, @PID, @note)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("PID", personalityID);
                cmd.Parameters.AddWithValue("note", note);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
        }

        public List<Bookmarks_Personality> GetPersonalityBMsByUserID(int userID)
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

        public void DeletePersonalityBM(int UserId, int PersonalityId)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('d','p', @ID, @PID)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", UserId);
                cmd.Parameters.AddWithValue("PID", PersonalityId);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
        }

        public void UpdatePersonalityBM(int UserId, int PersonalityId, string note)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('u','p', @ID, @PID, @NOTE)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", UserId);
                cmd.Parameters.AddWithValue("PID", PersonalityId);
                cmd.Parameters.AddWithValue("NOTE", note);

                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
        }

        public void CreateTitleBM(int userID, int titleID, string note)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('n', 't', @ID, @PID, @note)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("PID", titleID);
                cmd.Parameters.AddWithValue("note", note);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
        }

        public List<Bookmarks_Title> GetTitleBMsByUserID(int userID)
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
            connection.Connect().Close();
            return result;
        }

        public void DeleteTitleBM(int userID, int titleID)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('d','t', @ID, @PID)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("PID", titleID);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();

        }

        public void UpdateTitleBM(int userID, int titleID, string note)
        {
            using (var cmd = new NpgsqlCommand("call update_bookmark('u','t', @ID, @TID, @NOTE)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("TID", titleID);
                cmd.Parameters.AddWithValue("NOTE", note);

                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
        }

        ////////////////////////////////////////////////////////////
        //                          User                          //
        ////////////////////////////////////////////////////////////
 
        public void CreateUser(string username, byte [] password, string email, DateTime dob)
        {


            var user = new User();
            user.Id = ctx.Users.Max(x => x.Id)+1;   // Since the ID column is a serial type (meaning that the value is auto-incremented on each new entry), do we even need this line?
            user.Username = username;
            user.Password = password;
            user.Email = email;
            user.DateOfBirth = dob;
            ctx.Add(user);
            ctx.SaveChanges();
            
            
        }

        public User GetUser(int userId)
        {
            return ctx.Users.Find(userId);
        }

        public void UpdateUser(int userID, string email, string username, Byte[] password, DateTime dob)
        {

            var user = ctx.Users.First(x => x.Id == userID);
            user.Username = username;
            user.Email = email;
            user.Password = password;
            user.DateOfBirth = dob;
            ctx.SaveChanges();



            /*
            using var cmd = new NpgsqlCommand("call update_user('u', @ID, @USERNAME, @PASS, @EMAIL, @DOB)", connection.Connect());
            cmd.Parameters.AddWithValue("ID", userID);
            cmd.Parameters.AddWithValue("USERNAME", username);
            cmd.Parameters.AddWithValue("PASS", password);
            cmd.Parameters.AddWithValue("EMAIL", email);
            cmd.Parameters.AddWithValue("DOB", dob);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            */
        }
        public void DeleteUser(int userId)
        {
            using (var cmd = new NpgsqlCommand("call update_user('d', @ID)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userId);
                NpgsqlDataReader reader = cmd.ExecuteReader();

            }
            connection.Connect().Close();
        }
        ////////////////////////////////////////////////////////////
        //                         RATINGS                        //
        ////////////////////////////////////////////////////////////

        public void CreateRating(int user_ID, int title_ID, Int16 rating)
        {
            using (var cmd = new NpgsqlCommand("call update_rating(@UID, @TID, @RATING, @DEL)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("UID", user_ID);
                cmd.Parameters.AddWithValue("TID", title_ID);
                cmd.Parameters.AddWithValue("RATING", rating);
                cmd.Parameters.AddWithValue("DEL", false);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();


        }
        public List<Rating> GetRating(int userID)
        {
            var cmd = new NpgsqlCommand("select rating from ratings where \"user_ID\" @UID", connection.Connect());
            cmd.Parameters.AddWithValue("UID", userID);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Rating> result = new List<Rating>();
            while (reader.Read())
            {
                Rating row = new Rating()
                {
                    Title_Id = (int)reader["title_ID"],
                    RatingOfTitle= (int)reader["rating"],
                    Timestamp = (DateTime)reader["timestamp"],

                };
                result.Add(row);
            }
            connection.Connect().Close();
            return result;
        }

        public void UpdateRating(int user_ID, int title_ID, Int16 rating)
        {
            using (var cmd = new NpgsqlCommand("call update_rating(@UID, @TID, @RATING, @DEL)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("UID", user_ID);
                cmd.Parameters.AddWithValue("TID", title_ID);
                cmd.Parameters.AddWithValue("RATING", rating);
                cmd.Parameters.AddWithValue("DEL", false);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
            
        }
        public void DeleteRating(int user_ID, int title_ID)
        {
            using (var cmd = new NpgsqlCommand("call update_rating(@UID, @TID, @RATING, @DEL)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("UID", user_ID);
                cmd.Parameters.AddWithValue("TID", title_ID);
                cmd.Parameters.AddWithValue("RATING", Int16.MinValue);
                cmd.Parameters.AddWithValue("DEL", true);
                NpgsqlDataReader reader = cmd.ExecuteReader();
            }
            connection.Connect().Close();
        }

        public List<Title> GetAvgRatingFromTitleId(int title_ID)
        {
            var cmd = new NpgsqlCommand("select avg_rating from title where \"title_ID\" = @TID", connection.Connect());
            cmd.Parameters.AddWithValue("TID", title_ID);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Title> result = new List<Title>();
            while (reader.Read())
            {
                Title row = new Title()
                {
                    Id = (int)reader["title_ID"],
                    AvgRating = (int)reader["avg_rating"],
                 

                };
                result.Add(row);
            }
            connection.Connect().Close();
            return result;
        }
        ////////////////////////////////////////////////////////////
        //                          SEARCH                        //
        ////////////////////////////////////////////////////////////
        public List<Search_Queries> GetSQ(int userID)
        {
            var cmd = new NpgsqlCommand("select * from search_queries where \"user_ID\" = @UID ORDER BY timestamp DESC;", connection.Connect());
            cmd.Parameters.AddWithValue("UID", userID);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Search_Queries> result = new List<Search_Queries>();
            while (reader.Read())
            {
                Search_Queries row = new Search_Queries()
                {
                    Query = reader["query"].ToString(), // we have to do some seperating the string up some time, should we do it now?
                    Timestamp = (DateTime)reader["timestamp"],

                };
                result.Add(row);
            }
            connection.Connect().Close();
            return result;
        }


        // this dont seem to make sense - from sigita and mads, where is the userid, we need a userid to know from who the
        // search should be deleted, which it doesnt take
        public void DeleteSQ(int queryID)
        {
            using (var cmd = new NpgsqlCommand("call update_search_queries(@UID, @QID, @QUERY, @DEL)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("UID", int.MinValue);
                cmd.Parameters.AddWithValue("QID", queryID);
                cmd.Parameters.AddWithValue("QUERY", "");
                cmd.Parameters.AddWithValue("DEL", true);
                NpgsqlDataReader reader = cmd.ExecuteReader();

            }
            connection.Connect().Close();
        }

        public List<Personality> ActorSearch(int user_Id, string query)
        {
            var cmd = new NpgsqlCommand("select * from actor_search(@UID, @QUERY);", connection.Connect());
            cmd.Parameters.AddWithValue("UID", user_Id);
            cmd.Parameters.AddWithValue("QUERY", query);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Personality> result = new List<Personality>();
            while (reader.Read())
            {
                Personality row = new Personality()
                {
                    Id = (int)reader["ID"],
                    Name = reader["name"].ToString(),
                    Year_Birth = (int)reader["year_birth"],
                    Year_Death = (int)reader["year_death"],
                };
                result.Add(row);
            }
            connection.Connect().Close();
            return result;
        }


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

           public List<Role> GetRole(int titleID, int personalityID)
        {
            var cmd = new NpgsqlCommand("select role from roles where \"title_ID\" = @TID AND \"personality_ID\" = @PID", connection.Connect());
            cmd.Parameters.AddWithValue("TID", titleID);
            cmd.Parameters.AddWithValue("PID", personalityID);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<Role> result = new List<Role>();
            while (reader.Read())
            {
                Role row = new Role()
                {
                    RoleOfPersonality = reader["role"].ToString(),
                };
                result.Add(row);
            }
            connection.Connect().Close();
            return result;
        }

        ////////////////////////////////////////////////////////////
    }
}