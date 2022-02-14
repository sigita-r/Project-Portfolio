using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Search_results
    {
        // Personality results
        public int Personality_ID { get; set; }
        public short Year_Birth { get; set; }
        public short Year_Death { get; set; }
        public string Personality_Name { get; set; }
        public string Character_Name { get; set; }
        // Title results
        public long Title_ID { get; set; }
        public string Plot { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsAdult { get; set; }
        public short? Year_Start { get; set; }
        public short? Year_End { get; set; }
        public int? Runtime { get; set; }
        public decimal? Avg_Rating { get; set; }
        public string Poster { get; set; }
        public string Awards { get; set; }
        public string Genres { get; set; }
    }
}
