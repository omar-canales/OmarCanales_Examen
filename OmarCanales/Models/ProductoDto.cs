using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmarCanales.Models
{
    public class ProductoDto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
    }
}
