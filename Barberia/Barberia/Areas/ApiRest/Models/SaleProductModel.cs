using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class SaleProductModel
    {
        public int id { get; set; }
        public int idProduct { get; set; }
        public int idStore { get; set; }
        public int quantity { get; set; }
        public double discount { get; set; }
        public decimal total { get; set; }

    }
}