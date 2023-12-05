namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Venta")]
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        public int IdVenta { get; set; }

        public int? IdEmpleado { get; set; }

        public int? DNICliente { get; set; }

        [StringLength(50)]
        public string TipoPago { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public int? TotalVenta { get; set; }

        public int? IdVeterinaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Veterinaria Veterinaria { get; set; }
    }
}
