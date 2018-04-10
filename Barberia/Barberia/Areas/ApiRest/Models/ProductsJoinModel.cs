using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ProductsJoinModel
    {
        public int id { get; set; }
        public string nameBrand { get; set; }
        public string nameType { get; set; }
        public string nameProduct { get; set; }
        public string description { get; set; }
        public decimal salePrice { get; set; }
        public int quantity { get; set; }
    }
}