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
        public ActionResult Employe()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Sale()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SaleInventary()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult BuyedInventary()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Products()
        {
            return View();
        }
    }
}