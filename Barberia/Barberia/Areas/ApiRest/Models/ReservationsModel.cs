using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ReservationsModel
    {
        public int id { get; set; }
        public int idService { get; set; }
        public int idStore { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string flName { get; set; }
        public string reservation { get; set; }
       
    }
}