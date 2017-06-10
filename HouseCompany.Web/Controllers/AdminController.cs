using HouseCompany.Data.Abstract;
using HouseCompany.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseCompany.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRepository _repository;


        public AdminController(IRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View(_repository.PhotosMainPage.ToList());
        }

        [HttpPost]
        public ActionResult EditPhotoMainPage(PhotoMainPage photoMain, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var imgName = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/CarouselImages/"), System.IO.Path.GetFileName(image.FileName));
                    image.SaveAs(path);
                    photoMain.PhotoMain = "~/Content/CarouselImages/" + imgName;
                    _repository.SavePhotoMainPage(photoMain);
                }
                else if (photoMain.PhotoMainID != 0)
                {
                    photoMain = _repository.PhotosMainPage.FirstOrDefault(f => f.PhotoMainID == photoMain.PhotoMainID);

                    string fullPath = Request.MapPath(photoMain.PhotoMain); //delete from server
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    _repository.DeletePhotoMainPage(photoMain);
                }
            }
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult EditComment()
        {
            return View(_repository.Comments.ToList());
        }

        [HttpPost]
        public ActionResult EditComment(Comment comment, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && comment.CommentID ==0)
                {
                    comment.ImageMimeType = image.ContentType;
                    comment.UserPhoto = new byte[image.ContentLength];
                    image.InputStream.Read(comment.UserPhoto, 0, image.ContentLength);
                    _repository.SaveComment(comment);
                }
                else
                {
                    var com = comment;
                    comment = _repository.Comments.FirstOrDefault(f => f.CommentID == com.CommentID);
                    comment.UserName = com.UserName;
                    comment.Message = com.Message;
                    _repository.SaveComment(comment);
                }
            }
            return RedirectToAction("EditComment", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteComment(Comment comments)
        {
            _repository.DeleteComment(comments);
            return RedirectToAction("EditComment", "Admin");
        }

        public ActionResult EditAboutCompany()
        {
            return View(_repository.AboutCompanies.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditAboutCompany(AboutCompany about)
        {
            _repository.SaveAboutCompany(about);
            return View();
        }

        public ActionResult EditPhotoGallery()
        {
            return View(_repository.PhotoGalleries.OrderByDescending(o => o.PhotoID).ToList());
        }

        [HttpPost]
        public ActionResult EditPhotoGallery(PhotoGallery galley, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var imgName = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Gallery/"), System.IO.Path.GetFileName(image.FileName));
                    image.SaveAs(path);
                    galley.Photo = "~/Content/Gallery/" + imgName;
                    _repository.SavePhoto(galley);
                }
                else if (galley.PhotoID != 0)
                {
                    galley = _repository.PhotoGalleries.FirstOrDefault(f => f.PhotoID == galley.PhotoID);

                    string fullPath = Request.MapPath(galley.Photo); //delete from server
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    _repository.DeletePhoto(galley);
                }
            }
            return RedirectToAction("EditPhotoGallery", "Admin");
        }

        public ActionResult EditContacts()
        {
            return View(_repository.Contacts.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditContacts(Contact contact)
        {
            _repository.SaveContscts(contact);
            return View();
        }
    }
}