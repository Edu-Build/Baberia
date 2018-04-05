using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ComboReservationModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int idService { get; set; }
        public string nameService { get; set; }
        public decimal price { get; set; }
    }
}