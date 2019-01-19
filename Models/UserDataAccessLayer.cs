using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class UserDataAccessLayer
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

        public static string _akses;
        public static string _idpelabuhan;
        public static string _namapelabuhan;
        public string ValidateLogin(UserDetails user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidateUserLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginNamauser", user.Namauser);
                cmd.Parameters.AddWithValue("@LoginPassword", user.Password);
                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _akses = reader["akses"].ToString();
                    _idpelabuhan = reader["idpelabuhan"].ToString();
                    _namapelabuhan = reader["namapelabuhan"].ToString();
                }
                con.Close();
                return result;
            }
        }
    }
}
