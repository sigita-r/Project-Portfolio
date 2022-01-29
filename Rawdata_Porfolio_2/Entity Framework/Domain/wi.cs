using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Wi
    {
        [Key]
        public long Title_Id { get; set; }
        public Title Title { get; set; }
        public string Word { get; set; }
        public string Field { get; set; }
        public string Lexeme { get; set; }

        public override string ToString()
        {
            return $"Title ID = {Title_Id}, Word = {Word}, Field = {Field}, Lexeme = {Lexeme}";
        }

    }
}
