using MAUI.Models;

namespace MAUI.Views;

public partial class Detalles : ContentPage
{
	public Detalles(int idPersona)
	{
		InitializeComponent();
		BindingContext = new PersonaConNombreDepartamento(BL.ManejadoraPersonas.GetPersonaBL(idPersona));
	}
}