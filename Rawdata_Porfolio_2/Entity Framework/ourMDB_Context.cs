using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;

namespace Rawdata_Porfolio_2.Entity_Framework
{
    public class ourMDB_Context : DbContext
    {
        public DbSet<bookmarks_personality> Bookmark_Personalities { get; set; }
        public DbSet<bookmarks_title> Bookmarks { get; set; }
        public DbSet<characters> Characters { get; set; }
        public DbSet<episode> Episodes { get; set; }
        public DbSet<personality> Personalities { get; set; }
        public DbSet<personality_professions> Personality_Professions { get; set; }
        public DbSet<ratings> Ratings { get; set; }
        public DbSet<roles> Roles { get; set; }
        public DbSet<search_queries> Search_Queries { get; set; }
        public DbSet<title> Titles { get; set; }
        public DbSet<title_genres> title_Genres { get; set; }
        public DbSet<title_localization> Title_Localizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<wi> Wis { get; set; }


    }
}
