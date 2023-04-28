using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using AndreTurismoAppRepository;

namespace AndreTurismoAppService
{
    public class TicketService
    {
        public TicketModel InserirPassagem(TicketModel passagem)
        {
            return new TicketRepository().InserirPassagem(passagem);
        }
        public TicketModel RetornarPassagem(int id_passagem)
        {
            return new TicketRepository().RetornarPassagem(id_passagem);
        }
        public bool AtualizarPassagem(TicketModel passagem, string coluna, string valor)
        {
            return new TicketRepository().AtualizarPassagem(passagem, coluna, valor);   
        }
    }
}
