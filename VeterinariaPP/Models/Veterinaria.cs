namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Veterinaria")]
    public partial class Veterinaria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Veterinaria()
        {
            Cita = new HashSet<Cita>();
            Compra = new HashSet<Compra>();
            Producto = new HashSet<Producto>();
            Servicio = new HashSet<Servicio>();
            Usuario = new HashSet<Usuario>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        public int IdVeterinaria { get; set; }

        [StringLength(50)]
        public string Direccion { get; set; }

        public int? IdEstadoVeterinaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        public virtual Estado Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servicio> Servicio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }



        public List<Veterinaria> Listar()
        {
            var veterinaria = new List<Veterinaria>();
            string cadena = "SELECT * FROM Veterinaria where IdEstadoVeterinaria=3";
            try
            {
                using (var contenedor = new DB())
                {
                    veterinaria = contenedor.Database.SqlQuery<Veterinaria>(cadena).ToList();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            return veterinaria;
        }


        public List<Veterinaria> BuscarVeterinaria(string dato_busqueda)
        {
            var lista = new List<Veterinaria>();
            string cadena = "SELECT * FROM Veterinaria WHERE Direccion LIKE '%" + dato_busqueda + "%' and IdVeterinaria>0";
            try
            {
                using (var contenedor = new DB())
                {
                    lista = contenedor.Database.SqlQuery<Veterinaria>(cadena).ToList();
                }
            }
            catch (Exception)
            {
                // throw;
            }
            return lista;
        }

        public Boolean Agregar(string Direccion, int IdEstadoVeterinaria)
        {
            bool modelo = false;
            string cadena = "'" + Direccion + "',";
            cadena = cadena + "'" + IdEstadoVeterinaria + "'";
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("INSERT INTO Veterinaria VALUES(" + cadena + ")");

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

        public Veterinaria Consultar(int Id)
        {
            var veterinaria = new Veterinaria();
            try
            {
                using (var conexion = new DB())
                {
                    veterinaria = conexion.Veterinaria.Where(r => r.IdVeterinaria == Id).Single();
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return veterinaria;
        }

        //Actualizar la informacion
        public Boolean Actualizar(int Id, string Direccion, int IdEstadoVeterinaria)
        {
            bool modelo = false;
            string cadena = "Direccion='" + Direccion + "',";
            cadena = cadena + "IdEstadoVeterinaria='" + IdEstadoVeterinaria + "'";
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("UPDATE Veterinaria SET " + cadena + " WHERE IdVeterinaria=" + Id);


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

        public Boolean Eliminar(int Id)
        {
            bool modelo = false;
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("DELETE FROM Vterinaria WHERE IdVeterinaria=" + Id);
                    if (resultado == 1)
                    {
                        modelo = true;
                    }
                }
            }
            catch (Exception)
            {
                modelo = false;

            }
            return modelo;
        }

        public List<Usuario> detalleVeterinaria(string IdVeterinaria)
        {
            var usuario = new List<Usuario>();
            string cadena = "SELECT * From Usuario where IdVeterinaria=" + IdVeterinaria;
            try
            {
                using (var contenedor = new DB())
                {
                    usuario = contenedor.Database.SqlQuery<Usuario>(cadena).ToList();
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return usuario;
        }

    }
}
