using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Departamento
    {
        #region atributos
        private int _id;
        private string _nombre;
        #endregion

        #region propiedades
        public int ID {
            get { return _id; }
        }

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Departamento() { }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public Departamento(int id, string nombre) {
            this._id = id;
            this._nombre = nombre;
        }
        #endregion
    }
}
