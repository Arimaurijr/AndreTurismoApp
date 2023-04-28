using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using AndreTurismoAppRepository;

namespace AndreTurismoAppService
{
    public class PackageService
    {
        public PackageModel InserirPacote(PackageModel pacote)
        {
            return new PackageRepository().InserirPacote(pacote);
        }
        public List<PackageModel> ListarTodasPacotes()
        {
            return new PackageRepository().ListarTodasPacotes();
        }
        public bool AtualizarPacote(PackageModel pacote, string coluna, string valor)
        {
            return new PackageRepository().AtualizarPacote(pacote, coluna, valor);
        }
        public PackageModel RetornarPacote(int id_pacote)
        {
            return new PackageRepository().RetornarPacote(id_pacote);
        }
    }
}
