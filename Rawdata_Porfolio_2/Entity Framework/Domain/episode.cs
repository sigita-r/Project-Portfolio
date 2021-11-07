using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class episode
    {
        public int Id { get; set; }
        public int Title_Id { get; set; }
        public int Season { get; set; }
        public int Ep_Number { get; set; }

    }
}
