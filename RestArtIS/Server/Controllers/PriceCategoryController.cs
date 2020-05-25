using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestArtIS.Server.Data;
using RestArtIS.Server.Models;

namespace RestArtIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceCategoryController : ControllerBase
    {
        private readonly RestArtISContext _context;

        public PriceCategoryController(RestArtISContext context)
        {
            _context = context;
        }

        // GET: api/PriceCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceCategory>>> GetPriceCategory()
        {
            return await _context.PriceCategory.ToListAsync();
        }

        // GET: api/PriceCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceCategory>> GetPriceCategory(Guid id)
        {
            var priceCategory = await _context.PriceCategory.FindAsync(id);

            if (priceCategory == null)
            {
                return NotFound();
            }

            return priceCategory;
        }

        // PUT: api/PriceCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceCategory(Guid id, PriceCategory priceCategory)
        {
            if (id != priceCategory.PriceCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(priceCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceCategoryExists(id))
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

        // POST: api/PriceCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PriceCategory>> PostPriceCategory(PriceCategory priceCategory)
        {
            _context.PriceCategory.Add(priceCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PriceCategoryExists(priceCategory.PriceCategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPriceCategory", new { id = priceCategory.PriceCategoryId }, priceCategory);
        }

        // DELETE: api/PriceCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PriceCategory>> DeletePriceCategory(Guid id)
        {
            var priceCategory = await _context.PriceCategory.FindAsync(id);
            if (priceCategory == null)
            {
                return NotFound();
            }

            _context.PriceCategory.Remove(priceCategory);
            await _context.SaveChangesAsync();

            return priceCategory;
        }

        private bool PriceCategoryExists(Guid id)
        {
            return _context.PriceCategory.Any(e => e.PriceCategoryId == id);
        }
    }
}
