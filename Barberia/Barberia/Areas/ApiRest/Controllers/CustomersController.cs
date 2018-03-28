using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Barberia.Areas.ApiRest.Controllers
{
    public class CustomersController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerCustomers customers;


        public CustomersController()
        {
            /*Instanciando el objeto dentro del contructor*/
            customers = new ManagerCustomers();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Customer()
        {

            return Json(new { data = customers.allCustomers() }, JsonRequestBehavior.AllowGet);

        }

        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Customers(int? id, CustomersModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(customers.createCustomer(item));
                case "PUT":
                    return Json(customers.updateCustomer(item));
                case "GET":
                    return Json(customers.returnCustomer(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(customers.deleteCustomer(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}