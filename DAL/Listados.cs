using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Listados
    {
        /// <summary>
        /// Función estática que devuelve una lista de personas desde la base de datos
        /// </summary>
        /// <returns>List<Persona> lista de  personas rescatadas de la bd</returns>
        public static List<Persona> GetListadoPersonasDAL() {
            List<Persona> personas = new List<Persona>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            try {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.CommandText = "SELECT * FROM Personas";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id = (int)reader["ID"];
                        string nombre = (string)reader["Nombre"];
                        string apellidos = (string)reader["Apellidos"];
                        DateTime fechaNac = (DateTime)reader["FechaNacimiento"];
                        string foto = "No disponible";
                        if (reader["Foto"] != System.DBNull.Value) {
                            foto = (string)reader["Foto"];
                        }
                        string direccion = (string)reader["Direccion"];
                        string telefono = (string)reader["Telefono"];
                        int idDepto = (int)reader["IDDepartamento"];

                        Persona p = new Persona(id, nombre, apellidos, foto, telefono, direccion, fechaNac, idDepto);
                        personas.Add(p);
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex) {
                throw ex;
            }

            return personas;
        }

        /// <summary>
        /// Devuelve un listado de departamentos de la base de datos
        /// </summary>
        /// <returns>List<Departamento> lista de departamentos rescatados de la bd</returns>
        public static List<Departamento> GetListadoDepartamentosDAL()
        {
            List<Departamento> departamentos = new List<Departamento>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            try
            {
                SqlConnection conn = ConexionDB.GetConexion();
                cmd.CommandText = "SELECT * FROM Departamento";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string nombre = (string)reader["Nombre"];

                        Departamento depto = new Departamento(id, nombre);
                        departamentos.Add(depto);
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return departamentos;
        }
    }
}
