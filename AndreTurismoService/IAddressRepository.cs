using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;

namespace AndreTurismoAppRepository
{
    public interface IAddressRepository
    {
        AddressModel InserirEndereco(AddressModel endereco);
        AddressModel RetornarEndereco(int id_endereco);
        bool AtualizarEndereco(AddressModel endereco, string coluna, string valor);
    }
}
