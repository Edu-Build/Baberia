using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class BuyedProductsModel
    {
        public int id { get; set; }
        public int idProduct { get; set; }
        public decimal priceBuy { get; set; }
        public int quantity { get; set; }
    }
}