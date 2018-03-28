using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class StoreCatalogController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerStoreCatalog store;


        public StoreCatalogController()
        {
            /*Instanciando el objeto dentro del contructor*/
            store = new ManagerStoreCatalog();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Stores()
        {

            return Json(new { data = store.allStore() }, JsonRequestBehavior.AllowGet);

        }

        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Store(int? id, StoreCatalogModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(store.createStore(item));
                case "PUT":
                    return Json((store.updateStore(item)));
                case "GET":
                    return Json((store.returnStore(id.GetValueOrDefault())), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(store.deleteStore(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}