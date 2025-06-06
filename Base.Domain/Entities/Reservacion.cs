using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
    [Table("Reservaciones")]
    public class Reservacion : EntityBase
    {
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [Required]
        public int CantidadPersonas { get; set; }
        [ForeignKey("Habitacion")]
        public int? IdHabitacion { get; set; }
        public virtual Habitacion Habitacion { get; set; }
        [ForeignKey("Persona")]
        public int? IdPersona { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
