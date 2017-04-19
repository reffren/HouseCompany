using HouseCompany.Data.Abstract;
using HouseCompany.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HouseCompany.Data.Concrete
{
    public class Repository : IRepository
    {
        private EFContext context = new EFContext();
        public IQueryable<PhotoGallery> PhotoGalleries
        {
            get { return context.PhotoGalleries; }
        }

        public void SavePhoto(PhotoGallery photo)
        {
            if (photo.PhotoID == 0)
            {
                context.PhotoGalleries.Add(photo);
            }
            else
            {
                context.Entry(photo).State = EntityState.Modified; // Indicating that the record is changed
            }
            context.SaveChanges();
        }

        public void DeletePhoto(PhotoGallery photo)
        {
            context.Entry(photo).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IQueryable<Comment> Comments
        {
            get { return context.Comments; }
        }
        public void SaveComment(Comment comment)
        {
            if (comment.CommentID == 0)
            {
                context.Comments.Add(comment);
            }
            else
            {
                context.Entry(comment).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteComment(Comment comment)
        {
            context.Entry(comment).State = EntityState.Deleted;
            context.SaveChanges();
        }


        public IQueryable<PhotoMainPage> PhotosMainPage
        {
            get { return context.PhotosMainPage; }
        }

        public void SavePhotoMainPage(PhotoMainPage photosMainPage)
        {
            if (photosMainPage.PhotoMainID == 0)
            {
                context.PhotosMainPage.Add(photosMainPage);
            }
            else
            {
                context.Entry(photosMainPage).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeletePhotoMainPage(PhotoMainPage photosMainPage)
        {
            context.Entry(photosMainPage).State = EntityState.Deleted;
            context.SaveChanges();
        }


        public IQueryable<Contact> Contacts
        {
            get { return context.Contacts; }
        }

        public void SaveContscts(Contact contact)
        {
            if (contact.ContactID == 0)
            {
                context.Contacts.Add(contact);
            }
            else
            {
                context.Entry(contact).State = EntityState.Modified;
            }
            context.SaveChanges();
        }


        public IQueryable<AboutCompany> AboutCompanies
        {
            get { return context.AboutCompanies; }
        }

        public void SaveAboutCompany(AboutCompany aboutCompany)
        {
            if (aboutCompany.AboutCompanyID == 0)
            {
                context.AboutCompanies.Add(aboutCompany);
            }
            else
            {
                context.Entry(aboutCompany).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}