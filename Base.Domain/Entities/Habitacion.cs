using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
    [Table("Habitaciones")]
	public class Habitacion : EntityBase
	{
        [Required]
        public string Name { get; set; }
        public string UrlImage { get; set; }
        [ForeignKey("Hotel")]
        public int? IdHotel { get; set; }
        public virtual Hotel? Hotel { get; set; }
        public virtual ICollection<Reservacion> Reservaciones { get; set; }
    }
}
