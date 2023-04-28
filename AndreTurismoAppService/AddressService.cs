using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using AndreTurismoAppRepository;

namespace AndreTurismoAppService
{
    public class AddressService
    {
        public AddressModel InserirEndereco(AddressModel endereco)
        {
            return new AddressRepository().InserirEndereco(endereco);
        }
        public AddressModel RetornarEndereco(int id_endereco)
        {
            return new AddressRepository().RetornarEndereco(id_endereco);
        }
        public bool AtualizarEndereco(AddressModel endereco, string coluna, string valor)
        {
            return new AddressRepository().AtualizarEndereco(endereco, coluna, valor);
        }
    }
}
