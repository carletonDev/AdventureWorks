using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductModelProductDescriptionsController : ControllerBase
    {
        private readonly AdventureWorksContext _context;

        public ProductModelProductDescriptionsController(AdventureWorksContext context)
        {
            _context = context;
        }

        // GET: api/ProductModelProductDescriptions
        [HttpGet]
        public IEnumerable<ProductModelProductDescription> GetProductModelProductDescription()
        {
            return _context.ProductModelProductDescription;
        }

        // GET: api/ProductModelProductDescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductModelProductDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productModelProductDescription = await _context.ProductModelProductDescription.FindAsync(id);

            if (productModelProductDescription == null)
            {
                return NotFound();
            }

            return Ok(productModelProductDescription);
        }

        // PUT: api/ProductModelProductDescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModelProductDescription([FromRoute] int id, [FromBody] ProductModelProductDescription productModelProductDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productModelProductDescription.ProductModelId)
            {
                return BadRequest();
            }

            _context.Entry(productModelProductDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelProductDescriptionExists(id))
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

        // POST: api/ProductModelProductDescriptions
        [HttpPost]
        public async Task<IActionResult> PostProductModelProductDescription([FromBody] ProductModelProductDescription productModelProductDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductModelProductDescription.Add(productModelProductDescription);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductModelProductDescriptionExists(productModelProductDescription.ProductModelId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductModelProductDescription", new { id = productModelProductDescription.ProductModelId }, productModelProductDescription);
        }

        // DELETE: api/ProductModelProductDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModelProductDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productModelProductDescription = await _context.ProductModelProductDescription.FindAsync(id);
            if (productModelProductDescription == null)
            {
                return NotFound();
            }

            _context.ProductModelProductDescription.Remove(productModelProductDescription);
            await _context.SaveChangesAsync();

            return Ok(productModelProductDescription);
        }

        private bool ProductModelProductDescriptionExists(int id)
        {
            return _context.ProductModelProductDescription.Any(e => e.ProductModelId == id);
        }
    }
}