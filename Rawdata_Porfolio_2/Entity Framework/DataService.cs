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

        IEnumerable<Title> GetTitles();
        
        public bool CreatePersonalityBM(int userID, int personalityID, string note);
        public List<Bookmarks_Personality> GetPersonalityBM(int userID);
        

        public bool DeletePersonalityBM(int userID, int personalityID);
        public bool UpdatePersonalityBM(int userID, int personalityID, string note);

       
        public bool CreateTitleBM(int userID, int titleID, string note);
         public List<Bookmarks_Title> GetTitleBM(int userID);
         public bool DeleteTitleBM(int userID, int titleID);
         public bool UpdateTitleBM(int userID, int titleID, string note);

        public List<Character> GetCharacter(int personality_Id);
        /*
        public List<Episode> GetEpisode(int titleID);
        
         Personality GetPersonality();

         Personality_Profession GetPersonalityProfession();

         Rating CreateRating();
         Rating GetRating();
         Rating UpdateRating();
         Rating DeleteRating();

         Role GetRole();

         Search_Queries CreateSQ();
         Search_Queries GetSQ();
         Search_Queries DeleteSQ();

         */

        // Should also be renamed to getTitle(int id)
        Title GetTitles(int Id);

        /*
        Title_Genre ReadTG();

        Title_Localization ReadTL();

        User CreateUser();
        User GetUser();
        User UpdateUser();

        Wi GettWi();
        */
        
    }
    public class DataService : IDataService
    {
        // making our context so we can add to it all the time
        // instead of createing a new one in each method, which is kinda sus
        public OurMDB_Context ctx = new OurMDB_Context();
        public ConnString connection = new ConnString();


        public bool CreatePersonalityBM(int userID, int personalityID, string note)
        {
            
           
            using (var cmd = new NpgsqlCommand("call update_bookmark('n', 'p', @ID, @PID, @note)", connection.Connect()))
            {
                cmd.Parameters.AddWithValue("ID", userID);
                cmd.Parameters.AddWithValue("PID", personalityID);
                cmd.Parameters.AddWithValue("note", note);
                NpgsqlDataReader reader =  cmd.ExecuteReader();
                
            }
            
            connection.Connect().Close();
            return true;

         
        }
        public List<Bookmarks_Personality> GetPersonalityBM(int userID)
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

        public List<Bookmarks_Title> GetTitleBM(int userID)
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
        
        public List<Character> GetCharacter(int personality_Id) 
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
        /*
        public List<Episode> ReadEpisode(int titleID)
        {
            using (var cmd = new NpgsqlCommand("SELECT * FROM public.characters WHERE \"title_ID\" = @TID", connection.Connect()))
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
        public Title GetTitles(int Id)
        {
         
                return ctx.Titles.Find(Id);
        }

        // getting all the titles from context and putting them
        // into a list
        public IEnumerable<Title> GetTitles()
        {
            return ctx.Titles.ToList();
        }

    }

    public class ConnString
    {
        public NpgsqlConnection Connect(){

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
}