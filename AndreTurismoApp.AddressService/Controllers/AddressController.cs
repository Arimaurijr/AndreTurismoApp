using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp._AddressService.Data;
using AndreTurismoAppModels;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AndreTurismoApp._AddressService.Service;
using System.Net;

namespace AndreTurismoApp._AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AndreTurismoAppAddressServiceContext _context;
        private readonly PostOfficeService _postOfficeService;  

        public AddressController(AndreTurismoAppAddressServiceContext context, PostOfficeService postOfficeService)
        {
            _context = context;
            _postOfficeService = postOfficeService;
        }

        // GET: api/AddressModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressModel>>> GetAddressModel()
        {
            if (_context.AddressModel == null)
            {
                return NotFound();
            }
            return await _context.AddressModel.Include(a=> a.Cidade).ToListAsync();
        }
        [HttpGet("{cep:length(8)}", Name = "GetAddress_1")]
        public AddressDTO GetPostOffices(string cep)
        {
            //Exemplo de chamada de serviço - TESTE
            return _postOfficeService.GetAddress(cep).Result;
        }


        // GET: api/AddressModels/5

        [HttpGet("{id}", Name = "GetAddress_2")]
        public async Task<ActionResult<AddressModel>> GetAddressModel_2(int id)
        {
            if (_context.AddressModel == null)
            {
                return NotFound();
            }
            var addressModel = await _context.AddressModel.Include(a => a.Cidade).Where(a=> a.Id == id).FirstOrDefaultAsync();

            if (addressModel == null)
            {
                return NotFound();
            }

            return addressModel;

        } 
      
        // PUT: api/AddressModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressModel(int id, AddressModel addressModel)
        {
            if (id != addressModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressModel).State = EntityState.Modified;
            _context.AddressModel.Update(addressModel);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressModelExists(id))
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

        // POST: api/AddressModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{CEP},{Numero}")]
        public async Task<ActionResult<AddressModel>> PostAddressModel(string CEP, string Numero, AddressModel addressModel)
        {
          if (_context.AddressModel == null)
          {
              return Problem("Entity set 'AndreTurismoAppAddressServiceContext.AddressModel'  is null.");
          }

          AddressDTO endereco =  await _postOfficeService.GetAddress(CEP);
          AddressModel enderecoModel = new AddressModel(endereco);
          enderecoModel.CEP = CEP;
          _context.AddressModel.Add(enderecoModel);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetAddressModel", new { id = enderecoModel.Id }, enderecoModel);
        }

        // DELETE: api/AddressModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressModel(int id)
        {
            if (_context.AddressModel == null)
            {
                return NotFound();
            }
            var addressModel = await _context.AddressModel.FindAsync(id);
            if (addressModel == null)
            {
                return NotFound();
            }

            _context.AddressModel.Remove(addressModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressModelExists(int id)
        {
            return (_context.AddressModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
