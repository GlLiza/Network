using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Controllers
{
    public class AdvertisementController : Controller
    {
        public AdvertisementController() { }

        // GET: Advertisement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}