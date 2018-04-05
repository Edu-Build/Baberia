using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ComboReservationController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerComboReservations reservation;


        public ComboReservationController()
        {
            /*Instanciando el objeto dentro del contructor*/
            reservation = new ManagerComboReservations();
        }

        [HttpGet]
        public JsonResult reservationSale(int id)
        {

            return Json(reservation.retunrReservationSale(id), JsonRequestBehavior.AllowGet);

        }



        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult reservations()
        {

            return Json(reservation.ComboService(), JsonRequestBehavior.AllowGet);

        }
    }
}