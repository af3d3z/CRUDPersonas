using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Models
{
    public class PersonaConNombreDepartamento: Persona
    {
        public string NombreDepartamento { get; }

        public PersonaConNombreDepartamento() { }

        public PersonaConNombreDepartamento(Persona persona): base(persona) {
            Departamento depto = BL.Listados.GetListadoDepartamentosBL().Where(dpto => dpto.ID == persona.IDDepartamento).FirstOrDefault();
            if (depto != null)
            {
                this.NombreDepartamento = depto.Nombre;
            }
            else {
                this.NombreDepartamento = "Departamento no encontrado";
            }
        }

        public PersonaConNombreDepartamento(Persona persona, List<Departamento> departamentos) : base(persona) {
            Departamento depto = BL.Listados.GetListadoDepartamentosBL().Where(dpto => dpto.ID == persona.IDDepartamento).FirstOrDefault();
            if (depto != null)
            {
                this.NombreDepartamento = depto.Nombre;
            }
            else {
                this.NombreDepartamento = "Departamento no encontrado";
            }
        }
    }
}
