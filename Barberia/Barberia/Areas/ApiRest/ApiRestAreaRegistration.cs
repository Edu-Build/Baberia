using System.Web.Mvc;

namespace Barberia.Areas.ApiRest
{
    public class ApiRestAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ApiRest";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            /*Acciones Rest*/
            context.MapRoute(
                "accessCustomer",
                "Api/Clientes/Cliente/{id}",
                new { controller = "Customers", action = "Customers", id = UrlParameter.Optional }
            );

            /*Listado*/
            context.MapRoute(
                "accessCustomers",
                "Api/Clientes",
                new { controller = "Customers", action = "Customer" }
            );


            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}