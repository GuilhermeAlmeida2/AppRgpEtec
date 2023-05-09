using AppRpgEtec.ViewModels.Personagens;

namespace AppRgpEtec.Views.Personagens;

public partial class ListagemView : ContentPage
{
	private ListagemPersonagemViewModel viewModel;
	public ListagemView()
	{
		InitializeComponent();

		viewModel= new ListagemPersonagemViewModel();
		BindingContext = viewModel;
		Title = "Personagens - App Rpg Etec";
	
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		_ = viewModel.ObterPersonagens();
    }



}