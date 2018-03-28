using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class CustomersModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cellPhone { get; set; }
        public string homePhone { get; set; }

        internal CustomersModel ToString(string v)
        {
            throw new NotImplementedException();
        }
    }
}