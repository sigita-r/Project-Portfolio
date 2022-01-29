using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Rating
    {
        [Key]
        public int User_Id { get; set; }
        public User User { get; set; }
        public long Title_Id { get; set; }
        public Title Title { get; set; }
        public short RatingOfTitle { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"User Id ={User_Id}, Title ID = {Title_Id}, Rating of Title = {RatingOfTitle}, Timestamp = {Timestamp}";
        }
    }
}
