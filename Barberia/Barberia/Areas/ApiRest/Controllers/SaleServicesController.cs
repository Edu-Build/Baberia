using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class SaleServicesController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerSaleService sale;


        public SaleServicesController()
        {
            /*Instanciando el objeto dentro del contructor*/
            sale = new ManagerSaleService();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult SaleServices()
        {

            return Json(new { data = sale.allSaleServices() }, JsonRequestBehavior.AllowGet);

        }


        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult SaleService(int? id, SaleServicesModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(sale.createSale(item));
                case "PUT":
                    return Json(sale.updateSaleService(item));
                case "GET":
                    return Json(sale.returnSaleService(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(sale.deleteSaleService(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}