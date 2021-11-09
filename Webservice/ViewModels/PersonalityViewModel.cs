using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webservice.ViewModels
{
    public class PersonalityViewModel
    {
        public string Url { get; set; }


        public string Name { get; set; }
        public int Year_Birth { get; set; }
        public int Year_Death { get; set; }
        public string Profession { get; set; }

        /*
        public List<Bookmarks_Personality> Bookmarks_Personalities { get; set; }
        public List<Character> Characters { get; set; }
        public List<Personality> Personalities { get; set; }
        public List<Role> Roles { get; set; }
        */
    }
}
