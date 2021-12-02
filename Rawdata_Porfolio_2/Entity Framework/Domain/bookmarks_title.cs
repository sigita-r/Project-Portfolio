using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Bookmarks_Title
    {
        [Key]
        public int User_Id { get; set; }
        public User User { get; set; }
        public Int64 Title_Id { get; set; }
        public Title Title { get; set; }
        public string Note { get; set; }
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"User Id ={User_Id}, Title ID = {Title_Id}, Note = {Note}, Timestamp = {Timestamp}";
        }
    }
}
