using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ComboTypeProductController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerComboTypeProduct type;


        public ComboTypeProductController()
        {
            /*Instanciando el objeto dentro del contructor*/
            type = new ManagerComboTypeProduct();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult types()
        {

            return Json(type.ComboType(), JsonRequestBehavior.AllowGet);

        }
    }
}