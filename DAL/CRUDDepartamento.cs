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

        /// <summary>
        /// Agrega un departamento a la base de datos
        /// </summary>
        /// <param name="dpto"></param>
        /// <returns>Devuelve el número de filas afectadas, si es uno, es que se ha completado la operación.</returns>
        public static int AgregarDepartamento(Departamento dpto) {
            int affectedRows = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = dpto.ID;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = dpto.Nombre;
            try
            {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.CommandText = "INSERT INTO Departamentos VALUES (@id, @nombre)";
                cmd.Connection = conn;
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw e;
            }
            return affectedRows;
        }

        /// <summary>
        /// Modifica un departamento de la base de datos
        /// </summary>
        /// <param name="dpto">Departamento a actualizar</param>
        /// <returns>Devuelve el número de filas afectadas, si es uno, es que se ha completado la operación.</returns>
        public static int ModificarDepartamento(Departamento dpto) { 
            int affectedRows = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = dpto.ID;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = dpto.Nombre;
            try
            {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.CommandText = "UPDATE Departamentos WHERE ID = @id SET Nombre = @nombre";
                cmd.Connection = conn;
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw e;
            }
            return affectedRows;
        }

        /// <summary>
        /// Borra un departamento de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve el número de filas afectadas, si es uno, es que se ha completado la operación.</returns>
        public static int BorrarDepartamento(int id) {
            int affectedRows = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.CommandText = "DELETE FROM Departamentos WHERE ID = @id";
                cmd.Connection = conn;
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw e;
            }
            return affectedRows;
        }
    }
}
