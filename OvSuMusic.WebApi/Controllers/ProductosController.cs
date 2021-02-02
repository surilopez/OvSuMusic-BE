using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OvSuMusic.Data;
using OvSuMusic.Data.Contracts;
using OvSuMusic.Models;

namespace OvSuMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProductosRepo productosRepo;

        public ProductosController(IProductosRepo productosRepo)
        {
            this.productosRepo = productosRepo;
        }

        // GET: api/Productos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            try
            {
                return await productosRepo.ObtenerProductosAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var product = await productosRepo.ObtenerProductoAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Productos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            try
            {
                var newProduct = await productosRepo.Agregar(producto);
                if (newProduct == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(Post), new { id = newProduct.Id }, producto);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        //PUT api/productos/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    return NotFound();
                }

                var result = await productosRepo.Actualizar(producto);
                if (!result)
                    return BadRequest();

                return producto;
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        //DELETE: api/Productos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await productosRepo.Eliminar(id);
                if (!result)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

    }
}
