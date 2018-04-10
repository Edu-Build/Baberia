using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ProductsModel
    {
        public int id { get; set; }
        public string idBrand { get; set; }
        public string idType { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal salePrice { get; set; }
        public int quantity { get; set; }
    }
}