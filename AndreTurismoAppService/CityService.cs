using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using AndreTurismoAppRepository;

namespace AndreTurismoAppService
{
    public class CityService
    {
        public CityModel InserirCidade(CityModel city)
        {
            return new CityRepository().InserirCidade(city);
        }
        public CityModel RetornarCidade(int id)
        {
            return new CityRepository().RetornarCidade(id);
        }
        public bool AtualizarCidade(CityModel cidade, string coluna, string valor)
        {
            return new CityRepository().AtualizarCidade(cidade, coluna, valor);
        }
    }
}
