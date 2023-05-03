using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAppModels;
using AndreTurismoAppPackageService.Data;

namespace AndreTurismoAppPackageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly AndreTurismoAppPackageServiceContext _context;

        public PackageController(AndreTurismoAppPackageServiceContext context)
        {
            _context = context;
        }

        // GET: api/Package
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageModel>>> GetPackageModel()
        {
          if (_context.PackageModel == null)
          {
              return NotFound();
          }
            return await _context.PackageModel.ToListAsync();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageModel>> GetPackageModel(int id)
        {
          if (_context.PackageModel == null)
          {
              return NotFound();
          }
            var packageModel = await _context.PackageModel.FindAsync(id);

            if (packageModel == null)
            {
                return NotFound();
            }

            return packageModel;
        }

        // PUT: api/Package/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackageModel(int id, PackageModel packageModel)
        {
            if (id != packageModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(packageModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageModelExists(id))
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

        // POST: api/Package
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PackageModel>> PostPackageModel(PackageModel packageModel)
        {
          if (_context.PackageModel == null)
          {
              return Problem("Entity set 'AndreTurismoAppPackageServiceContext.PackageModel'  is null.");
          }

          //Cliente
          //Endereco

          var endereco = await _context.AddressModel.FindAsync(packageModel.Cliente_Pacote.Endereco.Id);
          if (endereco == null)
          {
                _context.AddressModel.Add(packageModel.Cliente_Pacote.Endereco);
                endereco = packageModel.Cliente_Pacote.Endereco;
          }
           packageModel.Cliente_Pacote.Endereco = endereco;
         
          var cliente = await _context.ClientModel.FindAsync(packageModel.Cliente_Pacote.Id);
          if (cliente == null)
          {
                _context.ClientModel.Add(packageModel.Cliente_Pacote);
                cliente = packageModel.Cliente_Pacote;
          }
          packageModel.Cliente_Pacote = cliente;

        ///hotel 
        // endereco hotel
         endereco = await _context.AddressModel.FindAsync(packageModel.Hotel_Pacote.Endereco.Id);
         if(endereco == null)
         {
                _context.AddressModel.Add(packageModel.Hotel_Pacote.Endereco);
                endereco = packageModel.Hotel_Pacote.Endereco;
         }
         packageModel.Hotel_Pacote.Endereco = endereco;


        var hotel = await _context.HotelModel.FindAsync(packageModel.Hotel_Pacote.Id);
        if(hotel == null)
        {
             _context.HotelModel.Add(packageModel.Hotel_Pacote);
             hotel = packageModel.Hotel_Pacote;
        }
        packageModel.Hotel_Pacote = hotel;

        //passagem
        // destino

        var destino = await _context.AddressModel.FindAsync(packageModel.Passagem_Pacote.Destino.Id);
        if(destino == null)
        {
                _context.AddressModel.Add(packageModel.Passagem_Pacote.Destino);
                destino = packageModel.Passagem_Pacote.Destino;
        }
        packageModel.Passagem_Pacote.Destino = destino;

        var origem = await _context.AddressModel.FindAsync(packageModel.Passagem_Pacote.Origem.Id); 
        if(origem == null) 
        {
                _context.AddressModel.Add(packageModel.Passagem_Pacote.Origem);
                origem = packageModel.Passagem_Pacote.Origem;
        }
        packageModel.Passagem_Pacote.Origem = origem;


         _context.PackageModel.Add(packageModel);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetPackageModel", new { id = packageModel.Id }, packageModel);

        }

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageModel(int id)
        {
            if (_context.PackageModel == null)
            {
                return NotFound();
            }
            var packageModel = await _context.PackageModel.FindAsync(id);
            if (packageModel == null)
            {
                return NotFound();
            }

            _context.PackageModel.Remove(packageModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageModelExists(int id)
        {
            return (_context.PackageModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
