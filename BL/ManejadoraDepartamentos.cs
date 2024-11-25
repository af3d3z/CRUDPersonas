using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ManejadoraDepartamentos
    {
        /// <summary>
        /// Devuelve un departamento de la base de datos
        /// PRE: el id debe ser mayor a 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Departamento GetDepartamentoBL(int id) { 
            return DAL.CRUDDepartamento.GetDepartamento(id);
        }
    }
}
