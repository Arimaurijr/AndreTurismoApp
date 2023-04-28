using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;

namespace AndreTurismoAppRepository
{
    public interface ITicketRepository
    {
        TicketModel InserirPassagem(TicketModel passagem);
        TicketModel RetornarPassagem(int id_passagem);
        bool AtualizarPassagem(TicketModel passagem, string coluna, string valor);
    }
}
