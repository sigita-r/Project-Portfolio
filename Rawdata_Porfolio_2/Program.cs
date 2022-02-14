using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rawdata_Porfolio_2.Entity_Framework;
using System.Security.Cryptography;
using System.Text;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using Rawdata_Porfolio_2.Entity_Framework;


namespace Rawdata_Porfolio_2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var ds = new DataService();
            //Console.WriteLine(ds.CreateTitleBM(1,1,"title bm"));
            //Console.WriteLine(ds.DeleteTitleBM(1, 1));
            //Console.WriteLine(ds.UpdateTitleBM(1,1,"addition"));

            //Using the object which is returned by ReadTitleBM
            /*    foreach (Bookmarks_Personality bp in ds.GetPersonalityBMsByUserID(2)) 
                {
                    Console.WriteLine(bp.Name);
                }
               var prog = ds.GetPersonalityBMsByUserID(2);
               Console.WriteLine(prog.Count());*/

            //  Console.WriteLine(ds.ReadCharacter(1));


            //string plainData = "password";
            //var hashedData = ComputeSha256Hash(plainData);

            // ds.CreateUser("test", hashedData, "mail@mail.com", DateTime.Today);


            /* Console.WriteLine(ds.GetKnownCharactersFromTitleById(1).Count);

             Console.WriteLine(ds.GetCharactersFromTitleById(1).Count);*/

            // ds.UpdateUser(2, "newmail@mail.com", "newname", hashedData, DateTime.Today);
            //Console.WriteLine(ds.GetUser(2));
            //Console.WriteLine(ds.DeleteUser(3));
            /* Console.WriteLine(ds.GetTitleGenre(1));

             foreach (Title_Genre tg in ds.GetTitleGenre(1)) 
             {
                 Console.WriteLine(tg.Genre);
             }
            */
            //Console.WriteLine(ds.CreateRating(1, 1, 5));

            //Console.WriteLine(ds.UpdateRating(1,1,4));
            //Console.WriteLine(ds.DeleteRating(1,1));


            //Console.WriteLine(ds.DeleteSQ(1));
            // Console.WriteLine(ds.GetSQ(1));
            //Console.WriteLine(ds.GetRole(212920, 41572));
            // Console.WriteLine( ds.ActorSearch(2, "Fred"));
            /*

            foreach (Search_results sr in ds.SS_Search(2, "batman", "", "", "Christian"))
               {
                   Console.WriteLine(sr.Title_Name + sr.Title_ID);
               }*/

            //ds.CreateUser("Check", ds.ComputeSha256Hash(p), "hsahmad@mail.dk", DateTime.Today);

            /*string p = "password";
            var ps = ds.ComputeSha256Hash(p);
            string v = ds.Login("Check", ps);
            Console.WriteLine(v);*/

            // Console.WriteLine(ds.GetPersonalityById(1));
            /*
            string password = "password";
             byte[] pwBytes = Encoding.Unicode.GetBytes(password);
             ds.CreateUser("Check2", pwBytes, "hsahmad@maidl.dk", DateTime.Today);


             Console.WriteLine(ds.Login("Check2", pwBytes));*/
            
            /*List<Search_results> result = ds.SS_Search(2, "Batman", "", "Gotham", "");*/

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
    }
}
