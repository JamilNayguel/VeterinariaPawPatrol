namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Cita = new HashSet<Cita>();
            Compra = new HashSet<Compra>();
            Mascota = new HashSet<Mascota>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        public int IdUsuario { get; set; }

        [StringLength(50)]
        public string NombreUsuario { get; set; }

        public int? Celular { get; set; }

        [StringLength(30)]
        public string Correo { get; set; }

        [StringLength(200)]
        public string Contrasena { get; set; }

        public int IdPrivilegio { get; set; }

        public int IdEstadoUsuario { get; set; }

        public int? IdVeterinaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        public virtual Estado Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mascota> Mascota { get; set; }

        public virtual Privilegio Privilegio { get; set; }

        public virtual Veterinaria Veterinaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }


        #region Listas
        public List<Usuario> Listar()
        {
            var usuario = new List<Usuario>();
            string cadena = "SELECT * FROM Usuario where IdPrivilegio!=4 and IdEstadoUsuario=15";
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
        #endregion
        #region Buscar Usuario
        public List<Usuario> BuscarUsuario(string dato_busqueda)
        {
            var lista = new List<Usuario>();
            string cadena = "SELECT * FROM Usuario WHERE NombreUsuario LIKE '%" + dato_busqueda + "%' and IdPrivilegio!=4";
            try
            {
                using (var contenedor = new DB())
                {
                    lista = contenedor.Database.SqlQuery<Usuario>(cadena).ToList();
                }
            }
            catch (Exception)
            {
                // throw;
            }
            return lista;
        }
        #endregion
        #region Crear Usuario
        public Boolean Agregar(string NombreUsuario, int Celular, string Correo, string Contrasena, int IdPrivilegio, int IdEstadoUsuario, int IdVeterinaria)
        {
            bool modelo = false;
            string cadena = "'" + NombreUsuario + "',";
            cadena = cadena + "'" + Celular + "',";
            cadena = cadena + "'" + Correo + "',";
            cadena = cadena + "'" + Contrasena + "',";
            cadena = cadena + "'" + IdPrivilegio + "',";
            cadena = cadena + "'" + IdEstadoUsuario + "',";
            cadena = cadena + "'" + IdVeterinaria + "'";
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("INSERT INTO Usuario VALUES(" + cadena + ")");

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
        #region Editar Usuario
        //Consultar informacion
        public Usuario Consultar(int Id)
        {
            var usuario = new Usuario();
            try
            {
                using (var conexion = new DB())
                {
                    usuario = conexion.Usuario.Where(r => r.IdUsuario == Id).Single();
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return usuario;
        }

        //Actualizar la informacion
        public Boolean Actualizar(int Id, string NombreUsuario, int Celular, string Correo, string Contrasena, int IdPrivilegio, int IdEstadoUsuario, int IdVeterinaria)
        {
            bool modelo = false;
            string cadena = "NombreUsuario='" + NombreUsuario + "',";
            cadena = cadena + "Celular='" + Celular + "',";
            cadena = cadena + "Correo='" + Correo + "',";
            cadena = cadena + "Contrasena='" + Contrasena + "',";
            cadena = cadena + "IdPrivilegio='" + IdPrivilegio + "',";
            cadena = cadena + "IdEstadoUsuario='" + IdEstadoUsuario + "',";
            cadena = cadena + "IdVeterinaria='" + IdVeterinaria + "'";
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("UPDATE Usuario SET " + cadena + " WHERE IdUsuario=" + Id);


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
        #region Eliminar Usuario
        public Boolean Eliminar(int Id)
        {
            bool modelo = false;
            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("DELETE FROM Usuario WHERE IdUsuario=" + Id);
                    if (resultado == 1)
                    {
                        modelo = true;
                    }
                }
            }
            catch (Exception)
            {
                using (var conexion = new DB())
                {
                    conexion.Database.ExecuteSqlCommand("UPDATE Usuario SET IdEstadoUsuario=14 WHERE IdUsuario=" + Id);
                }
                modelo = false;

            }
            return modelo;
        }
        #endregion

    }
}
