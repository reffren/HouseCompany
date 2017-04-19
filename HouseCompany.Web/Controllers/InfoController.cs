using HouseCompany.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseCompany.Web.Controllers
{
    public class InfoController : Controller
    {
        private IRepository _repository;

        public InfoController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult SiteInfo()
        {
            return PartialView(_repository.Contacts.FirstOrDefault());
        }
	}
}