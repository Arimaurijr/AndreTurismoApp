using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoAppModels;
using Dapper;

namespace AndreTurismoService
{
    
    public class PackageService
    {

        public string Conn { get; set; }

        public PackageService()
        {
            Conn = ConfigurationManager.ConnectionStrings["servicoturismo"].ConnectionString;

        }

        public PackageModel InserirPacote(PackageModel pacote)
        {

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                StringBuilder montagem_query = new StringBuilder();
                montagem_query.Append(PackageModel.INSERIR_PACOTE);
                montagem_query.Replace("@Hotel_Pacote", new HotelService().InserirHotel(pacote.Hotel_Pacote).Id.ToString());
                montagem_query.Replace("@Passagem_Pacote", new TicketService().InserirPassagem(pacote.Passagem_Pacote).Id.ToString());
                montagem_query.Replace("@Cliente_Pacote", new ClientService().InserirCliente(pacote.Cliente_Pacote).Id.ToString());

                pacote.Id = (int)db.ExecuteScalar(montagem_query.ToString(), pacote);
            }

            return pacote;
        }
        public List<PackageModel> ListarTodasPacotes()
        {   
            StringBuilder sb = new StringBuilder();

            sb.Append("select id_pacote,");
            sb.Append("       hotel_pacote,");
            sb.Append("       passagem_pacote,");
            sb.Append("       data_cadastro_pacote,");
            sb.Append("       valor_pacote,");
            sb.Append("       cliente_pacote");
            sb.Append("       from package");


            List<PackageModel> pacotes = new();

            var db = new SqlConnection(Conn);
            db.Open();

            SqlCommand commandSelect = new(sb.ToString(), db);
            IDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
               PackageModel pacote = new();

               pacote.Id = (int)dr["id_pacote"];
               int id_hotel = (int)dr["hotel_pacote"];
               int id_passagem = (int)dr["passagem_pacote"];
               int id_cliente = (int)dr["cliente_pacote"];
               pacote.Hotel_Pacote = new HotelService().RetornarHotel(id_hotel);
               pacote.Passagem_Pacote = new TicketService().RetornarPassagem(id_passagem);
               pacote.Cliente_Pacote = new ClientService().RetornarCliente(id_cliente);

               pacote.Valor_Pacote = (decimal)dr["valor_pacote"];
               pacote.Data_Cadastro_Pacote = (DateTime)dr["data_cadastro_pacote"];

               pacotes.Add(pacote);

            }

            return pacotes;
            
        }
        public bool AtualizarPacote(PackageModel pacote, string coluna, string valor)
        {
            bool status = true;

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                StringBuilder montagem_query = new StringBuilder();
                montagem_query.Append(PackageModel.UPDATE);
                montagem_query.Replace("@coluna", coluna);
                montagem_query.Replace("@valor", valor);

                db.Execute(montagem_query.ToString(), pacote);
            }

            return status;
        }

        public PackageModel RetornarPacote(int id_pacote)
        {
            StringBuilder sb = new StringBuilder();
            PackageModel pacote = new PackageModel();

            sb.Append("select id_pacote,");
            sb.Append("       hotel_pacote,");
            sb.Append("       passagem_pacote,");
            sb.Append("       data_cadastro_pacote,");
            sb.Append("       valor_pacote,");
            sb.Append("       cliente_pacote");
            sb.Append("       from package where id_pacote = " + id_pacote);


            var db = new SqlConnection(Conn);
            db.Open();

            SqlCommand commandSelect = new(sb.ToString(), db);
            IDataReader dr = commandSelect.ExecuteReader();

             if(dr.Read())
            {
                

                pacote.Id = (int)dr["id_pacote"];
                int id_hotel = (int)dr["hotel_pacote"];
                int id_passagem = (int)dr["passagem_pacote"];
                int id_cliente = (int)dr["cliente_pacote"];
                pacote.Hotel_Pacote = new HotelService().RetornarHotel(id_hotel);
                pacote.Passagem_Pacote = new TicketService().RetornarPassagem(id_passagem);
                pacote.Cliente_Pacote = new ClientService().RetornarCliente(id_cliente);

                pacote.Valor_Pacote = (decimal)dr["valor_pacote"];
                pacote.Data_Cadastro_Pacote = (DateTime)dr["data_cadastro_pacote"];

            }

            return pacote;

        }

    }
    
}
