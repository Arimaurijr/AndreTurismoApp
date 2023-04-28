using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;

namespace AndreTurismoAppRepository
{
    public interface ICityRepository
    {
        CityModel InserirCidade(CityModel city);
        CityModel RetornarCidade(int id);
        bool AtualizarCidade(CityModel cidade, string coluna, string valor);
    }
}
