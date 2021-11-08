using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Character
    {
        public int Personality_Id { get; set; }
        public Personality Personality { get; set; }
        public int Title_Id { get; set; }
        public Title Title { get; set; }
        public int Id { get; set; }
        public string CharacterOfPersonality { get; set; }
        public bool Known_For { get; set; }
    }
}
