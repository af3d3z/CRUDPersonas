namespace ENT
{
    public class Persona
    {
        #region atributos
        private int _id;
        private String _nombre;
        private String _apellidos;
        private String _foto;
        private String _telefono;
        private String _direccion;
        private DateTime _fechaNacimiento;
        private int _idDepartamento;
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

        public String Apellidos {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public String Foto {
            get { return _foto; }
            set { _foto = value; }
        }

        public String Telefono {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public String Direccion {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public DateTime FechaNacimiento {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public int IDDepartamento {
            get { return _idDepartamento; }
            set { _idDepartamento = value; }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor vacío de Persona
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor con todos los parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="foto"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="idDepartamento"></param>
        public Persona(int id, string nombre, string apellidos, string foto, string telefono, string direccion, DateTime fechaNacimiento, int idDepartamento)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._foto = foto;
            this._telefono = telefono;
            this._direccion = direccion;
            this._fechaNacimiento = fechaNacimiento;
            this._idDepartamento = idDepartamento;
        }


        #endregion
    }
}
