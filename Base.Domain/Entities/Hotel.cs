using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
    [Table("Hoteles")]
	public class Hotel : EntityBase
	{
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Url)]
        public string Url { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Habitacion> Habitaciones { get; set; }
    }
}
