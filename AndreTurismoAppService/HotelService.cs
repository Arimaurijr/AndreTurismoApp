using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using AndreTurismoAppRepository;

namespace AndreTurismoAppService
{
    public class HotelService
    {
        public HotelModel InserirHotel(HotelModel hotel)
        {
            return new HotelRepository().InserirHotel(hotel);
        }
        public HotelModel RetornarHotel(int id_hotel)
        {
            return new HotelRepository().RetornarHotel(id_hotel);
        }
        public bool AtualizarHotel(HotelModel hotel, string coluna, string valor)
        {
            return new HotelRepository().AtualizarHotel(hotel, coluna, valor);  
        }
    }
}
