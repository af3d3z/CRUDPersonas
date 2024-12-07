using ENT;
using MAUI.Models;
using MAUI.Models.ViewModels;

namespace MAUI.Views {
    public partial class Editar : ContentPage
    {
        public Editar(Persona personaSeleccionada)
        {
            InitializeComponent();
            EditarVM vm = new EditarVM(personaSeleccionada);
            BindingContext = vm;
        }
    }
}