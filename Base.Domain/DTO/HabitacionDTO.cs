using Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Base.Domain.DTO
{
	public class HabitacionDTO: BaseDTO
	{
		[Required]
		public string Name { get; set; }
		public string UrlImage { get; set; }
		[ForeignKey("Hotel")]
		public int? IdHotel { get; set; }
	}
}
