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

namespace AndreTurismoAppRepository
{

    public class HotelRepository
    {
        public string Conn { get; set; }

        public HotelRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["servicoturismo"].ConnectionString;

        }

        public HotelModel InserirHotel(HotelModel hotel)
        {

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var query = HotelModel.INSERIR_HOTEL.Replace("@Endereco", new AddressRepository().InserirEndereco(hotel.Endereco).Id.ToString());
                hotel.Id = (int)db.ExecuteScalar(query, hotel);
            }

            return hotel;
        }
        public HotelModel RetornarHotel(int id_hotel)
        {

               
                StringBuilder sb = new StringBuilder();

                sb.Append("select  id_hotel,");
                sb.Append("        nome_hotel,");
                sb.Append("        endereco_hotel,");
                sb.Append("        data_cadastro_hotel,");
                sb.Append("        valor_hotel");
                sb.Append("        from hotel");
                sb.Append("        where id_hotel = " + id_hotel);

                HotelModel hotel = new HotelModel();

                var db = new SqlConnection(Conn);
                db.Open();

               SqlCommand commandSelect = new(sb.ToString(), db);
               IDataReader dr = commandSelect.ExecuteReader();

                if (dr.Read())
                {
                    hotel.Id = (int)dr["id_hotel"];
                    hotel.Nome = (string)dr["nome_hotel"];
                    hotel.Data_Cadastro_Hotel = (DateTime)dr["data_cadastro_hotel"];
                    hotel.Valor_Hotel = (decimal)dr["valor_hotel"];
                    int id_endereco = (int)dr["endereco_hotel"];
                    dr.Close();
                    db.Close();

                    hotel.Endereco = new AddressRepository().RetornarEndereco(id_endereco);

                }

                return hotel;
        }
        public bool AtualizarHotel(HotelModel hotel, string coluna, string valor)
        {
            bool status = true;

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                StringBuilder montagem_query = new StringBuilder();
                montagem_query.Append(HotelModel.UPDATE);
                montagem_query.Replace("@coluna", coluna);
                montagem_query.Replace("@valor", valor);

                db.Execute(montagem_query.ToString(), hotel);
            }

            return status;
        }

    }
}
