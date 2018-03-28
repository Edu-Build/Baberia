using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class StoreCatalogModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string town { get; set; }
        public string addressSt { get; set; }
        public string phone { get; set; }
    }
}