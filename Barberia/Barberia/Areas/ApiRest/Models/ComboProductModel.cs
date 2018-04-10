using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ComboProductModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal salePrice { get; set; }
        public int quantity { get; set; }
    }
}