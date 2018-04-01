using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ComboServiceController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerComboService service;


        public ComboServiceController()
        {
            /*Instanciando el objeto dentro del contructor*/
            service = new ManagerComboService();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Services()
        {

            return Json( service.ComboService(), JsonRequestBehavior.AllowGet);

        }
    }
}