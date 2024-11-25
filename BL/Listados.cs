using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Listados
    {
        /// <summary>
        /// Rescata la lista de personas de la capa DAL
        /// </summary>
        /// <returns></returns>
        public static List<Persona> GetListadoPersonasBL() {
            return DAL.Listados.GetListadoPersonasDAL();
        }

        /// <summary>
        /// Rescata la lista de departamentos de la capa DAL
        /// </summary>
        /// <returns></returns>
        public static List<Departamento> GetListadoDepartamentosBL() { 
            return DAL.Listados.GetListadoDepartamentosDAL();
        }
    }
}
