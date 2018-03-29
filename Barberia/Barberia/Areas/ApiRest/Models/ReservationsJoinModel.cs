using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ReservationsJoinModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string service { get; set; }
        public string store { get; set; }
        public string createReservation { get; set; }
        public string dataReservation { get; set; }
        public string process { get; set; }
      
    }
}