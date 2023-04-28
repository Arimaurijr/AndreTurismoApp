using AndreTurismoApp.AddressService;
using AndreTurismoAppModels;
using AndreTurismoAppRepository;

namespace AndreTurismoApp.AddressService.Service
{
    public class CityService
    {
        public CityModel InserirCidade(CityModel cidade)
        {
            return new CityRepository().InserirCidade(cidade);
        }
    }
}
