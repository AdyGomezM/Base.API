using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
    public class Tour : EntityBase
    {
        public string Name { get; set;}
        public string Descripcion { get; set; } 
        public decimal Precio { get; set; }
       
    }
}
