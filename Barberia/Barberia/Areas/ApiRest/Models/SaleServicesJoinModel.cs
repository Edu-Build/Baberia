using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class SaleServicesJoinModel
    {
        public int id { get; set; }
        public string nameService { get; set; }
        public string nameStore { get; set; }
        public string nameEmploye { get; set; }
        public string dateRegister { get; set; }
        public double discount { get; set; }
        public decimal total { get; set; }
    }
}