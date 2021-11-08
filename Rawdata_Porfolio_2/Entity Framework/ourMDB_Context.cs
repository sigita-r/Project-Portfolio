using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using System.IO;


namespace Rawdata_Porfolio_2.Entity_Framework
{
    public class OurMDB_Context : DbContext
    {
        public DbSet<Bookmarks_Personality> Bookmark_Personalities { get; set; }
        public DbSet<Bookmarks_Title> Bookmarks { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Personality> Personalities { get; set; }
        public DbSet<Personality_Profession> Personality_Professions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Search_Queries> Search_Queries { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Title_Genres> Title_Genres { get; set; }
        public DbSet<Title_Localization> Title_Localizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wi> Wis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();

           
            string connStringFromFile;

            using (StreamReader readtext = new StreamReader("%USERPROFILE%/Roskilde Universitet/Group 14 - RAWDATA - Documents/General/Project portfolio/Part 2/Login.txt"))
            {
                connStringFromFile = readtext.ReadLine();
            }
            optionsBuilder.UseNpgsql(connStringFromFile);
        }

      

    }
}
