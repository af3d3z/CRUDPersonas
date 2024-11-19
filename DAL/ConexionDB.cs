using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ConexionDB
    {
        public static SqlConnection GetConexion()
        {
            SqlConnection conn = new SqlConnection();

            try {
                conn.ConnectionString = "server=alonso.database.windows.net;database=alonso-db;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
                conn.Open();
            } catch (Exception e) {
                throw e;            
            }

            return conn;
        }
    }
}
