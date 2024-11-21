using ENT;

namespace CRUDPersonas.Models.ViewModels
{
    public class PersonaListaDepartamentos
    {
        private Persona _persona;
        private List<Departamento> _listadoDepartamentos;

        public Persona Persona {
            get { return _persona; }
            set { _persona = value; }
        }

        public List<Departamento> ListadoDepartamentos {
            get { return _listadoDepartamentos; }
            set { _listadoDepartamentos = value; }
        }

        public PersonaListaDepartamentos(Persona p)
        {
            _persona = p;
            try
            {
                _listadoDepartamentos = DAL.Listados.GetListadoDepartamentosDAL();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public PersonaListaDepartamentos()
        {
        }
    }
}
