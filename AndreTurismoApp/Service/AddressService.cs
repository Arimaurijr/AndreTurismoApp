using System.Runtime.ConstrainedExecution;
using System.Text;
using AndreTurismoAppModels;
using Newtonsoft.Json;

namespace AndreTurismoApp.Service
{
    public class AddressService
    {
        static readonly HttpClient endereco = new HttpClient();
        public async Task<List<AddressModel>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await endereco.GetAsync("https://localhost:5001/api/Address");
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<List<AddressModel>>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async Task<AddressModel> GetAddressID(int id)
        {
            try
            {
                HttpResponseMessage response = await endereco.GetAsync("https://localhost:5001/api/Address/" + id);
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<AddressModel>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async void DeleteAddressID(int id)
        {
            try
            {
                HttpResponseMessage response = await endereco.DeleteAsync("https://localhost:5001/api/Address/" + id);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async void PostAddress(string CEP, string Numero, AddressModel addressModel)
        {
            string enderecoSerializado = JsonConvert.SerializeObject(addressModel);
            HttpContent httpContent = new StringContent(enderecoSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await endereco.PostAsync("https://localhost:5001/api/Address/" + CEP + ", " + Numero, httpContent);
        }
        public async void PutAddress(int id, AddressModel addressModel)
        {
            string enderecoSerializado = JsonConvert.SerializeObject(addressModel);
            HttpContent httpContent = new StringContent(enderecoSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await endereco.PutAsync("https://localhost:5001/api/Address/" + id, httpContent);
        }

    }
}
