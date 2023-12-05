namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;


    [Table("Proveedor")]
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            Compra = new HashSet<Compra>();
        }

        [Key]
        public int IdProveedor { get; set; }

        [StringLength(50)]
        public string NombreProveedor { get; set; }

        [StringLength(8)]
        public string DNI { get; set; }

        public int? Celular { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        public int? IdEstadoProveedor { get; set; }

        public int? IdCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        public virtual Estado Estado { get; set; }


        public List<string> Errores { get; private set; }

        #region Listas
        public List<Proveedor> Listar()
        {
            var proveedor = new List<Proveedor>();
            string cadena = "SELECT * FROM Proveedor where IdEstadoProveedor != 14";
            try
            {
                using (var contenedor = new DB())
                {
                    proveedor = contenedor.Database.SqlQuery<Proveedor>(cadena).ToList();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            return proveedor;
        }
        #endregion
        #region Buscar Proveedor
        //-------------Buscar proveedor por Nombre-------------------
        public List<Proveedor> BuscarProveedor(string dato_busqueda)
        {
            var lista = new List<Proveedor>();
            string cadena = "SELECT * FROM Proveedor WHERE NombreProveedor LIKE '%" + dato_busqueda + "%'";
            try
            {
                using (var contenedor = new DB())
                {
                    lista = contenedor.Database.SqlQuery<Proveedor>(cadena).ToList();
                }
            }
            catch (Exception)
            {
                // throw;
            }
            return lista;
        }
        #endregion

        #region Crear Proveedor
        public Boolean Agregar(string NombreProveedor, string DNI, int Celular, string Email, int IdEstadoProveedor, int IdCategoria)
        {
            
            bool modelo = false;
            string cadena = "'" + NombreProveedor + "',";
            cadena = cadena + "'" + DNI + "',";
            cadena = cadena + "'" + Celular + "',";
            cadena = cadena + "'" + Email + "',";
            cadena = cadena + "'" + IdEstadoProveedor + "',";
            cadena = cadena + "'" + IdCategoria + "'";
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("INSERT INTO Proveedor VALUES(" + cadena + ")");

                    if (resultado == 1)
                    {
                        modelo = true;
                    }
                }
            }
            catch (Exception)
            {
                modelo = false;
                //throw;
            }
            return modelo;
            
        }
        #endregion
        #region Editar Proveedor
        //Consultar informacion
        public Proveedor Consultar(int Id)
        {
            var proveedor = new Proveedor();
            try
            {
                using (var conexion = new DB())
                {
                    proveedor = conexion.Proveedor.Where(r => r.IdProveedor == Id).Single();
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return proveedor;
        }

        //Actualizar la informacion
        public Boolean Actualizar(int Id, string NombreProveedor, string DNI, int Celular, string Email, int IdEstadoProveedor, int IdCategoria)
        {
            bool modelo = false;
            string cadena = "NombreProveedor='" + NombreProveedor + "',";
            cadena = cadena + "DNI='" + DNI + "',";
            cadena = cadena + "Celular='" + Celular + "',";
            cadena = cadena + "Email='" + Email + "',";
            cadena = cadena + "IdEstadoProveedor='" + IdEstadoProveedor + "',";
            cadena = cadena + "IdCategoria='" + IdCategoria + "'";
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("UPDATE Proveedor SET " + cadena + " WHERE IdProveedor=" + Id);


                    if (resultado == 1)
                    {
                        modelo = true;
                    }
                }
            }
            catch (Exception)
            {
                modelo = false;
                //throw;
            }
            return modelo;
        }
        #endregion
        #region Eliminar Proveedor
        public Boolean Eliminar(int Id)
        {
            bool modelo = false;
            string cadena = "IdEstadoProveedor='14'";
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("DELETE FROM Proveedor WHERE IdProveedor=" + Id);
                    if (resultado == 1)
                    {
                        modelo = true;
                    }
                }
            }
            catch (Exception)
            {
                modelo = false;
                using (var conexion = new DB())
                {
                    conexion.Database.ExecuteSqlCommand("UPDATE Producto SET " + cadena + " WHERE IdProveedor=" + Id);

                }
            }
            return modelo;
        }
        #endregion
    }
}
