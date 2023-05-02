using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAppModels
{
    public class ClientModel
    {
        /*
        public readonly static string INSERIR_CLIENTE =
            "insert into client(nome_cliente, telefone, endereco_cliente, data_cadastro_cliente)" +
                           "values(@Nome,     @Telefone, @Endereco,       @Data_Cadastro_Cliente);" + "select cast(scope_identity() as int);";

        public readonly static string UPDATE = "update client set @coluna = '@valor' ";
        */
        //[Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public AddressModel Endereco { get; set; }
        public DateTime Data_Cadastro_Cliente { get; set; }

        /*
        public override string ToString()
        {
            string cliente ="\n##### CLIENTE #####" + 
                            "\nID: " + this.Id +
                            "\nNome: " + this.Nome +
                            "\nTelefone: " + this.Telefone +
                            "\nData de cadastro do cliente: " + this.Data_Cadastro_Cliente + 
                             this.Endereco;
            return cliente;
        }
        */
    }
}
