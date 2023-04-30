using AndreTurismoAppModels;
using Newtonsoft.Json;
using System.Text;

namespace AndreTurismoApp.Service
{
    public class HotelService
    {
        static readonly HttpClient hotel = new HttpClient();
        public async Task<List<HotelModel>> GetHotel()
        {
            try
            {
                HttpResponseMessage response = await hotel.GetAsync("https://localhost:5003/api/Hotel");
                response.EnsureSuccessStatusCode();
                string hotel1 = await response.Content.ReadAsStringAsync();
                var hotel2 = JsonConvert.DeserializeObject<List<HotelModel>>(hotel1);
                return hotel2;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async Task<HotelModel> GetHotelID(int id)
        {
            try
            {
                HttpResponseMessage response = await hotel.GetAsync("https://localhost:5003/api/Hotel/" + id);
                response.EnsureSuccessStatusCode();
                string _hotel = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<HotelModel>(_hotel);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async void DeleteHotelID(int id)
        {
            try
            {
                HttpResponseMessage response = await hotel.DeleteAsync("https://localhost:5003/api/Hotel/" + id);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async void PostHotel(HotelModel hotelModel)
        {
            string hotelSerializado = JsonConvert.SerializeObject(hotelModel);
            HttpContent httpContent = new StringContent(hotelSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await hotel.PostAsync("https://localhost:5003/api/Hotel/", httpContent);
        }
        public async void PutHotel(int id, HotelModel hotelModel)
        {
            string hotelSerializado = JsonConvert.SerializeObject(hotelModel);
            HttpContent httpContent = new StringContent(hotelSerializado, Encoding.UTF8, "application/JSON");
            HttpResponseMessage response = await hotel.PutAsync("https://localhost:5003/api/Hotel/" + id, httpContent);
        }
    }
}
