using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class characters
    {
        public int Personality_Id { get; set; }
        public int Title_Id { get; set; }
        public int Id { get; set; }
        public string Character { get; set; }
        public bool Known_For { get; set; }
    }
}
