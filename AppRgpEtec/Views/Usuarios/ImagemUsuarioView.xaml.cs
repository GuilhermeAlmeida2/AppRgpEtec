using AppRgpEtec.ViewModels.Usuarios;

namespace AppRgpEtec.Views.Usuarios;

public partial class ImagemUsuarioView : ContentPage
{
    ImagemUsuarioViewModel viewModel;
    public ImagemUsuarioView()
    {
        InitializeComponent();

        viewModel = new ImagemUsuarioViewModel();
        Title = "Imagem do Usuario";
        BindingContext = viewModel;
    }
}