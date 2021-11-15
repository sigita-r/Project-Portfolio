using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Character
    {
        public string Name { get; set; }
        public int Personality_Id { get; set; }
        public Personality Personality { get; set; }
        public int Title_Id { get; set; }
        public Title Title { get; set; }
        [Key]
        public int Id { get; set; }
        public string CharacterOfPersonality { get; set; }
        public bool Known_For { get; set; }

        public override string ToString()
        {
            return $"Personality Id ={Personality_Id}, Title ID = {Title_Id}, Character = {CharacterOfPersonality}, Known for = {Known_For}";
        }
    }
}
