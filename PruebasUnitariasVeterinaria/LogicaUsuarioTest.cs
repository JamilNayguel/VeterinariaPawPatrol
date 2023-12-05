using Microsoft.VisualStudio.TestTools.UnitTesting;
using VeterinariaPP.Logica;
using VeterinariaPP.Models;
using System;

namespace PruebasUnitariasVeterinaria
{
    [TestClass]
    public class LogicaUsuarioTest
    {
        private LogicaUsuario logica = new LogicaUsuario();
        private Usuario usuario = new Usuario();
        [TestMethod]
        public void MetodoEncontrarUsuario()
        {

            string correo = "RobertoZ@gmail.com";
            string contra = "RobertoPvz";

            bool resultadoesperado = false;

            bool resultado = logica.EncontrarUsuario(correo,contra);
            Assert.AreEqual(resultado, resultadoesperado);
        }
        [TestMethod]
        public void MetodoEncontrarCuenta()
        {

            int idusuario = 1;

            bool resultadoesperado = false;

            bool resultado = logica.EncontrarCuenta(idusuario);
            Assert.AreEqual(resultado, resultadoesperado);
        }
    }
}
