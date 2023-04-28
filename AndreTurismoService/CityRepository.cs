using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using Dapper;
using System.Data;
using AndreTurismoAppModels;

namespace AndreTurismoAppRepository
{
    public class CityRepository
    {
        
        public string Conn { get; set; }

        public CityRepository()
        {
            //Conn = ConfigurationManager.ConnectionStrings["ConexaoCEP"].ConnectionString;
            Conn = @"Server=(localdb)\MSSQLLocalDB; Integrated Security=true; AttachDbFileName=C:\Users\adm\AndreTurismoApp.AddressService.Data.mdf";
        }

        public CityModel InserirCidade(CityModel city)
        {

            using(var db = new SqlConnection(Conn))
            {
                db.Open();
                city.Id = (int)db.ExecuteScalar(CityModel.INSERT, city);
            }

            return city;  
        }
        public CityModel RetornarCidade(int id)
        {
               
           
                StringBuilder sb = new StringBuilder();
                sb.Append("select id_cidade, descricao, data_cadastro_cidade from city where id_cidade = " + id);

                CityModel cidade = new CityModel();
                var db = new SqlConnection(Conn);
                db.Open();

                SqlCommand commandSelect = new(sb.ToString(), db);
                IDataReader dr = commandSelect.ExecuteReader();

                if (dr.Read())
                {
                    cidade.Id = (int)dr["id_cidade"];
                    cidade.Descricao = (string)dr["descricao"];
                    cidade.Data_Cadastro_Cidade = (DateTime)dr["data_cadastro_cidade"];
                }

                
                dr.Close();
                db.Close();
                return cidade;
        }
        public bool AtualizarCidade(CityModel cidade, string coluna, string valor)
        {
            bool status = true;
            
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                StringBuilder montagem_query = new StringBuilder();
                montagem_query.Append(CityModel.UPDATE);
                montagem_query.Replace("@coluna",coluna);
                montagem_query.Replace("@valor", valor);

                db.Execute(montagem_query.ToString(), cidade);
            }

            return status;
        }
       
    }
}
