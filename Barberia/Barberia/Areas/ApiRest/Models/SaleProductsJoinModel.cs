using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class SaleProductsJoinModel
    {
        public int id { get; set; }
        public string nameProduct { get; set; }
        public string nameStore { get; set; }
        public int quantity { get; set; }
        public double discount { get; set; }
        public decimal total { get; set; }
        public string registerSale { get; set; }
    }
}