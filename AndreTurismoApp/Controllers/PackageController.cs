using AndreTurismoApp.Service;
using AndreTurismoAppModels;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController
    {
        private readonly PackageService _package;
        private readonly ClientService _client;
        private readonly TicketService _ticket;
        private readonly HotelService _hotel;
        public PackageController(PackageService package, ClientService client, TicketService ticket, HotelService hotel)
        {
            _package = package;
            _client = client;
            _ticket = ticket;
            _hotel = hotel;
        }

        // GET: api/AddressModels
        [HttpGet]
        public async Task<List<PackageModel>> GetPackageModel()
        {
            return _package.GetPackage().Result;
        }
        [HttpGet("{id}")]
        public async Task<PackageModel> GetPackageModelID(int id)
        {
            return await _package.GetPackageID(id);
        }
        [HttpDelete("{id}")]
        public async void DeletePackageID(int id)
        {
            _package.DeletePackageID(id);
        }
        [HttpPost]
        public async void PostPackage(PackageModel packageModel)
        {
            // hotel
            if(_hotel.GetHotelID(packageModel.Hotel_Pacote.Id) == null)
            {
                packageModel.Hotel_Pacote.Id = 0;
                _hotel.PostHotel(packageModel.Hotel_Pacote);

            }
            else
            {
                packageModel.Hotel_Pacote.Id = 0;
            }

            // cliente
            if(_client.GetClientID(packageModel.Cliente_Pacote.Id) == null)
            {
                packageModel.Cliente_Pacote.Id = 0;
                _client.PostClient(packageModel.Cliente_Pacote);
            }
            else
            {
                packageModel.Cliente_Pacote.Id = 0;
            }

            // passagem
            if(_ticket.GetTicketID(packageModel.Passagem_Pacote.Id) == null)
            {
                packageModel.Passagem_Pacote.Id = 0;
                _ticket.PostTicket(packageModel.Passagem_Pacote);   
            }
            else
            {
                packageModel.Passagem_Pacote.Id = 0;
            }

            _package.PostPackage(packageModel);
            /*
            var endereco = clientmodel.Endereco;
            if (_address.GetAddressID(endereco.Id).Result == null)
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

            _client.PostClient(clientmodel);
            */
        }
        [HttpPut("{id}")]
        public async void PutClient(int id, ClientModel client)
        {
            _client.PutAddress(id, client);
        }
    }
}
