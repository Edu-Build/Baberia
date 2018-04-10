using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class SaleProductController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerSaleProducts sale;


        public SaleProductController()
        {
            /*Instanciando el objeto dentro del contructor*/
            sale = new ManagerSaleProducts();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Sales()
        {

            return Json(new { data = sale.allRegisterSale() }, JsonRequestBehavior.AllowGet);

        }

        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Sale(int? id, SaleProductModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(sale.createRegisterSale(item));
                case "PUT":
                    return Json(sale.updateRegisterSale(item));
                case "GET":
                    return Json(sale.returnRegisterSale(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(sale.deleteRegisterSale(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}