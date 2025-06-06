using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.DTO
{
	public class HotelDTO : BaseDTO
	{
		[MaxLength(50)]
		[Required]
		public string Name { get; set; }
		[DataType(DataType.Url)]
		public string Url { get; set; }
		public string Description { get; set; }
	}
}
