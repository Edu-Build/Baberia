using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class SaleServiceReservationModel
    {
        public int id { get; set; }
        public int idReservation { get; set; }
        public int idEmploye { get; set; }
        public double discount { get; set; }
        public decimal total { get; set; }
    }
}