using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Personality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year_Birth { get; set; }
        public int? Year_Death { get; set; }
        public List<Bookmarks_Personality> Bookmarks_Personalities { get; set; }
        public List<Character> Characters { get; set; }
        public List<Role> Roles { get; set; }

        public override string ToString()
        {
            return $"Personality Id ={Id}, Year of Birth = {Year_Birth}, Year of Death= {Year_Death}";
        }
    }
}
