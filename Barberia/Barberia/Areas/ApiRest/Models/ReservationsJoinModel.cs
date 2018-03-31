using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ReservationsJoinModel
    {
        public int id { get; set; }
        public string nameService { get; set; }
        public string nameStore { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string nameFL { get; set; }
        public string dateReservation{ get; set; }
        public string reservation { get; set; }
        public string process { get; set; }

    }
}