using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.DTO
{
    public class TourDTO : BaseDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
   
    
    }
}
