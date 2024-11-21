using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CRUDPersona
    {
        /// <summary>
        /// Devuelve una persona de la base de datos a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Persona de la base de datos con ese ID</returns>
        public static Persona GetPersona(int id) {
            Persona persona = new Persona();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.CommandText = "SELECT * FROM Personas WHERE ID = @id";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader.HasRows) {
                    reader.Read();
                    string nombre = (string)reader["Nombre"];
                    string apellidos = (string)reader["Apellidos"];
                    DateTime fechaNac = (DateTime)reader["FechaNacimiento"];
                    string foto = "No disponible";
                    if (reader["Foto"] != System.DBNull.Value)
                    {
                        foto = (string)reader["Foto"];
                    }
                    string direccion = (string)reader["Direccion"];
                    string telefono = (string)reader["Telefono"];
                    int idDepto = (int)reader["IDDepartamento"];

                    persona = new Persona(id, nombre, apellidos, foto, telefono, direccion, fechaNac, idDepto);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e) {
                throw e;
            }

            return persona;
        }

        /// <summary>
        /// Agrega una persona a la base de datos
        /// </summary>
        /// <param name="persona">Persona a agregar</param>
        /// <returns>Devuelve el número de filas afectadas, si es uno es que se ha completado la operación.</returns>
        public static int AgregarPersona(Persona persona) {
            int affectedRows = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            cmd.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
            cmd.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            cmd.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
            cmd.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IDDepartamento;

            try {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.CommandText = "INSERT INTO Personas VALUES (@nombre, @apellidos, @telefono, @direccion, @foto, @fechaNac, @idDepartamento)";
                cmd.Connection = conn;
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw e;
            }

            return affectedRows;
        }

        /// <summary>
        /// Modifica una persona en la base de datos
        /// </summary>
        /// <param name="persona">Persona a modificar</param>
        /// <returns>Devuelve el número de filas afectadas, si es uno es que se ha completado la operación.</returns>
        public static int ModificarPersona(Persona persona)
        {
            int affectedRows = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.ID;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            cmd.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
            cmd.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            cmd.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
            cmd.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IDDepartamento;

            try
            {

                SqlConnection conn = ConexionDB.GetConexion();
                cmd.CommandText = "UPDATE Personas SET Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono, Direccion = @direccion, Foto = @foto, FechaNacimento = fechaNac, IDDepartamento = @idDepartamento WHERE ID = @id";
                cmd.Connection = conn;
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return affectedRows;
        }

        /// <summary>
        /// Elimina una persona de la base de datos
        /// </summary>
        /// <param name="id">Id de la persona a borrar</param>
        /// <returns>Devuelve el número de filas afectadas, si es uno es que se ha completado la operación.</returns>
        public static int BorrarPersona(int id) {
            int affectedRows = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.CommandText = "DELETE FROM Personas WHERE ID = @id";
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
