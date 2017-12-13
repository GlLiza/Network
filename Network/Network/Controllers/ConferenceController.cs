using Network.BL.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Controllers
{
    public class ConferenceController : Controller
    {
        private  ConferenceService _conService;
        private UserService _userService;

        public ConferenceController(ConferenceService conService, UserService userService)
        {
            _conService = conService;
            _userService = userService;
        }


        // GET: Conference
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateConference()
        {
            return View();
        }
    }
}