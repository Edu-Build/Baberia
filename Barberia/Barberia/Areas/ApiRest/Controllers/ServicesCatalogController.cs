using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ServicesCatalogController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerServicesCatalog service;


        public ServicesCatalogController()
        {
            /*Instanciando el objeto dentro del contructor*/
            service = new ManagerServicesCatalog();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Services()
        {

            return Json(new { data = service.allService() }, JsonRequestBehavior.AllowGet);

        }

        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Service(int? id, ServicesCatalogModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(service.createService(item));
                case "PUT":
                    return Json(service.updateService(item));
                case "GET":
                    return Json(service.returnService(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(service.deleteService(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}