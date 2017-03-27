using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Main_Web_Api.Models
{
    public class PeticionDetalleDTO : PeticionDTO
    {
        public Guid Guid { get; set; }
        public string Fecha { get; set; }
        public bool Procesada { get; set; }
    }
}
