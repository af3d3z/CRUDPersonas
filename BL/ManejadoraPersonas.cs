using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ManejadoraPersonas
    {
        /// <summary>
        /// Rescata una persona de la base de datos en base a su id
        /// PRE: el id debe ser mayor a 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Persona GetPersonaBL(int id) {
            return DAL.CRUDPersona.GetPersona(id);
        }

        /// <summary>
        /// Agrega una persona a la base de datos
        /// PRE: la persona debe estar rellena
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int AgregarPersonaBL(Persona persona)
        {
            return DAL.CRUDPersona.AgregarPersona(persona);
        }

        /// <summary>
        /// Modifica una persona en la base de datos
        /// PRE: la persona debe estar rellena
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int ModificarPersonaBL(Persona persona) {
            return DAL.CRUDPersona.ModificarPersona(persona);
        }

        /// <summary>
        /// Borra una persona de la bd
        /// PRE: el id debe ser mayor a 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int BorrarPersonaBL(int id) {
            return DAL.CRUDPersona.BorrarPersona(id);
        }
    }
}
