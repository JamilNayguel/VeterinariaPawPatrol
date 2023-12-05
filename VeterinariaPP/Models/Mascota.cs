namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mascota")]
    public partial class Mascota
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mascota()
        {
            Cita = new HashSet<Cita>();
            Historial = new HashSet<Historial>();
        }

        [Key]
        public int IdMascota { get; set; }

        public int? IdDueño { get; set; }

        [StringLength(50)]
        public string NombreMacota { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Sexo { get; set; }

        [StringLength(50)]
        public string Raza { get; set; }

        [StringLength(50)]
        public string Edad { get; set; }

        [StringLength(50)]
        public string Peso { get; set; }

        public int? IdEstadoMascota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        public virtual Estado Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historial> Historial { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
