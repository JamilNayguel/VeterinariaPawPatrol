using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaPP.Models;

namespace VeterinariaPP.Controllers
{
    public class CompraController : Controller
    {
        private Compra compra = new Compra();

        [HttpGet]
        public ActionResult ListarCompras()
        {
            return View(compra.Listar());
        }

        public ActionResult CrearCompra()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Registrar nueva Compra";
            return View();
        }

        // POST: Venta/Create
        [HttpPost]
        public ActionResult CrearCompra(int IdProveedor, int IdEmpleado, string NumComprobante, string TipoPago, string Fecha, int IdVeterinaria)
        {

            if (compra.Crear(IdProveedor, IdEmpleado, NumComprobante, TipoPago, Fecha, IdVeterinaria))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Compra Registrada";
                return View(compra);

            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Compra no registrada, llene los campos correctamente";
            }
            return View(compra);
        }
        public ActionResult Detalles(int Id)
        {

            return View(compra.Consultar(Id));
        }
    }
}