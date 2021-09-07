using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OmarCanales.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required, Range(0, double.MaxValue)]
        public double Precio { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Cantidad { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
