using AndreTurismoApp.Service;
using AndreTurismoAppModels;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp._AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _address;
        public AddressController(AddressService address)
        {
            _address = address;
        }

        // GET: api/AddressModels
        [HttpGet]
        public async Task<List<AddressModel>> GetAddressModel()
        {
            return await _address.GetAddress();
        }
        [HttpGet("{id}")]
        public async Task<AddressModel> GetAddressModelID(int id)
        {
            return await _address.GetAddressID(id);
        }
        [HttpDelete("{id}")]
        public async void DeleteAddressID(int id)
        {
            _address.DeleteAddressID(id);
        }
        [HttpPost("{CEP}, {Numero}")]
        public async void PostAddress(string CEP, string Numero, AddressModel addressModel)
        {
            _address.PostAddress(CEP,Numero,addressModel);
        }
        [HttpPut("{id}")]
        public async void PutAddress(int id, AddressModel address)
        {
            _address.PutAddress(id,address);
        }
        /*
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
            var addressModel = await _context.AddressModel.FindAsync(id);

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
        */
    }
}
