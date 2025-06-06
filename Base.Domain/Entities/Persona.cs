using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
    [Table("Personas")]
    public class Persona : EntityBase
    {
        [Required]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string RFC { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public virtual ICollection<Reservacion> Reservaciones { get; set; }
    }
}
