namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleCita")]
    public partial class DetalleCita
    {
        [Key]
        public int IdDetalleCita { get; set; }

        public int? IdCita { get; set; }

        public int? IdServicio { get; set; }

        public virtual Cita Cita { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}
