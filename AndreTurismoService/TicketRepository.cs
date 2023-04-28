using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using Dapper;

namespace AndreTurismoAppRepository
{
    
    public class TicketRepository : ITicketRepository   
    {
        public string Conn { get; set; }

        public TicketRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["servicoturismo"].ConnectionString;
        }

        public TicketModel InserirPassagem(TicketModel passagem)
        {

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                StringBuilder montagem_query = new StringBuilder();
                montagem_query.Append(TicketModel.INSERIR_PASSAGEM);
                montagem_query.Replace("@Origem", new AddressRepository().InserirEndereco(passagem.Origem).Id.ToString());
                montagem_query.Replace("@Destino", new AddressRepository().InserirEndereco(passagem.Destino).Id.ToString());
                montagem_query.Replace("@Cliente", new ClientRepository().InserirCliente(passagem.Cliente).Id.ToString());

                passagem.Id = (int)db.ExecuteScalar(montagem_query.ToString(), passagem);
            }

            return passagem;
        }
        public TicketModel RetornarPassagem(int id_passagem)
        {
            
             StringBuilder sb = new StringBuilder();
             

             sb.Append("select id_passagem,");
             sb.Append("       endereco_origem,");
             sb.Append("       endereco_destino,");
             sb.Append("       cliente_passagem,");
             sb.Append("       data_cadastro_passagem,");
             sb.Append("       valor_passagem");
             sb.Append("       from  passagem");
             sb.Append("       where id_passagem = " + id_passagem);

             TicketModel passagem = new TicketModel();

             var db = new SqlConnection(Conn);
             db.Open();

             SqlCommand commandSelect = new(sb.ToString(), db);
             IDataReader dr = commandSelect.ExecuteReader();

            if (dr.Read())
             {
                passagem.Id = (int)dr["id_passagem"];
                int id_origem = (int)dr["endereco_origem"];
                int id_destino = (int)dr["endereco_destino"];
                int id_cliente = (int)dr["cliente_passagem"];
                dr.Close();
                db.Close();

                passagem.Origem = new AddressRepository().RetornarEndereco(id_origem);
                passagem.Destino = new AddressRepository().RetornarEndereco(id_destino);
                passagem.Cliente = new ClientRepository().RetornarCliente(id_cliente);


             }

              return passagem;
        }
        public bool AtualizarPassagem(TicketModel passagem, string coluna, string valor)
        {
            bool status = true;

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                StringBuilder montagem_query = new StringBuilder();
                montagem_query.Append(TicketModel.UPDATE);
                montagem_query.Replace("@coluna", coluna);
                montagem_query.Replace("@valor", valor);

                db.Execute(montagem_query.ToString(), passagem);
            }

            return status;
        }
    }

}
