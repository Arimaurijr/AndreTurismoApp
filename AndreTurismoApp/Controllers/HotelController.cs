using AndreTurismoApp.Service;
using AndreTurismoAppModels;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotel;
        private readonly AddressService _address;
        public HotelController(HotelService hotel, AddressService address)
        {
            _hotel = hotel; 
            _address = address;
        }

        // GET: api/AddressModels
        [HttpGet]
        public async Task<List<HotelModel>> GetHotelModel()
        {
            //return await _hotel.GetHotel().Result;

            return  _hotel.GetHotel().Result;
        }
        [HttpGet("{id}")]
        public async Task<HotelModel> GetHotelModelID(int id)
        {
            return await _hotel.GetHotelID(id);
        }
        [HttpDelete("{id}")]
        public async void DeleteClientID(int id)
        {
            _hotel.DeleteHotelID(id);
        }
        [HttpPost]
        public async void PostClient(HotelModel hotelModel)
        {
            var endereco = hotelModel.Endereco;
            if (_address.GetAddressID(endereco.Id).Result == null)
            {
                hotelModel.Endereco.Id = 0;
                hotelModel.Endereco.Cidade.Id = 0;

                _address.PostAddress(hotelModel.Endereco.CEP, Convert.ToString(hotelModel.Endereco.Numero), hotelModel.Endereco);
            }
            else
            {
                hotelModel.Endereco.Id = 0;
                hotelModel.Endereco.Cidade.Id = 0;
            }

            _hotel.PostHotel(hotelModel);
        }
        [HttpPut("{id}")]
        public async void PutClient(int id, HotelModel hotel)
        {
            _hotel.PutHotel(id, hotel);
        }

    }
}


