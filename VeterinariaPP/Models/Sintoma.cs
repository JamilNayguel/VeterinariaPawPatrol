namespace VeterinariaPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sintoma")]
    public partial class Sintoma
    {
        [Key]
        public int IdSintoma { get; set; }

        public int? IdCita { get; set; }

        [StringLength(50)]
        public string NombreSintoma { get; set; }

        public virtual Cita Cita { get; set; }
    }
}
