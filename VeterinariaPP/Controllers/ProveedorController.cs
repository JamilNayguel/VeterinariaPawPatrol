using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaPP.Models;

namespace VeterinariaPP.Controllers
{
    public class ProveedorController : Controller
    {
        private Proveedor proveedor = new Proveedor();
        [HttpGet]
        public ActionResult ListarProveedores()
        {
            return View(proveedor.Listar());
        }
        [HttpPost]
        public String BuscarProveedor(string dato_busqueda)
        {
            string res = "";
            var lista = new List<Proveedor>();
            var categoria = new VeterinariaPP.Models.DB().Categoria.ToList();
            var estados = new VeterinariaPP.Models.DB().Estado.ToList();
            lista = proveedor.BuscarProveedor(dato_busqueda);
            foreach (var l in lista)
            {
                string boton2 = "<button class='btn btn-default' type='button' id='btn_editar' "
                            + "name='btn_editar' onclick=\"location.href='../Proveedor/EditarProveedor?Id=" + l.IdProveedor + "'\">"
                            + "<span class=\"glyphicon glyphicon-edit\"> Editar</span></button>";

                string boton3 = "<button class='btn btn-danger' type='button' id='btn_eliminar' name='btn_eliminar' "
                            + "onclick=\"location.href='../Proveedor/EliminarDefinitivo?Id=" + l.IdProveedor + "'\"><span class=\"glyphicon glyphicon-trash\"> Eliminar</span></button>";

                foreach (var c in categoria)
                {
                    if (l.IdCategoria == c.IdCategoria)
                    {
                        foreach (var e in estados)
                        {
                            if (l.IdEstadoProveedor == e.IdEstado)
                            {
                                res = res +
                                "<tr><td>" + l.NombreProveedor + "</td>"
                                + "<td>" + l.DNI + "</td>"
                                + "<td>" + l.Celular + "</td>"
                                + "<td>" + l.Email + "</td>"
                                + "<td>" + e.NombreEstado + "</td>"
                                + "<td>" + c.NombreCategoria + "</td>"
                                + "<td>" + boton2 + " " + boton3 + "</td></tr>";
                            }
                        }
                    }
                }

            }
            return res;
        }
        public ActionResult AgregarProveedor()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Registrar nuevo Proveedor";
            return View();
        }
        [HttpPost]
        public ActionResult AgregarProveedor(string NombreProveedor, string DNI, int Celular, string Email, int IdEstadoProveedor, int IdCategoria)
        {
            bool bandera = false;
            var proveedores = new DB().Proveedor.ToList();
            foreach (var p in proveedores)
            {
                if (p.DNI == DNI)
                {
                    bandera = true;
                }
            }
            if (bandera == false)
            {
                if (proveedor.Agregar(NombreProveedor, DNI, Celular, Email, IdEstadoProveedor, IdCategoria))
                {
                    ViewBag.alerta = "success";
                    ViewBag.res = "Nuevo Proveedor Registrado";
                    return View(proveedor);

                }
                else
                {
                    ViewBag.alerta = "danger";
                    ViewBag.res = "Proveedor no registrado, llene los campos correctamente";
                }

            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Ya existe un Proveedor con ese DNI, ingrese uno nuevo";
            }
            return View(proveedor);
        }
        public ActionResult EditarProveedor(int Id)
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Modificar Registro";
            return View(proveedor.Consultar(Id));
        }
        [HttpPost]
        public ActionResult EditarProveedor(int Id, string NombreProveedor, string DNI, int Celular, string Email, int IdEstadoProveedor, int IdCategoria)
        {
            bool bandera = false;
            var proveedores = new DB().Proveedor.ToList();
            foreach (var p in proveedores)
            {
                if (p.DNI == DNI && p.IdProveedor != Id)
                {
                    bandera = true;
                }
            }
            if (bandera == false)
            {
                if (proveedor.Actualizar(Id, NombreProveedor, DNI, Celular, Email, IdEstadoProveedor, IdCategoria))
                {
                    ViewBag.alerta = "success";
                    ViewBag.res = "Registro Modificado";
                    return View(proveedor.Consultar(Id));

                }
                else
                {
                    ViewBag.alerta = "danger";
                    ViewBag.res = "Registro no Modificado, llene los campos correctamente";
                }

            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Ya existe un Proveedor con ese DNI";
            }

            return View(proveedor.Consultar(Id));
        }
        [HttpGet]
        public ActionResult EliminarDefinitivo(int Id)
        {
            if (proveedor.Eliminar(Id))
            {

                return RedirectToAction("ListarProveedores", "Proveedor");

            }
            else
            {
                return RedirectToAction("ListarProveedores", "Proveedor");

            }

        }

    }
}