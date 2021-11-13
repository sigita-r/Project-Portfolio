using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    //can't we just make this as a list in the Personality?
    public class Personality_Profession

    { 
        [Key]
        public int Personality_Id { get; set; }
        public Personality Personality { get; set; }
        public string Profession { get; set; }

        public override string ToString()
        {
            return $"Personality ID = {Personality_Id}, Profession = {Profession}";
        }
    }
}
