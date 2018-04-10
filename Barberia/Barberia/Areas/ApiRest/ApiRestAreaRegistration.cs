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


            /*Acciones Rest Usuario*/
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


            /*Actualizacion proceso Reserrvacion*/
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

            /*Acciones Rest Ventas Servicios Reservacion*/
            context.MapRoute(
                "accessSaleReservation",
                "Api/VentasReservacion/Venta/{id}",
                new { controller = "SaleServiceReservation", action = "SaleService", id = UrlParameter.Optional }
            );

            /*Listado Ventas Servicios Reservacion*/
            context.MapRoute(
                "accessSaleReservations",
                "Api/VentasReservacion",
                new { controller = "SaleServiceReservation", action = "SaleServices" }
            );

            /*Acciones Rest Ventas Servicios */
            context.MapRoute(
                "accessSaleService",
                "Api/VentaServicios/Venta/{id}",
                new { controller = "SaleServices", action = "SaleService", id = UrlParameter.Optional }
            );

            /*Listado Ventas Servicios */
            context.MapRoute(
                "accessSaleServices",
                "Api/VentaServicios",
                new { controller = "SaleServices", action = "SaleServices" }
            );
            /*Combo Reservaciones*/
            context.MapRoute(
                "accessComboReservations",
                "Api/ComReservaciones",
                new { controller = "ComboReservation", action = "reservations" }
            );

            /*Retorno reservacion para registro de venta*/
            context.MapRoute(
                "accessReturnReservations",
                "Api/ComRegistroReservacion/Registro/{id}",
                new { controller = "ComboReservation", action = "reservationSale", id = UrlParameter.Optional }
            );


            /*Combo Empleados*/
            context.MapRoute(
                "accessComboEmployees",
                "Api/ComEmpleados",
                new { controller = "ComboEmployees", action = "employees" }
            );


            /*Combo tipos de Productos*/
            context.MapRoute(
                "accessComboTypeProduct",
                "Api/ComTipoProducto",
                new { controller = "ComboTypeProduct", action = "Types" }
            );



            /*Combo tipos de Marcas*/
            context.MapRoute(
                "accessComboBrandProduct",
                "Api/ComMarcasProducto",
                new { controller = "ComboBrandProduct", action = "Brands" }
            );

            /*Acciones Rest Productos */
            context.MapRoute(
                "accessProduct",
                "Api/Productos/producto/{id}",
                new { controller = "Products", action = "Product", id = UrlParameter.Optional }
            );

            /*Listado Rest Productos */
            context.MapRoute(
                "accessProducts",
                "Api/Productos",
                new { controller = "Products", action = "Products" }
            );

            /*Baja de Productos*/
            context.MapRoute(
                "accessProductDown",
                "Api/Producto/Baja/{id}",
                new { controller = "Products", action = "Down", id = UrlParameter.Optional }
            );

            /*Alta de productos*/
            context.MapRoute(
                "accessProductHigh",
                "Api/Producto/Alta/{id}",
                new { controller = "Products", action = "High", id = UrlParameter.Optional }
            );

            /*Baja de Productos*/
            context.MapRoute(
                "accessQuantity",
                "Api/Producto/Cantidad/{id}",
                new { controller = "Products", action = "Quantity", id = UrlParameter.Optional }
            );


            /*Combo  Productos*/
            context.MapRoute(
                "accessComboProduct",
                "Api/ComProducto",
                new { controller = "ComboProducts", action = "Products" }
            );

            /*Acciones Rest Compra de productos */
            context.MapRoute(
                "accessBuyedProduct",
                "Api/CompraProductos/producto/{id}",
                new { controller = "BuyedProducts", action = "Buyed", id = UrlParameter.Optional }
            );

            /*Listado Rest Compra de productos */
            context.MapRoute(
                "accessBuyedProducts",
                "Api/CompraProductos",
                new { controller = "BuyedProducts", action = "Buyeds" }
            );

            /*Acciones Rest Venta Productos */
            context.MapRoute(
                "accessSaleProduct",
                "Api/RegistroProductos/Venta/{id}",
                new { controller = "SaleProduct", action = "Sale", id = UrlParameter.Optional }
            );

            /*Listado Rest Listado Ventas Productos */
            context.MapRoute(
                "accessSaleProducts",
                "Api/RegistroProductos",
                new { controller = "SaleProduct", action = "Sales" }
            );


            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}