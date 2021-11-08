using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Wi
    {
        public int Title_Id { get; set; }
        public Title Title { get; set; }
        public string Word { get; set; }
        public string Field { get; set; }
        public string Lexeme { get; set; }

    }
}
