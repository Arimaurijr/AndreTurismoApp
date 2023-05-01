using AndreTurismoAppModels;
using Newtonsoft.Json;
using System.Text;

namespace AndreTurismoApp.Service
{
    public class TicketService
    {
        static readonly HttpClient ticket = new HttpClient();
        public async Task<List<TicketModel>> GetTicket()
        {
            try
            {
                HttpResponseMessage response = await ticket.GetAsync("https://localhost:5004/api/Ticket");
                response.EnsureSuccessStatusCode();
                string tic = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<List<TicketModel>>(tic);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async Task<TicketModel> GetTicketID(int id)
        {
            try
            {
                HttpResponseMessage response = await ticket.GetAsync("https://localhost:5004/api/Ticket/" + id);
                response.EnsureSuccessStatusCode();
                string tic = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<TicketModel>(tic);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async void DeleteTicketID(int id)
        {
            try
            {
                HttpResponseMessage response = await ticket.DeleteAsync("https://localhost:5004/api/Ticket/" + id);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async void PostTicket(TicketModel ticketmodel)
        {
            string ticketSerializado = JsonConvert.SerializeObject(ticketmodel);
            HttpContent httpContent = new StringContent(ticketSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await ticket.PostAsync("https://localhost:5004/api/Ticket/", httpContent);
        }
        public async void PutTicket(int id, TicketModel ticketModel)
        {
            string ticketSerializado = JsonConvert.SerializeObject(ticketModel);
            HttpContent httpContent = new StringContent(ticketSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await ticket.PutAsync("https://localhost:5004/api/Ticket/" + id, httpContent);
        }
    }
}
