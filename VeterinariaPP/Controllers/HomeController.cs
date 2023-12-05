using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VeterinariaPP.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace VeterinariaPP.Controllers
{
    public class HomeController : Controller
    {
        static Random aleatorio = new Random();
        static int num = aleatorio.Next(1000, 9999);
        static string codigogenerado = num.ToString();
        public Usuario usuario = new Usuario();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Principal()
        {
            return View();
        }
        public ActionResult Servicios()
        {
            return View();
        }
        public ActionResult Sucursales()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {

            FormsAuthentication.SignOut();
            VeterinariaPP.Models.Usuario objeto = ((VeterinariaPP.Models.Usuario)Session["Usuario"]);
            objeto = null;
            return RedirectToAction("LoginUsuario", "Acceso", objeto);
        }
        public void Verificar(string Correo)
        {

            var password = "ywmjdwxyoqvrwhus";
            var cliente = new SmtpClient("smtp.gmail.com", 587);
            {
                cliente.EnableSsl = true;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential("pawpatrolteleveterinaria@gmail.com", password);
            };
            var email = new MailMessage("pawpatrolteleveterinaria@gmail.com", Correo);
            email.Subject = "Codigo de verificacion de televeterinaria";
            email.Body = codigogenerado;
            email.IsBodyHtml = false;
            cliente.Send(email);
        }
        [HttpGet]
        public ActionResult Codigos()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Ingrese el codigo que se le ha enviado por gmail si es correcto puede iniciar sesion";
            return View();
        }
        [HttpPost]
        public ActionResult Codigos(string Codigo)
        {

            if (Codigo == codigogenerado)
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Codigo Verificado";
                return RedirectToAction("LoginUsuario", "Acceso");

            }
            else
            {
                ViewBag.res = "Codigo Erroneo";
                return View();
            }
        }

        [HttpGet]
        public ActionResult AgregarDueño()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Bienvenid@ al registro de nuevo dueño";
            return View();
        }
        [HttpPost]
        public ActionResult AgregarDueño(string NombreUsuario, int Celular, string Correo, string Contrasena, int IdPrivilegio, int IdEstadoUsuario, int IdVeterinaria)
        {
            Verificar(Correo);
            string contra = Encrypt(Contrasena);
            if (usuario.Agregar(NombreUsuario, Celular, Correo, contra, IdPrivilegio, IdEstadoUsuario, IdVeterinaria))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Registro efectuado";
                return RedirectToAction("Codigos", "Home");

            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Cuenta no registrado, llene los campos correctamente";
                return RedirectToAction("AgregarDueño", "Home");
            }


        }
        static string Encrypt(string textToEncrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [HttpGet]
        public ActionResult EliminarCuenta()
        {
            using (var conexion = new DB())
            {
                int resultado = conexion.Database.ExecuteSqlCommand("DELETE FROM Usuario WHERE IdUsuario=(SELECT MAX(IdUsuario) FROM Usuario)");

            }
            return RedirectToAction("Principal", "Home");
        }
    }
}