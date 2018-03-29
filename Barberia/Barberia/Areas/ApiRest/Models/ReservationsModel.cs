using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ReservationsModel
    {
        public int id { get; set; }
        public int idCustomer { get; set; }
        public int idService { get; set; }
        public int idStore { get; set; }
        public string createReservation { get; set; }
        public string dataReservation { get; set; }
        public string process { get; set; }

    }
}