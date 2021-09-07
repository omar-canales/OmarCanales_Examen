using OmarCanales.Interfaces;
using OmarCanales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmarCanales.Application
{
    public class ProductoApplication : IProductoApplication
    {
        private IPersistencia _persistencia;
        public ProductoApplication(IPersistencia persistencia)
        {
            _persistencia = persistencia;
        }

        public async Task<Producto> Actualizar(Producto producto, int productoId)
        {
            try
            {
                var nuevaLista = Task.Run(() => _persistencia.Productos.Where(p => p.ProductoId != productoId));
                _persistencia.Productos = nuevaLista.Result.ToList();
                _persistencia.Productos.Add(producto);
                return _persistencia.Productos.FirstOrDefault(p => p.ProductoId == producto.ProductoId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el producto {producto.Nombre}, error: {ex.Message}");
            }
        }

        public async Task<int> AgregarProducto(ProductoDto producto)
        {
            try
            {
                var ultimoId = _persistencia.Productos.Count() > 0 ? _persistencia.Productos.Max(p => p.ProductoId) : 0;

                _persistencia.Productos.Add(new Producto
                {
                    ProductoId = ultimoId + 1,
                    Cantidad = producto.Cantidad,
                    Categoria = producto.Categoria,
                    Descripcion = producto.Descripcion,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio
                });

                return _persistencia.Productos.LastOrDefault(p => p != null).ProductoId;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el producto {producto.Nombre}, error: {ex.Message}");
            }
        }

        public async Task<bool> EliminarProducto(int productoId)
        {
            try
            {
                var nuevaLista = Task.Run(() => _persistencia.Productos.Where(p => p.ProductoId != productoId));
                _persistencia.Productos = nuevaLista.Result.ToList();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al eliminar el producto id {productoId}, error: {ex.Message}");
            }
        }

        public async Task<Producto> ObtenerProducto(int productoId)
        {
            try
            {
                var response = Task.Run(() => _persistencia.Productos.FirstOrDefault(p =>
                                                                        p.ProductoId == productoId)).Result;

                return response != null ? response :
                    throw new ApplicationException($"No se encontró el producto con el Id: {productoId}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el producto Id: {productoId}, error: {ex.Message}");
            }
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            try
            {
                return Task.Run(() => _persistencia.Productos).Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener la lista de productos, error: {ex.Message}");
            }
        }
    }
}
