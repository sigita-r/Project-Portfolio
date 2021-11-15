using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rawdata_Porfolio_2.Entity_Framework;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;

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
            /* foreach (Bookmarks_Title bt in ds.ReadTitleBM(1)) 
             {
                 Console.WriteLine(bt.Name);
             }*/
            //  Console.WriteLine(ds.ReadCharacter(1));
            /* I cant make this work, idk why
             byte[] passExample = new byte[] { 1, 2, 3 };
             Console.WriteLine(ds.CreateUser(1, "test", passExample, "mail@mail.com", DateTime.Parse("15/11/2021")));*/
            /* Console.WriteLine(ds.GetKnownCharactersFromTitleById(1).Count);

             Console.WriteLine(ds.GetCharactersFromTitleById(1).Count);*/

            //Console.WriteLine(ds.GetUser(1));
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
