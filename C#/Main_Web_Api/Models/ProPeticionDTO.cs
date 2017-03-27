using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Main_Web_Api.Models
{
    public class ProPeticionDTO
    {
        public ProPeticionDTO() { }

        public Guid Guid { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(12)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        public string Correo { get; set; }
        [Required]
        [StringLength(13)]
        public string Cedula { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        [StringLength(1000)]
        public string Peticion { get; set; }
    }
}
