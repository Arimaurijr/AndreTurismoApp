using AndreTurismoApp.Service;
using AndreTurismoAppModels;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
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
       
    }
}
