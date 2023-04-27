﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.AddressService.Data;
using AndreTurismoAppModels;

namespace AndreTurismoApp.AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressModelsController : ControllerBase
    {
        private readonly AndreTurismoAppAddressServiceContext _context;

        public AddressModelsController(AndreTurismoAppAddressServiceContext context)
        {
            _context = context;
        }

        // GET: api/AddressModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressModel>>> GetAddressModel()
        {
          if (_context.AddressModel == null)
          {
              return NotFound();
          }
            return await _context.AddressModel.ToListAsync();
        }

        // GET: api/AddressModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressModel>> GetAddressModel(int id)
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
            _context.AddressModel.Add(addressModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressModel", new { id = addressModel.Id }, addressModel);
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
