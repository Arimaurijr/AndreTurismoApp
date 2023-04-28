using AndreTurismoApp._AddressService;
using AndreTurismoAppModels;
using AndreTurismoAppRepository;

namespace AndreTurismoApp._AddressService.Service
{
    public class CityService
    {
        public CityModel InserirCidade(CityModel cidade)
        {
            return new CityRepository().InserirCidade(cidade);
        }
    }
}
