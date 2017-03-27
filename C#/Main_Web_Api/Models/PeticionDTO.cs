using System.ComponentModel.DataAnnotations;

namespace Main_Web_Api.Models
{
    public class PeticionDTO
    {
        public PeticionDTO() { }

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
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        [StringLength(13)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(1000)]
        public string Peticion { get; set; }
    }
}
