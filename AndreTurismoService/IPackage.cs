using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;

namespace AndreTurismoAppRepository
{
    public interface IPackage
    {
        PackageModel InserirPacote(PackageModel pacote);
        List<PackageModel> ListarTodasPacotes();
        bool AtualizarPacote(PackageModel pacote, string coluna, string valor);
       PackageModel RetornarPacote(int id_pacote);
    }
}
