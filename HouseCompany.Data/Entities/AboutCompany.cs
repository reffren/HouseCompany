using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseCompany.Data.Entities
{
    public class AboutCompany
    {
        [Key]
        public int AboutCompanyID { get; set; }
        public string DescriptionLeft { get; set; }
        public string DescriptionRight { get; set; }

    }
}