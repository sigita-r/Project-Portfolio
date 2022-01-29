using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Role
    {
        
        public string Name { get; set; }
        public int Personality_Id { get; set; }
        public Personality Personality { get; set; }
        public long Title_Id { get; set; }
        public Title Title { get; set; }
        public string RoleOfPersonality { get; set; }

        public override string ToString()
        {
            return $"Personality ID = {Personality_Id}, Title ID = {Title_Id}, Role of Personality = {RoleOfPersonality}";
        }
    }
}
