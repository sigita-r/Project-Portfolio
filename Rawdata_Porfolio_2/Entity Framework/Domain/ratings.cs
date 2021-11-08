﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Rating
    {
        public int User_Id { get; set; }
        public User User { get; set; }
        public int Title_Id { get; set; }
        public Title Title { get; set; }
        public int RatingOfTitle { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
