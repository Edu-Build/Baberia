using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class SaleServiceReservationController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerSaleServiceReservation sale;


        public SaleServiceReservationController()
        {
            /*Instanciando el objeto dentro del contructor*/
            sale = new ManagerSaleServiceReservation();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult SaleServices()
        {

            return Json(new { data = sale.allSaleReservation() }, JsonRequestBehavior.AllowGet);

        }


        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult SaleService(int? id, SaleServiceReservationModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(sale.createSaleReservation(item));
                case "PUT":
                    return Json(sale.updateSaleReservations(item));
                case "GET":
                    return Json(sale.returnSaleReservation(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(sale.deleteSaleReservations(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}