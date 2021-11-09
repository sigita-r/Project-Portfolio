using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Search_Queries
    {
        [Key]
        public int Id { get; set; }
        public string Query { get; set; }
        public DateTime Timestamp { get; set; }
        public int User_Id { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return $"ID = {Id}, Query = {Query}, User ID= {User_Id}";
        }
    }
}
