using AndreTurismoApp.Service;
using AndreTurismoAppModels;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _client;
        //private readonly AddressService _address;   
        public ClientController(ClientService client)
        {
            _client = client;
            //_address = address; 
        }

        // GET: api/AddressModels
        [HttpGet]
        public async Task<List<ClientModel>> GetClientModel()
        {
            return  _client.GetClient().Result;
        }
        [HttpGet("{id}")]
        public async Task<ClientModel> GetClientModelID(int id)
        {
            return await _client.GetClientID(id);
        }
        [HttpDelete("{id}")]
        public async void DeleteClientID(int id)
        {
            _client.DeleteClientID(id);
        }
        [HttpPost]
        public async void PostClient(ClientModel clientmodel)
        {
            /*
            var endereco = clientmodel.Endereco;
            if(_address.GetAddressID(endereco.Id).Result == null)
            {
                clientmodel.Endereco.Id = 0;
                clientmodel.Endereco.Cidade.Id = 0;

                _address.PostAddress(clientmodel.Endereco.CEP, Convert.ToString(clientmodel.Endereco.Numero), clientmodel.Endereco);
            }
            else
            {
                clientmodel.Endereco.Id = 0;
                clientmodel.Endereco.Cidade.Id = 0;
            }
            */

            _client.PostClient(clientmodel);
        }
        [HttpPut("{id}")]
        public async void PutClient(int id, ClientModel client)
        {
            _client.PutAddress(id, client);
        }
        
    }
}

