using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VeterinariaPP.Models;

namespace PruebasUnitariasVeterinaria
{
    [TestClass]
    public class UsuarioTest
    {
        private Usuario usuario = new Usuario();
        [TestMethod]
        public void MetodoAgregar()
        {

            string nombreusuario = "Roberto Zapata";
            int celular = 987353498;
            string correo = "RobertoZ@gmail.com";
            string contrasena = "RobertoPvz";
            int idprivilegio = 1;
            int idestadousuario = 15;
            int idveterinaria = 1;

            bool resultadoesperado = false;

            bool resultado = usuario.Agregar(nombreusuario, celular, correo, contrasena, idprivilegio, idestadousuario , idveterinaria);
            Assert.AreEqual(resultado, resultadoesperado);
        }
        [TestMethod]
        public void MetodoEditar()
        {
            int idusuario = 1;
            string nombreusuario = "Roberto Zapata";
            int celular = 987353498;
            string correo = "RobertoZ@gmail.com";
            string contrasena = "RobertoPvz";
            int idprivilegio = 1;
            int idestadousuario = 15;
            int idveterinaria = 1;

            bool resultadoesperado = false;

            bool resultado = usuario.Actualizar(idusuario, nombreusuario, celular, correo, contrasena, idprivilegio, idestadousuario, idveterinaria);
            Assert.AreEqual(resultado, resultadoesperado);
        }
        

    }
}
