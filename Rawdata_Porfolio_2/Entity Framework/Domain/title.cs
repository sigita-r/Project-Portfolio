using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class title
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Is_Adult { get; set; }
        public int Year_Start { get; set; }
        public int Year_End { get; set; }
        public int Runtime { get; set; }
        public int Avg_Rating { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
    }
}
