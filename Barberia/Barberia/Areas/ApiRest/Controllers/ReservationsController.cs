using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ReservationsController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerReservations reservations;


        public ReservationsController()
        {
            /*Instanciando el objeto dentro del contructor*/
            reservations = new ManagerReservations();
        }

        
        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Reservations()
        {

            return Json(new { data = reservations.allReservations() }, JsonRequestBehavior.AllowGet);

        }


        /*Accion que me actualiza el proceso de mi Reservacion*/
        [HttpPut]
        public JsonResult ProcessUpdate(int id)
        {
            return Json(reservations.updateReservationProcess(id));
        }



        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Reservation(int? id, ReservationsModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(reservations.createReservations(item));
                case "PUT":
                    return Json(reservations.updateReservations(item));
                case "GET":
                    return Json(reservations.returnReservation(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(reservations.deleteReservations(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}