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
            /*Acciones Rest Cliente*/
            context.MapRoute(
                "accessCustomer",
                "Api/Clientes/Cliente/{id}",
                new { controller = "Customers", action = "Customer", id = UrlParameter.Optional }
            );

            /*Listado Cliente*/
            context.MapRoute(
                "accessCustomers",
                "Api/Clientes",
                new { controller = "Customers", action = "Customers" }
            );

             /*Acciones Rest Tiendas*/
            context.MapRoute(
                "accessStoreCatalog",
                "Api/Catalogo/Tienda/{id}",
                new { controller = "StoreCatalog", action = "Store", id = UrlParameter.Optional }
            );

            /*Listado de Tiendas*/
            context.MapRoute(
                "accessStoresCatalog",
                "Api/Catalogo",
                new { controller = "StoreCatalog", action = "Stores" }
            );

            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}