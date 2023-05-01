using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppModels;
using AndreTurismoAppTicketService.Data;

namespace AndreTurismoAppTicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly AndreTurismoAppTicketServiceContext _context;

        public TicketController(AndreTurismoAppTicketServiceContext context)
        {
            _context = context;
        }

        // GET: api/Ticket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketModel>>> GetTicketModel()
        {
          if (_context.TicketModel == null)
          {
              return NotFound();
          }
            return await _context.TicketModel.ToListAsync();
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketModel>> GetTicketModel(int id)
        {
          if (_context.TicketModel == null)
          {
              return NotFound();
          }
            var ticketModel = await _context.TicketModel.FindAsync(id);

            if (ticketModel == null)
            {
                return NotFound();
            }

            return ticketModel;
        }

        // PUT: api/Ticket/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketModel(int id, TicketModel ticketModel)
        {
            if (id != ticketModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketModelExists(id))
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

        // POST: api/Ticket
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketModel>> PostTicketModel(TicketModel ticketModel)
        {
          if (_context.TicketModel == null)
          {
              return Problem("Entity set 'AndreTurismoAppTicketServiceContext.TicketModel'  is null.");
          }
            _context.TicketModel.Add(ticketModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketModel", new { id = ticketModel.Id }, ticketModel);
        }

        // DELETE: api/Ticket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketModel(int id)
        {
            if (_context.TicketModel == null)
            {
                return NotFound();
            }
            var ticketModel = await _context.TicketModel.FindAsync(id);
            if (ticketModel == null)
            {
                return NotFound();
            }

            _context.TicketModel.Remove(ticketModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketModelExists(int id)
        {
            return (_context.TicketModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
