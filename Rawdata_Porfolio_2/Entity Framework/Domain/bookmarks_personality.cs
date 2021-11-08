using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Bookmarks_Personality
    {
        public int User_Id { get; set; }
        public User User { get; set; }
        public int Personality_Id { get; set; }
        public Personality Personality { get; set; }
        public string Note { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
