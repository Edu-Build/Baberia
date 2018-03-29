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


            /*Acciones Rest empleado*/
            context.MapRoute(
                "accessEmploye",
                "Api/CatEmpleados/Empleado/{id}",
                new { controller = "Employees", action = "Employe", id = UrlParameter.Optional }
            );

            /*Listado Empleados*/
            context.MapRoute(
                "accessEmployees",
                "Api/CatEmpleados",
                new { controller = "Employees", action = "Employees" }
            );


            /*Acciones Rest reservacion*/
            context.MapRoute(
                "accessReservation",
                "Api/CatReservaciones/Reservacion/{id}",
                new { controller = "Reservations", action = "Reservation", id = UrlParameter.Optional }
            );

            /*Listado Reservaciones*/
            context.MapRoute(
                "accessReservations",
                "Api/CatReservaciones",
                new { controller = "Reservations", action = "Reservations" }
            );

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
                "Api/CatalogoTienda/Tienda/{id}",
                new { controller = "StoreCatalog", action = "Store", id = UrlParameter.Optional }
            );

            /*Listado de Tiendas*/
            context.MapRoute(
                "accessStoresCatalog",
                "Api/CatalogoTienda",
                new { controller = "StoreCatalog", action = "Stores" }
            );

            /*Acciones Rest Servicios*/
            context.MapRoute(
                "accessService",
                "Api/CatalogoServicio/Servicio/{id}",
                new { controller = "ServicesCatalog", action = "Service", id = UrlParameter.Optional }
            );

            /*Listado Servicios*/
            context.MapRoute(
                "accessServices",
                "Api/CatalogoServicio",
                new { controller = "ServicesCatalog", action = "Services" }
            );

            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}