using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseCompany.Data.Entities
{
    public class PhotoMainPage
    {
        [Key]
        public int PhotoMainID { get; set; }
        public string PhotoMain { get; set; }
        public string PhotoName { get; set; }
    }
}