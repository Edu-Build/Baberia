using Barberia.Areas.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Areas.ApiRest.Controllers
{
    public class ProductsController : Controller
    {
        /*Declarando un objeto de privado para posteriormente porder ser instanciado*/
        private ManagerProducts product;


        public ProductsController()
        {
            /*Instanciando el objeto dentro del contructor*/
            product = new ManagerProducts();
        }



        [HttpGet]
        public JsonResult Quantity(int id)
        {
            return Json(product.returnQuantity(id), JsonRequestBehavior.AllowGet);
        }


        /*Alta Producto*/
        [HttpPut]
        public JsonResult High(ProductsActionModel high)
        {
            return Json(product.updateProductHigh(high));
        }


        /*Baja Producto*/
        [HttpPut]
        public JsonResult Down(ProductsActionModel down)
        {
            return Json(product.updateProductDown(down));
        }


        /*Retornamos los clientes en formato Json*/
        [HttpGet]
        public JsonResult Products()
        {

            return Json(new { data = product.allProduct() }, JsonRequestBehavior.AllowGet);

        }

        /*Action JsonResult que con un condional Case evaluara que metodo se ejecutara dependiendo de la Peticion del cliente*/
        public JsonResult Product(int? id, ProductsModel item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(product.createProducto(item));
                case "PUT":
                    return Json(product.updateProduct(item));
                case "GET":
                    return Json(product.returnProduct(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(product.deleteProduct(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}