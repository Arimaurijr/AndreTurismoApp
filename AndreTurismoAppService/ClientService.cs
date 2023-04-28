using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using AndreTurismoAppRepository;

namespace AndreTurismoAppService
{
    public class ClientService
    {
        public ClientModel InserirCliente(ClientModel cliente)
        {
            return new ClientRepository().InserirCliente(cliente);
        }
        public ClientModel RetornarCliente(int id_cliente)
        {
            return new ClientRepository().RetornarCliente(id_cliente);
        }
        public bool AtualizarCliente(ClientModel cliente, string coluna, string valor)
        {
            return new ClientRepository().AtualizarCliente(cliente, coluna, valor); 
        }
    }
}
