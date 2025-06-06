using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.DTO
{
	public abstract class BaseDTO
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
		public string AppUser { get; set; }
		public DateTime RowVersion { get; set; }
	}

}
