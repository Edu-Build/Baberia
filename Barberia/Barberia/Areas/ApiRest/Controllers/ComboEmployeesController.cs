using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ComboEmployeesController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerComboEmployees employe;


        public ComboEmployeesController()
        {
            /*Instanciando el objeto dentro del contructor*/
            employe = new ManagerComboEmployees();
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult employees()
        {

            return Json(employe.ComboEmployees(), JsonRequestBehavior.AllowGet);

        }
    }
}