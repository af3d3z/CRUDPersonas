using ENT;

namespace CRUDPersonas.Models.ViewModels
{
    public class PersonaDepartamentoVM
    {
        private Persona _persona;
        private Departamento _departamento;

        public Persona Persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        public Departamento Departamento {
            get { return _departamento; }
            set { _departamento = value; }
        }

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public PersonaDepartamentoVM() { }

        /// <summary>
        /// Constructor con persona
        /// </summary>
        /// <param name="p">Persona</param>
        public PersonaDepartamentoVM(Persona p) {
            _persona = p;
            try
            {
                _departamento = DAL.CRUDDepartamento.GetDepartamento(p.IDDepartamento);
            }
            catch (Exception e) {
                throw e;
            }
        }

    }
}
