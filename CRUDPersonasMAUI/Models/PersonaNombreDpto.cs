using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonasMAUI.Models
{
    public class PersonaNombreDpto : Persona
    {
        public string NombreDepartamento { get; }

        public PersonaNombreDpto(Persona persona, List<Departamento> departamentos)
        {
            Departamento departamentoPersona = departamentos.Find(depto => depto.ID == persona.IDDepartamento);
            if (departamentoPersona != null)
            {
                NombreDepartamento = departamentoPersona.Nombre;
            }
        }
    }
}
