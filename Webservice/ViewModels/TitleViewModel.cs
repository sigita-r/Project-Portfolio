using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webservice.ViewModels
{
    public class TitleViewModel
    {
        public string Url { get; set; }

        public long Id { get; set; }
        public string Type { get; set; }
        public bool Is_Adult { get; set; }
        public short? Year_Start { get; set; }
        public short? Year_End { get; set; }
        public int? Runtime { get; set; }
        public double? Avg_Rating { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }
        public string Genres { get; set; }

        /*
        public List<Bookmarks_Title> Bookmarks_Titles { get; set; }
        public List<Character> Characters { get; set; }
        public List<Episode> Episodes { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Role> Roles { get; set; }
        */
    }
}