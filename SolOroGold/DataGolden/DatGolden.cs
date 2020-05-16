using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OroGolden.WebApp.Data
{
    public class DatGolden
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public int Agregar(string Nombre, string Email, int Telefono)
        {
            int filas = 0;

            SqlCommand com = new SqlCommand($"insert into persona values ( '{Nombre}', '{Email}', {Telefono} )", con);

            try
            {
                con.Open();
                filas = com.ExecuteNonQuery();
                return filas;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }

        public DataTable NombreRepetido(string Nombre)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select * from persona where Nombre = Nombre", con);
            da.Fill(dt);

            return dt;
        }

    }
}
