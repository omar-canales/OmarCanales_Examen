using OmarCanales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmarCanales.Interfaces
{
    public interface IProductoApplication
    {
        public Task<int> AgregarProducto(ProductoDto producto);
        public Task<bool> EliminarProducto(int productoId);
        public Task<Producto> Actualizar(Producto producto, int productoId);
        public Task<List<Producto>> ObtenerProductos();
        public Task<Producto> ObtenerProducto(int productoId);
    }
}

