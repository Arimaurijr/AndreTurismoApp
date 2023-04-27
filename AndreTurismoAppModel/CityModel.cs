using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAppModels
{

    public class CityModel
    {
        public readonly static string INSERT = "insert into city(descricao,data_cadastro_cidade) VALUES(@descricao, @data_cadastro_cidade);" + "select cast(scope_identity() as int);";
        public readonly static string UPDATE = "update city set @coluna = '@valor' ";
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Cadastro_Cidade { get; set; } 
        public override string ToString()
        {
            string cidade = "\n##### CIDADE #####" + 
                            "\nId: " + this.Id + 
                            "\nDescrição:" + this.Descricao +
                            "\nData cadastro da cidade:" + this.Data_Cadastro_Cidade + "\n";
            return cidade;
;        }
    }
}
