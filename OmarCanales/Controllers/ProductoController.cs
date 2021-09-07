using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmarCanales.Interfaces;
using OmarCanales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmarCanales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoApplication _productoApplication { get; set; }
        public ProductoController(IProductoApplication productoApplication)
        {
            _productoApplication = productoApplication;
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="List{T}<"/></returns>
        [HttpGet, Route("")]
        [ProducesResponseType(typeof(List<Producto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Producto>>> ObtenerProductos()
        {
            try
            {
                var resp = await _productoApplication.ObtenerProductos();

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un poducto por ProductoId
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="List{T}<"/></returns>
        [HttpGet, Route("{productoId}")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> ObtenerProducto(int productoId)
        {
            try
            {
                var resp = await _productoApplication.ObtenerProducto(productoId);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Eliminar un poducto por ProductoId
        /// </summary>
        /// <returns>Regresa objeto de tipo <see cref="bool<"/></returns>
        [HttpDelete, Route("{productoId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> EliminarProducto(int productoId)
        {
            try
            {
                var resp = await _productoApplication.EliminarProducto(productoId);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Permite agregar un producto
        /// </summary>
        /// <param name="payload">Parametro de tipo <see cref="Producto"/>.Modelo para agregar un producto</param>
        /// <returns>Regresa objeto de tipo <see cref="{T}<"/></returns>
        [HttpPost, Route("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AgregarProducto(ProductoDto payload)
        {
            try
            {
                var resp = _productoApplication.AgregarProducto(payload);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
