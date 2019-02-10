using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class TitleDataAccessLayer
    {
        public static IConfiguration Configuration { get; set; }
        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string connectionString = Configuration["ConnectionStrings:penjadwalan"];
            return connectionString;
        }
        string connectionString = GetConnectionString();
        string Query;

        public string NamaPelabuhan(int id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                Query = "SELECT * FROM dbo.pelabuhan WHERE idlistpelabuhan='"+id+"' ";
                string nama = "";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        nama = reader["namapelabuhan"].ToString();
                    }
                    
                }
                else
                {
                    nama = "Tidak Terdefinisi";
                }
                con.Close();

                return nama;
            }

        }

        public string NamaProduk(int id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                Query = "SELECT * FROM dbo.produk WHERE idproduk='" + id + "' ";
                string nama = "";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        nama = reader["namaproduk"].ToString();
                    }

                }
                else
                {
                    nama = "Tidak Terdefinisi";
                }
                con.Close();

                return nama;
            }

        }

    }
}
