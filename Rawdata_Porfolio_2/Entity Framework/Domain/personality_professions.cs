using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Personality_Profession

    { 
        public int Personality_ID { get; set; }
        public Personality Personality { get; set; }
        public string Profession { get; set; }
    }
}
