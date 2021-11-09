using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Title_Genre
    {
        [Key]
        public int Title_Id { get; set; }
        public Title Title { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"Title ID = {Title_Id}, Genre = {Genre}";
        }
    }
}
