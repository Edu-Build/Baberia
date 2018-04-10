using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class BuyedProductsJoinModel
    {
        public int id { get; set; }
        public string nameProduct { get; set; }
        public decimal priceBuy { get; set; }
        public int quantity { get; set; }
        public string register { get; set; }
    }
}