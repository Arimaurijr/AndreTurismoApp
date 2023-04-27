using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAppModels
{
    public class PackageModel
    {
        public readonly static string INSERIR_PACOTE =
        "insert into package" +
        "(      hotel_pacote,  passagem_pacote,  data_cadastro_pacote,  valor_pacote,  cliente_pacote)" +
        "values(@Hotel_Pacote, @Passagem_Pacote, @Data_Cadastro_Pacote, @Valor_Pacote, @Cliente_Pacote);" + "select cast(scope_identity() as int);";

        public readonly static string UPDATE = "update package set @coluna = '@valor' ";
        public int Id { get; set; }
        public HotelModel Hotel_Pacote { get; set; }
        public TicketModel Passagem_Pacote { get; set; }
        public DateTime Data_Cadastro_Pacote { get; set; }
        public decimal Valor_Pacote { get; set; }
        public ClientModel Cliente_Pacote { get; set; }

        public override string ToString()
        {
            string pacote = "ID: " + this.Id +
                             this.Hotel_Pacote +
                             this.Passagem_Pacote +
                             this.Cliente_Pacote +
                            "Data de cadastro do pacote: " + this.Data_Cadastro_Pacote +
                            "\nValor do pacote: " + this.Valor_Pacote;
            return pacote;
        }
    }
}
