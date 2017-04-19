using HouseCompany.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCompany.Data.Abstract
{
    public interface IRepository
    {
        IQueryable<PhotoGallery> PhotoGalleries { get; }
        void SavePhoto(PhotoGallery photo);
        void DeletePhoto(PhotoGallery photo);

        IQueryable<Comment> Comments { get; }
        void SaveComment(Comment comment);
        void DeleteComment(Comment comment);

        IQueryable<PhotoMainPage> PhotosMainPage { get; }
        void SavePhotoMainPage(PhotoMainPage photosMainPage);
        void DeletePhotoMainPage(PhotoMainPage photosMainPage);

        IQueryable<Contact> Contacts { get; }
        void SaveContscts(Contact contact);

        IQueryable<AboutCompany> AboutCompanies { get; }
        void SaveAboutCompany(AboutCompany aboutCompany);

    }
}
