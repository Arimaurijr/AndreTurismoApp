using AndreTurismoApp.Service;
using AndreTurismoAppModels;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
       
            private readonly TicketService _ticket;
            private readonly AddressService _address;
            private readonly ClientService _client; 
            public TicketController(TicketService ticket, AddressService address, ClientService client)
            {
                _ticket = ticket;
                _address = address;
                _client = client;   
            }

            // GET: api/AddressModels
            [HttpGet]
            public async Task<List<TicketModel>> GetTicketModel()
            {
                return _ticket.GetTicket().Result;
            }
            [HttpGet("{id}")]
            public async Task<TicketModel> GetTicketModelID(int id)
            {
                return await _ticket.GetTicketID(id);
            }
            [HttpDelete("{id}")]
            public async void DeleteTicketID(int id)
            {
                _ticket.DeleteTicketID(id);
            }
            [HttpPost]
            public async void PostTicket(TicketModel ticketmodel)
            {
                var origem = ticketmodel.Origem;
                if (_address.GetAddressID(origem.Id).Result == null)
                {
                    ticketmodel.Origem.Id = 0;
                    ticketmodel.Origem.Cidade.Id = 0;

                    _address.PostAddress(ticketmodel.Origem.CEP, Convert.ToString(ticketmodel.Origem.Numero), ticketmodel.Origem);
                }
                else
                {
                    ticketmodel.Origem.Id = 0;
                    ticketmodel.Origem.Cidade.Id = 0;
                }

                var destino = ticketmodel.Destino;
                if (_address.GetAddressID(destino.Id).Result == null)
                {
                    ticketmodel.Destino.Id = 0;
                    ticketmodel.Destino.Cidade.Id = 0;

                    _address.PostAddress(ticketmodel.Destino.CEP, Convert.ToString(ticketmodel.Destino.Numero), ticketmodel.Destino);
                }
                else
                {
                    ticketmodel.Destino.Id = 0;
                    ticketmodel.Destino.Cidade.Id = 0;
                }

                /*
                var cliente = ticketmodel.Cliente;
                if(_client.GetClientID(cliente.Id).Result == null)
                {
                   _client.PostClient(cliente);
                }
                else
                {
                   ticketmodel.Cliente.Id = 0;
                }
                */


                _ticket.PostTicket(ticketmodel);
            }
            [HttpPut("{id}")]
            public async void PutClient(int id, TicketModel tick)
            {
                _ticket.PutTicket(id, tick);
            }
        }
    }

