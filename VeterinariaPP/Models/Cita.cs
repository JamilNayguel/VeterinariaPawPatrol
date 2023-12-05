namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cita")]
    public partial class Cita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cita()
        {
            DetalleCita = new HashSet<DetalleCita>();
            Historial = new HashSet<Historial>();
            Sintoma = new HashSet<Sintoma>();
        }

        [Key]
        public int IdCita { get; set; }

        public int? IdDueño { get; set; }

        public int? IdMascota { get; set; }

        [StringLength(10)]
        public string Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        public int? IdEstadoCita { get; set; }

        public int? IdVeterinaria { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Mascota Mascota { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Veterinaria Veterinaria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCita> DetalleCita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historial> Historial { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sintoma> Sintoma { get; set; }
    }
}
