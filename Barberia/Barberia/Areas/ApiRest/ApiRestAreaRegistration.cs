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
                "accessUsers",
                "Api/CatUsuarios/Usuario/{id}",
                new { controller = "Users", action = "Users", id = UrlParameter.Optional }
            );

            /*Listado Usuarios*/
            context.MapRoute(
                "accessListUsers",
                "Api/CatUsuarios",
                new { controller = "Users", action = "UserList" }
            );

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


            /*Actualizacion proceso reervacion*/
            context.MapRoute(
                "accessActReservacion",
                "Api/Actualizar/Proceso/{id}",
                new { controller = "Reservations", action = "ProcessUpdate", id = UrlParameter.Optional }
            );


            /*Acciones Rest Tiendas*/
            context.MapRoute(
                "accessStoreCatalog",
                "Api/CatTienda/Tienda/{id}",
                new { controller = "StoreCatalog", action = "Store", id = UrlParameter.Optional }
            );

            /*Listado de Tiendas*/
            context.MapRoute(
                "accessStoresCatalog",
                "Api/CatTienda",
                new { controller = "StoreCatalog", action = "Stores" }
            );

            /*Combo Tienda*/
            context.MapRoute(
                "accessComboStore",
                "Api/ComTienda",
                new { controller = "ComboStore", action = "Stores" }
            );

            /*Acciones Rest Servicios*/
            context.MapRoute(
                "accessService",
                "Api/CatServicio/Servicio/{id}",
                new { controller = "ServicesCatalog", action = "Service", id = UrlParameter.Optional }
            );

            /*Listado Servicios*/
            context.MapRoute(
                "accessServices",
                "Api/CatServicio",
                new { controller = "ServicesCatalog", action = "Services" }
            );

            /*Combo Servicios*/
            context.MapRoute(
                "accessComboService",
                "Api/ComServicio",
                new { controller = "ComboService", action = "Services" }
            );


            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}