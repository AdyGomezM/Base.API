using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
	public class ApplicationUser : IdentityUser
	{
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
    }
}
