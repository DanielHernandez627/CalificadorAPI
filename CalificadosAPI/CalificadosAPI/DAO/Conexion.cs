using System.Data;
using System.Data.SqlClient;

namespace CalificadosAPI.DAO
{
    public class Conexion
    {
        SqlConnection conex;
        static string servidor = "DESKTOP-6U77SPQ\\SQLEXPRESS";
        public string saludo;



        static string cadena = "Data Source = " + servidor + "; Initial Catalog= BDEstudiantes;Integrated Security = True;";


        public SqlConnection conexion()
        {
            try
            {
                conex = new SqlConnection(cadena);
                conex.Open();

            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }

            return conex;
        }

        public void cerrar()
        {
            conex.Close();
            conex.Dispose();

        }

        public DataTable Execonsultas(string query)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlCommand consulta = new SqlCommand(query, conexion());
                SqlDataAdapter adapter = new SqlDataAdapter(consulta);
                adapter.Fill(dtResult);
                cerrar();


            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return dtResult;
        }

        public bool basica(string query)
        {
            bool result = false;

            try
            {
                SqlCommand consulta = new SqlCommand(query, conexion());
                consulta.ExecuteNonQuery();
                cerrar();
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());

            }
            return result;
        }


    }
}
