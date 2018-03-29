using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class EmployeesController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerEmployees employe;


        public EmployeesController()
        {
            /*Instanciando el objeto dentro del contructor*/
            employe = new ManagerEmployees();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Employees()
        {

            return Json(new { data = employe.allEmployees() }, JsonRequestBehavior.AllowGet);

        }

        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Employe(int? id, EmployeesModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(employe.createEmploye(item));
                case "PUT":
                    return Json(employe.updateEmploye(item));
                case "GET":
                    return Json(employe.returnEmploye(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(employe.deleteEmploye(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}