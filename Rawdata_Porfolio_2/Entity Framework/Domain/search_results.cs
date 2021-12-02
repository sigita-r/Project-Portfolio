using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Entity_Framework.Domain
{
    public class Search_results
    {
        public int User_Id { get; set; }
        public int Personality_ID { get; set; }
        public Int64 Title_ID { get; set; }
        public string Character_Name { get; set; }
        public int Year_Birth { get; set; }
        public int Year_Death { get; set; }
        public string Plot { get; set; }
        public string Title_Name { get; set; }
     
        public string Personality_Name { get; set; }

    }
}
