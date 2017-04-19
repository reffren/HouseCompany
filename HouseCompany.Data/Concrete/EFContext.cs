using HouseCompany.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HouseCompany.Data.Concrete
{
    public class EFContext : DbContext
    {
        public DbSet<PhotoGallery> PhotoGalleries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PhotoMainPage> PhotosMainPage { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AboutCompany> AboutCompanies { get; set; }
    }
}