namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("DetalleCompra")]
    public partial class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }

        public int? IdCompra { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public int? TotalDetalleCompra { get; set; }

        public virtual Compra Compra { get; set; }

        public virtual Producto Producto { get; set; }


        public List<DetalleCompra> Listar()
        {
            var compras = new List<DetalleCompra>();
            string cadena = "SELECT * From DetalleCompra where IdCompra= (Select MAX(IdCompra) From Compra)";
            try
            {
                using (var contenedor = new DB())
                {
                    compras = contenedor.Database.SqlQuery<DetalleCompra>(cadena).ToList();
                }
            }
            catch (Exception)
            {
                //throw
            }
            return compras;
        }

        public Boolean Crear(int IdProducto, int Cantidad)
        {
            bool modelo = false;
            string IdCompra = "(Select MAX(IdCompra) From Compra)";
            string TotalCompra = "(Select PrecioCompra*" + Cantidad + " From Producto where IdProducto=" + IdProducto + ")";
            string cadena = string.Empty;
            cadena = string.Concat(IdCompra, ",", IdProducto, ",", Cantidad, ",", TotalCompra);


            try
            {
                using (var conexion = new DB())
                {
                    conexion.Database.ExecuteSqlCommand("UPDATE Compra SET TotalCompra= (select TotalCompra+" + TotalCompra +
                    " from Compra WHERE IdCompra = (select max(IdCompra) from Compra)) " +
                    "WHERE IdCompra = (select max(IdCompra) from Compra)");

                    conexion.Database.ExecuteSqlCommand("UPDATE Producto SET Stock= (select Stock+" + Cantidad +
                        " from Producto WHERE IdProducto =" + IdProducto + ")" +
                        "WHERE IdProducto = " + IdProducto);

                    int resultado = conexion.Database.ExecuteSqlCommand("INSERT INTO DetalleCompra VALUES(" + cadena + ")");
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

    }
}
