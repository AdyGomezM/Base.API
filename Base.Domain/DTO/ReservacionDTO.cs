using Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.DTO
{
    public class ReservacionDTO : BaseDTO
    {
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [Required]
        public int CantidadPersonas { get; set; }
        public int? IdHabitacion { get; set; }
        public int? IdPersona { get; set; }
    }
}
