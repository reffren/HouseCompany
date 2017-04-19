using HouseCompany.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseCompany.Web.Models
{
    public class MainModel
    {
        public IEnumerable<PhotoMainPage> PhotosMainPage { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public AboutCompany AboutCompany { get; set; }
    }
}