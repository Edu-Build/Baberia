using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class ServicesCatalogModel
    {

        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string descriptionS { get; set; }
        public decimal price { get; set; }
    }
}