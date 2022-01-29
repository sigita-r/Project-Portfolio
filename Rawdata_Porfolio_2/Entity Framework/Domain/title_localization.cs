using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rawdata_Porfolio_2.Pages.Entity_Framework.Domain
{
    public class Title_Localization
    {

        public long Title_Id { get; set; }
        public Title Title { get; set; }
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        public bool PrimaryTitle { get; set; }

        public override string ToString()
        {
            return $"Title ID = {Title_Id}, Localization ID = {Id}, Name = {Name}, Language = {Language}, Region ={Region}, Type = {Type}, Attribute = {Attribute}, Is Primary Title = {PrimaryTitle} ";
        }

    }
}
