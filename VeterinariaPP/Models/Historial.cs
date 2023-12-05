namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historial")]
    public partial class Historial
    {
        [Key]
        public int IdHistorial { get; set; }

        public int? IdMascota { get; set; }

        public int? IdCita { get; set; }

        public int? IdServicio { get; set; }

        [StringLength(20)]
        public string Fecha { get; set; }

        public virtual Cita Cita { get; set; }

        public virtual Mascota Mascota { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}
