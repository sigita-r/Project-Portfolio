using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webservice.ViewModels
{
    public class RatingViewModel
    {
        public int User_Id { get; set; }
        public long Title_Id { get; set; }
        public short RatingOfTitle { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
