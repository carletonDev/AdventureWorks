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
    public class ProductDescriptionsController : ControllerBase
    {
        private readonly AdventureWorksContext _context;

        public ProductDescriptionsController(AdventureWorksContext context)
        {
            _context = context;
        }

        // GET: api/ProductDescriptions
        [HttpGet]
        public IEnumerable<ProductDescription> GetProductDescription()
        {
            return _context.ProductDescription;
        }

        // GET: api/ProductDescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDescription = await _context.ProductDescription.FindAsync(id);

            if (productDescription == null)
            {
                return NotFound();
            }

            return Ok(productDescription);
        }

        // PUT: api/ProductDescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDescription([FromRoute] int id, [FromBody] ProductDescription productDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDescription.ProductDescriptionId)
            {
                return BadRequest();
            }

            _context.Entry(productDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDescriptionExists(id))
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

        // POST: api/ProductDescriptions
        [HttpPost]
        public async Task<IActionResult> PostProductDescription([FromBody] ProductDescription productDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductDescription.Add(productDescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDescription", new { id = productDescription.ProductDescriptionId }, productDescription);
        }

        // DELETE: api/ProductDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDescription = await _context.ProductDescription.FindAsync(id);
            if (productDescription == null)
            {
                return NotFound();
            }

            _context.ProductDescription.Remove(productDescription);
            await _context.SaveChangesAsync();

            return Ok(productDescription);
        }

        private bool ProductDescriptionExists(int id)
        {
            return _context.ProductDescription.Any(e => e.ProductDescriptionId == id);
        }
    }
}