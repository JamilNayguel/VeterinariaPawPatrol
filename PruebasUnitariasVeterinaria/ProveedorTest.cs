using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using VeterinariaPP.Models;
using VeterinariaPP.Controllers;


namespace PruebasUnitariasVeterinaria
{
    [TestClass]
    public class ProveedorTest
    {
        private Proveedor proveedor = new Proveedor();

        [TestMethod]
        public void MetodoAgregar()
        {

            string nombreProveedor = "Jose Pepas Duras";
            string dni = "78653498";
            int celular = 987353498;
            string email = "JosePespas@gmail.com";
            int idestadoprove = 1;
            int idcategoria = 10;

            bool resultadoesperado = false;

            bool resultado = proveedor.Agregar(nombreProveedor, dni, celular, email, idestadoprove, idcategoria);
            Assert.AreEqual(resultado, resultadoesperado);
        }
        [TestMethod]
        public void MetodoEditar()
        {
            int idproveedor = 3;
            string nombreProveedor = "Jose Pepas Duras";
            string dni = "78653498";
            int celular = 987353498;
            string email = "JosePespas@gmail.com";
            int idestadoprove = 15;
            int idcategoria = 10;

            bool resultadoesperado = false;

            bool resultado = proveedor.Actualizar(idproveedor,nombreProveedor, dni, celular, email, idestadoprove, idcategoria);
            Assert.AreEqual(resultado, resultadoesperado);
        }
        
    }
}
