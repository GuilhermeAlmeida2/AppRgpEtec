using AppRpgEtec.ViewModels.Personagens;

namespace AppRpgEtec.Views.Personagens;

public partial class CadastroPersonagemView : ContentPage
{
	private CadastroPersonagemViewModel cadViewModel;
	public CadastroPersonagemView()
	{
		cadViewModel = new CadastroPersonagemViewModel();
		BindingContext= cadViewModel;
		Title = "Novo Personagem";

		InitializeComponent();
	}
}