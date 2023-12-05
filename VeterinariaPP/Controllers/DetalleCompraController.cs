using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaPP.Models;

namespace VeterinariaPP.Controllers
{
    public class DetalleCompraController : Controller
    {
        private DetalleCompra detalles = new DetalleCompra();
        [HttpGet]
        public ActionResult CrearDetalle()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Agregue los articulos";
            return View(detalles.Listar());
        }
        [HttpPost]
        public ActionResult CrearDetalle(int IdProducto, int Cantidad)
        {
            if (detalles.Crear(IdProducto, Cantidad))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Producto Agregado, Desea agregar mas?";
                return View(detalles.Listar());

            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = ViewBag.res = "Producto No Agregado";

            }
            return View(detalles.Listar());

        }
    }
}