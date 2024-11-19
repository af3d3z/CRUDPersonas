using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CRUDDepartamento
    {
        /// <summary>
        /// Devuelve un departamento de la bd a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Departamento con el id suministrado</returns>
        public static Departamento GetDepartamento(int id) {
            Departamento departamento = new Departamento();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.CommandText = "SELECT * FROM Departamentos WHERE ID = @id";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader.HasRows) {
                    reader.Read();
                    string nombre = (string)reader["Nombre"];
                    departamento = new Departamento(id, nombre);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception e) {
                throw e;
            }

            return departamento;
        }
    }
}
