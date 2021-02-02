using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OvSuMusic.Data;
using OvSuMusic.Data.Contracts;
using OvSuMusic.Dtos;
using OvSuMusic.Models;

namespace OvSuMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProductosRepo _productosRepo;
        private readonly IMapper _mapper;

        public ProductosController(IProductosRepo productosRepo, IMapper mapper )
        {
            this._productosRepo = productosRepo;
            this._mapper = mapper;
        }

        // GET: api/Productos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> Get()
        {
            try
            {
                var productos= await _productosRepo.ObtenerProductosAsync();
                return _mapper.Map<List<ProductoDto>>(productos);
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
        public async Task<ActionResult<ProductoDto>> Get(int id)
        {
            var product = await _productosRepo.ObtenerProductoAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return  _mapper.Map<ProductoDto>(product);
        }

        // POST: api/Productos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Post(ProductoDto productoDto)
        {
            try
            {
                var prod = _mapper.Map<Producto>(productoDto);
                var newProduct = await _productosRepo.Agregar(prod);
                if (newProduct == null)
                {
                    return BadRequest();
                }

                var newProductDto= _mapper.Map<ProductoDto>(prod);
                return CreatedAtAction(nameof(Post), new { id = newProductDto.Id }, newProductDto);
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
        public async Task<ActionResult<ProductoDto>> Put(int id, [FromBody] ProductoDto productoDto)
        {
            try
            {
                if (productoDto == null)
                {
                    return NotFound();
                }
                var producto = _mapper.Map<Producto>(productoDto);
                var result = await _productosRepo.Actualizar(producto);
                if (!result)
                    return BadRequest();

                return productoDto;
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
                var result = await _productosRepo.Eliminar(id);
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
