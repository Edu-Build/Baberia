using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ComboProductsController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerComboProducts product;


        public ComboProductsController()
        {
            /*Instanciando el objeto dentro del contructor*/
            product = new ManagerComboProducts();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Products()
        {

            return Json(product.ComboProduct(), JsonRequestBehavior.AllowGet);

        }
    }
}