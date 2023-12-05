namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Compra")]
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            DetalleCompra = new HashSet<DetalleCompra>();
        }

        [Key]
        public int IdCompra { get; set; }

        public int? IdProveedor { get; set; }

        public int? IdEmpleado { get; set; }

        [StringLength(20)]
        public string NumComprobante { get; set; }

        public object Crear(Compra idproveedor, Compra idempleado, Compra comprobante, Compra tipopago, Compra fecha, Compra idveterinaria)
        {
            throw new NotImplementedException();
        }

        [StringLength(50)]
        public string TipoPago { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public int? TotalCompra { get; set; }

        public int? IdVeterinaria { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Veterinaria Veterinaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }


        public List<Compra> Listar()
        {
            var compras = new List<Compra>();
            string cadena = "SELECT * From Compra";
            try
            {
                using (var contenedor = new DB())
                {
                    compras = contenedor.Database.SqlQuery<Compra>(cadena).ToList();
                }
            }
            catch (Exception)
            {
                //throw
            }
            return compras;
        }


        public Boolean Crear(int IdProveedor, int IdEmpleado, string NumComprobante, string TipoPago, string Fecha, int IdVeterinaria)
        {
            bool modelo = false;
            Double TotalCompra = 0;
            string cadena = string.Empty;
            cadena = string.Concat(IdProveedor, ",", IdEmpleado, ",'", NumComprobante, "','", TipoPago, "','", Fecha, "',", TotalCompra, ",", IdVeterinaria);

            try
            {
                using (var conexion = new DB())
                {
                    int resultado = conexion.Database.ExecuteSqlCommand("INSERT INTO Compra VALUES(" + cadena + ")");
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

        public Compra Consultar(int Id)
        {
            var registro = new Compra();

            try
            {
                using (var conexion = new DB())
                {
                    registro = conexion.Compra.Where(i => i.IdCompra == Id).Single();

                }
            }
            catch (Exception)
            {
                //throw
            }
            return registro;
        }
    }
}
