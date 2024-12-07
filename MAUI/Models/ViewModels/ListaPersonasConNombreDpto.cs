using BL;
using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MAUI.Models.Utilidades;
using MAUI.Views;

namespace MAUI.Models.ViewModels
{
    public class ListaPersonasConNombreDpto : MAUI.Models.Utilidades.clsVMBase
    {
        #region atributos
        private DelegateCommand? _btnEliminarCommand;
        private DelegateCommand? _btnAgregarCommand;
        private DelegateCommand? _btnDetallesCommand;
        private DelegateCommand? _btnEditCommand;
        private PersonaConNombreDepartamento _personaSeleccionada = new PersonaConNombreDepartamento();
        private ObservableCollection<PersonaConNombreDepartamento> _listadoPersonasNombreDepartamento = new ObservableCollection<PersonaConNombreDepartamento>();
        #endregion


        #region properties
        public ObservableCollection<PersonaConNombreDepartamento> ListadoPersonasNombreDepartamento {
            get {
                return _listadoPersonasNombreDepartamento;
            }
        }
        public DelegateCommand BtnDetallesCommand {get{ return _btnDetallesCommand; } }
        public DelegateCommand BtnEliminarCommand { get { return _btnEliminarCommand; } }
        public DelegateCommand BtnEditarCommand { get { return _btnEditCommand; } }
        public DelegateCommand BtnAgregarCommand { get { return _btnAgregarCommand; } }

        public PersonaConNombreDepartamento PersonaSeleccionada
        {
            get { return _personaSeleccionada; }
            set {
                _personaSeleccionada = value;
                _btnEliminarCommand?.RaiseCanExecuteChanged();
                _btnDetallesCommand?.RaiseCanExecuteChanged();
                _btnEditCommand?.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }
        #endregion

        public ListaPersonasConNombreDpto() { 
            List<Departamento> departamentos = BL.Listados.GetListadoDepartamentosBL();
            List<Persona> personas = BL.Listados.GetListadoPersonasBL();

            foreach (Persona persona in personas){
                this._listadoPersonasNombreDepartamento.Add(new PersonaConNombreDepartamento(persona, departamentos));
            }

            this.PersonaSeleccionada = _listadoPersonasNombreDepartamento.FirstOrDefault();

            this._btnEliminarCommand = new DelegateCommand(btnEliminarCommand_Execute, btnEliminarCommand_CanExecute);
            this._btnAgregarCommand = new DelegateCommand(btnAgregarCommand_Execute);
            this._btnDetallesCommand = new DelegateCommand(btnDetallesCommand_Execute, btnDetallesCommand_CanExecute);
            this._btnEditCommand = new DelegateCommand(btnEditarCommand_Execute, btnEditCommand_CanExecute);
        }

        public void ActualizarLista() {
            List<Departamento> departamentos = BL.Listados.GetListadoDepartamentosBL();
            List<Persona> personas = BL.Listados.GetListadoPersonasBL();
            this._listadoPersonasNombreDepartamento.Clear();

            foreach (Persona persona in personas)
            {
                this._listadoPersonasNombreDepartamento.Add(new PersonaConNombreDepartamento(persona, departamentos));
            }
        }

        public ListaPersonasConNombreDpto(int idPersonaSeleccionada) {
            this._btnEliminarCommand = new DelegateCommand(btnEliminarCommand_Execute, btnEliminarCommand_CanExecute);
            this.PersonaSeleccionada = this._listadoPersonasNombreDepartamento.Where(per => per.ID == idPersonaSeleccionada).FirstOrDefault();
        }

        #region commands
        /// <summary>
        /// Verifica si se puede ejecutar o no el btn
        /// </summary>
        /// <returns></returns>
        private bool btnEliminarCommand_CanExecute() {
            bool canExecute = false;
            if (_personaSeleccionada != null) {
                canExecute = true;
            }

            return canExecute;
        }

        private bool btnDetallesCommand_CanExecute() {
            bool canExecute = false;
            if (_personaSeleccionada != null) {
                canExecute = true;
            }

            return canExecute;
        }

        /// <summary>
        /// Verifica si se puede ejecutar o no el btn
        /// </summary>
        /// <returns></returns>
        private bool btnEditCommand_CanExecute() {
            bool canExecute = false;
            if (_personaSeleccionada != null) {
                canExecute = true;
            }
            return canExecute;
        }

        /// <summary>
        /// Elimina del listado la persona seleccionada
        /// </summary>
        private void btnEliminarCommand_Execute() {
            this._listadoPersonasNombreDepartamento.Remove(this._personaSeleccionada);
            ManejadoraPersonas.BorrarPersonaBL(PersonaSeleccionada.ID);
        }

        /// <summary>
        /// Muestra los detalles de la persona seleccionada
        /// </summary>
        private async void btnDetallesCommand_Execute() {
            await Application.Current.MainPage.Navigation.PushAsync(new Detalles(_personaSeleccionada.ID));
        }

        private async void btnEditarCommand_Execute() {
            Persona persona = BL.ManejadoraPersonas.GetPersonaBL(_personaSeleccionada.ID);
            if (persona != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Editar(persona));
            }
        }

        /// <summary>
        /// Redirige al usuario a la vista de agregado
        /// </summary>
        private async void btnAgregarCommand_Execute() {
            await Shell.Current.GoToAsync("//Agregar");
        }
        #endregion
    }
}
