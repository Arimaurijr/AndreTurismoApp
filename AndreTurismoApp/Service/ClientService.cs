using System.Runtime.ConstrainedExecution;
using System.Text;
using AndreTurismoAppModels;
using Newtonsoft.Json;

namespace AndreTurismoApp.Service
{
    public class ClientService
    {
        static readonly HttpClient cliente = new HttpClient();
        public async Task<List<ClientModel>> GetClient()
        {
            try
            {
                HttpResponseMessage response = await cliente.GetAsync("https://localhost:5002/api/Client");
                response.EnsureSuccessStatusCode();
                string client = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<List<ClientModel>>(client);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async Task<ClientModel> GetClientID(int id)
        {
            try
            {
                HttpResponseMessage response = await cliente.GetAsync("https://localhost:5002/api/Client/" + id);
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<ClientModel>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }
        public async void DeleteClientID(int id)
        {
            try
            {
                HttpResponseMessage response = await cliente.DeleteAsync("https://localhost:5002/api/Client/" + id);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async void PostClient(ClientModel clientmodel)
        {
            string clienteSerializado = JsonConvert.SerializeObject(clientmodel);
            HttpContent httpContent = new StringContent(clienteSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await cliente.PostAsync("https://localhost:5002/api/Client/", httpContent);
        }
        public async void PutAddress(int id, ClientModel clientmodel)
        {
            string clienteSerializado = JsonConvert.SerializeObject(clientmodel);
            HttpContent httpContent = new StringContent(clienteSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await cliente.PutAsync("https://localhost:5002/api/client/" + id, httpContent);
        }

    }
}

