using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Title_Localization
    {
        public int Tilte_Id { get; set; }
        public Title Title { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        public bool Primary_Title { get; set; }

    }
}
