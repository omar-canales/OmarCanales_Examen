using OmarCanales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmarCanales.Models
{
    public class Persistencia : IPersistencia
    {
        private List<Producto> productos;
        public List<Producto> Productos
        {
            get
            {
                if (productos == null)
                    productos = new List<Producto>();
                return productos;
            }

            set { productos = value; }
        }
    }
}