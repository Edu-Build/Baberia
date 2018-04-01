using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ComboStoreController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerComboStore store;


        public ComboStoreController()
        {
            /*Instanciando el objeto dentro del contructor*/
            store = new ManagerComboStore();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Stores()
        {

            return Json( store.ComboStore(), JsonRequestBehavior.AllowGet);

        }
    }
}