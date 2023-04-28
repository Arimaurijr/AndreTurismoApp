using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAppModels
{
    public class AddressModel
    {
        public readonly static string INSERIR_ENDERECO = 
            "insert into addressModel" + 
            "(logradouro,numero,bairro,cep,complemento,data_cadastro_endereco,CidadeId)" +
     "values(@Logradouro,@Numero,@Bairro,@CEP,@Complemento,@Data_Cadastro_Endereco,@Cidade)" + "select cast(scope_identity() as int);";

        public readonly static string UPDATE = "update addressModel set @coluna = '@valor' ";

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public CityModel Cidade { get; set; }
        public DateTime Data_Cadastro_Endereco { get; set; }

        public override string ToString()
        {
            string enredeco = "\n##### ENDEREÇO #####" +
                              "\nId: " + this.Id +
                              "\nLogradouro: " + this.Logradouro +
                              "\nNumero: " + this.Numero +
                              "\nBairro: " + this.Bairro +
                              "\nCEP: " + this.CEP +
                              "\nComplemento: " + this.Complemento +
                              "\nData de Cadastro do endereço: " + this.Data_Cadastro_Endereco +
                               this.Cidade +
                              "\n";

            return enredeco;    
        }

    }
}
