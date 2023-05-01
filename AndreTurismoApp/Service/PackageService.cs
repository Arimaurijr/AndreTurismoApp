using AndreTurismoAppModels;
using Newtonsoft.Json;
using System.Text;

namespace AndreTurismoApp.Service
{
    public class PackageService
    {
        static readonly HttpClient pacote = new HttpClient();
        public async Task<List<PackageModel>> GetPackage()
        {
            try
            {
                HttpResponseMessage response = await pacote.GetAsync("https://localhost:5005/api/Package");
                response.EnsureSuccessStatusCode();
                string pac = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<List<PackageModel>>(pac);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async Task<PackageModel> GetPackageID(int id)
        {
            try
            {
                HttpResponseMessage response = await pacote.GetAsync("https://localhost:5005/api/Package/" + id);
                response.EnsureSuccessStatusCode();
                string pac = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<PackageModel>(pac);
                return end;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }
        public async void DeletePackageID(int id)
        {
            try
            {
                HttpResponseMessage response = await pacote.DeleteAsync("https://localhost:5005/api/Package/" + id);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async void PostPackage(PackageModel packageModel)
        {
            string pacoteSerializado = JsonConvert.SerializeObject(packageModel);
            HttpContent httpContent = new StringContent(pacoteSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await pacote.PostAsync("https://localhost:5005/api/Package/", httpContent);
        }
        public async void PutPackage(int id, PackageModel packageModel)
        {
            string pacoteSerializado = JsonConvert.SerializeObject(packageModel);
            HttpContent httpContent = new StringContent(pacoteSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await pacote.PutAsync("https://localhost:5005/api/Package/" + id, httpContent);
        }
    }
}
