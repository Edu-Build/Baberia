using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ComboBrandProductController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerComboBrandProduct brand;


        public ComboBrandProductController()
        {
            /*Instanciando el objeto dentro del contructor*/
            brand = new ManagerComboBrandProduct();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Brands()
        {

            return Json(brand.ComboBrand(), JsonRequestBehavior.AllowGet);

        }
    }
}