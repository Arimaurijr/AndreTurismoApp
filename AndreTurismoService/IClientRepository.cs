using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;

namespace AndreTurismoAppRepository
{
    public interface IClientRepository
    {
        ClientModel InserirCliente(ClientModel cliente);
        ClientModel RetornarCliente(int id_cliente);
        bool AtualizarCliente(ClientModel cliente, string coluna, string valor);
    }
}
