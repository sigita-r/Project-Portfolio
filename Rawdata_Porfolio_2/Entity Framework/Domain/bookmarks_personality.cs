using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class bookmarks_personality
    {
        public int Id { get; set; }
        public int Personality_Id { get; set; }
        public string Note { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
