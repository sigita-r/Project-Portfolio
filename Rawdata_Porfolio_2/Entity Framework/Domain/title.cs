using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Title
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsAdult { get; set; }
        public int Year_Start { get; set; }
        public int Year_End { get; set; }
        public int Runtime { get; set; }
        public double ? AvgRating { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }

        public List<Bookmarks_Title> Bookmarks_Titles { get; set;}
        public List<Character> Characters { get; set; }
        public List<Episode> Episodes { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Role> Roles { get; set; }
        public List<Title_Genre> Title_Genres { get; set; }
        public List<Title_Localization> Title_Localizations { get; set; }
        public List<Wi> Wis { get; set; }

        public override string ToString()
        {
            return $"Title ID = {Id}, Type = {Type}, Is Adult? = {IsAdult}, Start year = {Year_Start}, End year = {Year_End}, Runtime = {Runtime}, Average Rating = {AvgRating}, Poster URL = {Poster}, Plot = {Plot}, Awards = {Awards}";
        }
    }
}
