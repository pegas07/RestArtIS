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
    public class BusinessPartnersController : ControllerBase
    {
        private readonly RestArtISContext _context;

        public BusinessPartnersController(RestArtISContext context)
        {
            _context = context;
        }

        // GET: api/BusinessPartners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessPartner>>> GetBusinessPartner()
        {
            return await _context.BusinessPartner.ToListAsync();
        }

        // GET: api/BusinessPartners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessPartner>> GetBusinessPartner(Guid id)
        {
            var businessPartner = await _context.BusinessPartner.FindAsync(id);

            if (businessPartner == null)
            {
                return NotFound();
            }

            return businessPartner;
        }

        // PUT: api/BusinessPartners/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessPartner(Guid id, BusinessPartner businessPartner)
        {
            if (id != businessPartner.BusinessPartnerId)
            {
                return BadRequest();
            }

            _context.Entry(businessPartner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessPartnerExists(id))
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

        // POST: api/BusinessPartners
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessPartner>> PostBusinessPartner(BusinessPartner businessPartner)
        {
            _context.BusinessPartner.Add(businessPartner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusinessPartnerExists(businessPartner.BusinessPartnerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBusinessPartner", new { id = businessPartner.BusinessPartnerId }, businessPartner);
        }

        // DELETE: api/BusinessPartners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessPartner>> DeleteBusinessPartner(Guid id)
        {
            var businessPartner = await _context.BusinessPartner.FindAsync(id);
            if (businessPartner == null)
            {
                return NotFound();
            }

            _context.BusinessPartner.Remove(businessPartner);
            await _context.SaveChangesAsync();

            return businessPartner;
        }

        private bool BusinessPartnerExists(Guid id)
        {
            return _context.BusinessPartner.Any(e => e.BusinessPartnerId == id);
        }
    }
}
