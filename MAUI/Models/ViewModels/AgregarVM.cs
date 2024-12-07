using ENT;
using MAUI.Models.Utilidades;
using MAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Models.ViewModels
{
    public class AgregarVM: Persona
    {
        private List<Departamento> _listaDepartamentos;
        private Departamento _departamentoSeleccionado;
        private DelegateCommand _agregarBtn;
        private DelegateCommand _volverBtn;

        public List<Departamento> ListaDepartamentos {
            get { return _listaDepartamentos; }
        }

        public Departamento DepartamentoSeleccionado { get { return _departamentoSeleccionado;  } set { _departamentoSeleccionado = value; } }

        public DelegateCommand AgregarBtn { get { return this._agregarBtn; } }
        public DelegateCommand VolverBtn { get { return this._volverBtn; } }


        public AgregarVM() {
            this._listaDepartamentos = BL.Listados.GetListadoDepartamentosBL();
            this._departamentoSeleccionado = _listaDepartamentos.FirstOrDefault();
            this._volverBtn = new DelegateCommand(btnVolverCommand_Execute);
            this._agregarBtn = new DelegateCommand(btnAgregarCommand_Execute);
        }

        #region commands
        private async void btnAgregarCommand_Execute() {
            Persona personaAgregador = new Persona(this.Nombre, this.Apellidos, this.Foto, this.Telefono, this.Direccion, this.FechaNacimiento, this._departamentoSeleccionado.ID);
            BL.ManejadoraPersonas.AgregarPersonaBL(personaAgregador);
            this.Nombre = string.Empty;
            this.Apellidos = string.Empty;
            this.Foto = string.Empty;
            this.FechaNacimiento = new DateTime();
            this.DepartamentoSeleccionado = this.ListaDepartamentos.First();
            btnVolverCommand_Execute();
        }

        private async void btnVolverCommand_Execute() {
            await Shell.Current.GoToAsync("//MainPage");
        }

        #endregion

    }
}
