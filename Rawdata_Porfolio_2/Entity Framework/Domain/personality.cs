using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class personality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year_Birth { get; set; }
        public int Year_Death { get; set; }
    }
}
