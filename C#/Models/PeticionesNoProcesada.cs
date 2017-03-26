namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PeticionesNoProcesada
    {
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string Apellido { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Correo { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string Telefono { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(11)]
        public string Cedula { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime Fecha { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(1000)]
        public string Peticion { get; set; }
    }
}
