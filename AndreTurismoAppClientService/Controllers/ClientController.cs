using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppClientService.Data;
using AndreTurismoAppModels;

namespace AndreTurismoAppClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AndreTurismoAppClientServiceContext _context;

        public ClientController(AndreTurismoAppClientServiceContext context)
        {
            _context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> GetClientModel()
        {
            if (_context.ClientModel == null)
            {
                return NotFound();
            }
            try
            {
                var client = await _context.ClientModel.Include(c => c.Endereco).Include(c=> c.Endereco.Cidade).ToListAsync();
                return client;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            
            
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetClientModel(int id)
        {
          if (_context.ClientModel == null)
          {
              return NotFound();
          }
            var clientModel = await _context.ClientModel.FindAsync(id);

            if (clientModel == null)
            {
                return NotFound();
            }

            return clientModel;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientModel(int id, ClientModel clientModel)
        {
            if (id != clientModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientModelExists(id))
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

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientModel>> PostClientModel(ClientModel clientModel)
        {
          if (_context.ClientModel == null)
          {
              return Problem("Entity set 'AndreTurismoAppClientServiceContext.ClientModel'  is null.");
          }
          
          var endereco = await _context.AddressModel.FindAsync(clientModel.Endereco.Id);
          if(endereco == null)
          {
                //return NoContent();
                _context.AddressModel.Add(clientModel.Endereco);
                endereco = clientModel.Endereco;
          }
          
          clientModel.Endereco = endereco;
         
          _context.ClientModel.Add(clientModel);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetClientModel", new { id = clientModel.Id }, clientModel);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientModel(int id)
        {
            if (_context.ClientModel == null)
            {
                return NotFound();
            }
            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }

            _context.ClientModel.Remove(clientModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientModelExists(int id)
        {
            return (_context.ClientModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
