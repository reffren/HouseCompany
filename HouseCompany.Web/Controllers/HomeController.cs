using HouseCompany.Data.Abstract;
using HouseCompany.Data.Entities;
using HouseCompany.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseCompany.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        private MainModel _mainModel;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            _mainModel = new MainModel()
            {
                PhotosMainPage = _repository.PhotosMainPage.ToList(),
                Comments = _repository.Comments.ToList(),
                AboutCompany = _repository.AboutCompanies.FirstOrDefault()
            };
            return View(_mainModel);
        }

        public ActionResult Gallery()
        {
            var photos = _repository.PhotoGalleries.OrderByDescending(o => o.PhotoID).ToList();
            return View(photos);
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Comments()
        {
            var comments = _repository.Comments.ToList();
            return View(comments);
        }

        public FileContentResult GetImageComment(int commentId)
        {
            Comment com = _repository.Comments.FirstOrDefault(f => f.CommentID == commentId);
            if (com != null)
            {
                return File(com.UserPhoto, com.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
	}
}