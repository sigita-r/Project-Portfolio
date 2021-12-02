using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webservice.ViewModels
{
    public class RatingViewModel
    {
        public int User_Id { get; set; }
        public Int64 Title_Id { get; set; }
        public int RatingOfTitle { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
