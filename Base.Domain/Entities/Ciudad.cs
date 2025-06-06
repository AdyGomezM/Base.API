using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
    public class Ciudad : EntityBase
    {
        public string Nombre { get; set; }
        public string Estado { get; set; }    
        public string Pais { get; set; }

    }
}
