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
    public class ErrorLogsController : ControllerBase
    {
        private readonly AdventureWorksContext _context;

        public ErrorLogsController(AdventureWorksContext context)
        {
            _context = context;
        }

        public ErrorLogsController()
        {
        }

        // GET: api/ErrorLogs
        [HttpGet]
        public IEnumerable<ErrorLog> GetErrorLog()
        {
            return _context.ErrorLog;
        }

        // GET: api/ErrorLogs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetErrorLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var errorLog = await _context.ErrorLog.FindAsync(id);

            if (errorLog == null)
            {
                return NotFound();
            }

            return Ok(errorLog);
        }

        // PUT: api/ErrorLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErrorLog([FromRoute] int id, [FromBody] ErrorLog errorLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != errorLog.ErrorLogId)
            {
                return BadRequest();
            }

            _context.Entry(errorLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorLogExists(id))
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

        // POST: api/ErrorLogs
        [HttpPost]
        public async Task<IActionResult> PostErrorLog([FromBody] ErrorLog errorLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ErrorLog.Add(errorLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErrorLog", new { id = errorLog.ErrorLogId }, errorLog);
        }

        // DELETE: api/ErrorLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErrorLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var errorLog = await _context.ErrorLog.FindAsync(id);
            if (errorLog == null)
            {
                return NotFound();
            }

            _context.ErrorLog.Remove(errorLog);
            await _context.SaveChangesAsync();

            return Ok(errorLog);
        }

        private bool ErrorLogExists(int id)
        {
            return _context.ErrorLog.Any(e => e.ErrorLogId == id);
        }
    }
}