using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCore.Data;
using TestCore.Models;

namespace TestCore.Controllers
{
    [Produces("application/json")]
    [Route("api/blocks")]
    public class BlocksApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlocksApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/blocks
        [HttpGet]
        public IEnumerable<Block> GetBlocks()
        {
            return _context.Blocks;
        }

        // GET: api/blocks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlock([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var block = await _context.Blocks.SingleOrDefaultAsync(m => m.Hash == id);

            if (block == null)
            {
                return NotFound();
            }

            return Ok(block);
        }

        // PUT: api/blocks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlock([FromRoute] string id, [FromBody] Block block)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != block.Hash)
            {
                return BadRequest();
            }

            _context.Entry(block).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockExists(id))
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

        // POST: api/blocks
        [HttpPost]
        public async Task<IActionResult> PostBlock([FromBody] Block block)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Blocks.Add(block);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlock", new { id = block.Hash }, block);
        }

        // DELETE: api/blocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlock([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var block = await _context.Blocks.SingleOrDefaultAsync(m => m.Hash == id);
            if (block == null)
            {
                return NotFound();
            }

            _context.Blocks.Remove(block);
            await _context.SaveChangesAsync();

            return Ok(block);
        }

        private bool BlockExists(string id)
        {
            return _context.Blocks.Any(e => e.Hash == id);
        }
    }
}