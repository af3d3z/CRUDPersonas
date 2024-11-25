using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonasMAUI.Models.ViewModels
{
    public class ListaPersonasNombreDepartamento
    {
        private List<PersonaNombreDpto> _listaPersonaNombreDpto = new List<PersonaNombreDpto>();

        public List<PersonaNombreDpto> ListaPersonasNombreDpto
        {
            get {
                return _listaPersonaNombreDpto;
            }
        }

        public ListaPersonasNombreDepartamento() { 
            List<Departamento> departamentos = BL.Listados.GetListadoDepartamentosBL();
            List<Persona> personas = BL.Listados.GetListadoPersonasBL();

            foreach (Persona persona in personas) {
                this._listaPersonaNombreDpto.Add(new PersonaNombreDpto(persona, departamentos));
            }
        }
    }
}
