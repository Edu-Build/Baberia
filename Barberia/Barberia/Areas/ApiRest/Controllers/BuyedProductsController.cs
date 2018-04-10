using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class BuyedProductsController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerBuyedProducts buyed;


        public BuyedProductsController()
        {
            /*Instanciando el objeto dentro del contructor*/
            buyed = new ManagerBuyedProducts();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Buyeds()
        {

            return Json(new { data = buyed.allBuyed() }, JsonRequestBehavior.AllowGet);

        }

        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Buyed(int? id, BuyedProductsModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(buyed.createBuyed(item));
                case "PUT":
                    return Json(buyed.updateBuyed(item));
                case "GET":
                    return Json(buyed.returnBuyed(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(buyed.deleteProduct(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}