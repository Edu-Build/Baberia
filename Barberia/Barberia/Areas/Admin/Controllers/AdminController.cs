using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.Admin.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {

        [Authorize (Roles = "Admin, Registrador")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Service()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Reservation()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Employ()
        {
            return View();
        }
    }
}