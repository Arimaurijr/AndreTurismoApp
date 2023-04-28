using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using Dapper;

namespace AndreTurismoAppRepository
{
    public class AddressRepository
    {
        public string Conn { get; set; }
        public AddressRepository()
        {
            //Conn = ConfigurationManager.ConnectionStrings["servicoturismo"].ConnectionString;
            Conn = @"Server=(localdb)\MSSQLLocalDB; Integrated Security=true; AttachDbFileName=C:\Users\adm\AndreTurismoApp.AddressService.Data.mdf";
        }

        public AddressModel InserirEndereco(AddressModel endereco)
        {
            
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var query = AddressModel.INSERIR_ENDERECO.Replace("@Cidade", new CityRepository().InserirCidade(endereco.Cidade).Id.ToString());
                endereco.Id = (int)db.ExecuteScalar(query, endereco);
            }

            return endereco;
           
        }

        public AddressModel RetornarEndereco(int id_endereco)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select id_endereco,");
            sb.Append("       logradouro,");
            sb.Append("       numero,");
            sb.Append("       bairro,");
            sb.Append("       cep,");
            sb.Append("       complemento,");
            sb.Append("       data_cadastro_endereco,");
            sb.Append("       id_cidade_endereco");
            sb.Append("       from address where id_endereco = " + id_endereco);

            AddressModel endereco = new AddressModel();
            var db = new SqlConnection(Conn);
            db.Open();

            SqlCommand commandSelect = new(sb.ToString(), db);
            IDataReader dr = commandSelect.ExecuteReader();

            if (dr.Read())
            {

                endereco.Id = (int)dr["id_endereco"];
                endereco.Logradouro = (string)dr["logradouro"];
                endereco.Numero = (int)dr["numero"];
                endereco.Bairro = (string)dr["bairro"];
                endereco.CEP = (string)dr["cep"];
                endereco.Complemento = (string)dr["complemento"];
                endereco.Data_Cadastro_Endereco = (DateTime)dr["data_cadastro_endereco"];
                int id_cidade = (int)dr["id_cidade_endereco"];
                dr.Close();
                db.Close();

                endereco.Cidade = new CityRepository().RetornarCidade(id_cidade);

            }


            return endereco;
         }
        public bool AtualizarEndereco(AddressModel endereco, string coluna, string valor)
        {
            bool status = true;

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                StringBuilder montagem_query = new StringBuilder();
                montagem_query.Append(AddressModel.UPDATE);
                montagem_query.Replace("@coluna", coluna);
                montagem_query.Replace("@valor", valor);

                db.Execute(montagem_query.ToString(), endereco);
            }

            return status;
        }

        
    } 
       
}

