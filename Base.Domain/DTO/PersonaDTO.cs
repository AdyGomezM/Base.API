using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.DTO
{
    public class PersonaDTO : BaseDTO
    {
        [Required]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string RFC { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
