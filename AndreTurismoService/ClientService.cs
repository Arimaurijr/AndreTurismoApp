using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using Dapper;

namespace AndreTurismoService
{

    public class ClientService
    {
        public string Conn { get; set; }

        public ClientService()
        {
            Conn = ConfigurationManager.ConnectionStrings["servicoturismo"].ConnectionString;


        }

        public ClientModel InserirCliente(ClientModel cliente)
        {

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var query = ClientModel.INSERIR_CLIENTE.Replace("@Endereco", new AddressService().InserirEndereco(cliente.Endereco).Id.ToString());
                cliente.Id = (int)db.ExecuteScalar(query, cliente);
            }

            return cliente;
        }
        public ClientModel RetornarCliente(int id_cliente)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select id_cliente,");
            sb.Append("       nome_cliente,");
            sb.Append("       endereco_cliente,");
            sb.Append("       data_cadastro_cliente,");
            sb.Append("       telefone");
            sb.Append("       from client");
            sb.Append("       where id_cliente = " + id_cliente);

            ClientModel cliente = new ClientModel();
            var db = new SqlConnection(Conn);
            db.Open();

            SqlCommand commandSelect = new(sb.ToString(), db);
            IDataReader dr = commandSelect.ExecuteReader();


            if (dr.Read())
            {
                cliente.Id = (int)dr["id_cliente"];
                cliente.Nome = (string)dr["nome_cliente"];
                cliente.Telefone = (string)dr["Telefone"];
                cliente.Data_Cadastro_Cliente = (DateTime)dr["data_cadastro_cliente"];

                int id_endereco = (int)dr["endereco_cliente"];
                dr.Close();
                db.Close();

                cliente.Endereco = new AddressService().RetornarEndereco(id_endereco);
            }

            return cliente;
        }
        public bool AtualizarCliente(ClientModel cliente, string coluna, string valor)
        {
            bool status = true;

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                StringBuilder montagem_query = new StringBuilder();
                montagem_query.Append(ClientModel.UPDATE);
                montagem_query.Replace("@coluna", coluna);
                montagem_query.Replace("@valor", valor);

                db.Execute(montagem_query.ToString(), cliente);
            }

            return status;
        }


    }

}
