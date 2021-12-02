using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webservice.ViewModels
{
    public class CharacterViewModel
    {
        public string Name { get; set; }
        public int Personality_Id { get; set; }
        public int Title_Id { get; set; }
        public int Id { get; set; }
        public string CharacterOfPersonality { get; set; }
        public bool Known_For { get; set; }
    }
}