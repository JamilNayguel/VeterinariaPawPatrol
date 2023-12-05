using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VeterinariaPP.Models;
using System.Text;

namespace PruebasUnitariasVeterinaria
{
    
    [TestClass]
    public class VeterinariaTest
    {
        private Veterinaria veterinaria = new Veterinaria();
        [TestMethod]
        public void MetodoAgregar()
        {

            string direccion = "Av. Limonita";
            int idestadovet = 3;

            bool resultadoesperado = false;

            bool resultado = veterinaria.Agregar(direccion, idestadovet);
            Assert.AreEqual(resultado, resultadoesperado);
        }
        [TestMethod]
        public void MetodoEditar()
        {
            int idveterinaria = 1;
            string direccion = "Av. Limonita";
            int idestadovet = 3;

            bool resultadoesperado = false;

            bool resultado = veterinaria.Actualizar(idveterinaria,direccion, idestadovet);
            Assert.AreEqual(resultado, resultadoesperado);
        }
        [TestMethod]
        public void MetodoEliminar()
        {
            int idveterinaria = 1;

            bool resultadoesperado = false;

            bool resultado = veterinaria.Eliminar(idveterinaria);
            Assert.AreEqual(resultado, resultadoesperado);
        }
    }
}
