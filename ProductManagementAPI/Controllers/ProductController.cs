using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Core;
using ProductManagement.DataContext;
using ProductManagement.Services;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _Service;

        public ProductController(IProductService service)
        {
            _Service = service;
        }

        // GET: api/Product/List/{pageNumber}/{pageSize}
        [HttpGet("List/{pageNumber}/{pageSize?}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int pageNumber = 1, int pageSize = 25)
        {
            try
            {
                var lst = await _Service.Get(pageNumber, pageSize);
                int i = 1;
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _Service.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                await _Service.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_Service.Get(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                await _Service.Create(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _Service.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            await _Service.Delete(product);
            
            return NoContent();
        }
    }
}
