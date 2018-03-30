using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barberia.Areas.ApiRest.Models
{
    public class UsersJoinModel
    {

        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string idRol { get; set; }
        public string roleName { get; set; }

    }
}