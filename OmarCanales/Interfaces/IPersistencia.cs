using OmarCanales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmarCanales.Interfaces
{
    public interface IPersistencia
    {
        public List<Producto> Productos { get; set; }
    }
}
