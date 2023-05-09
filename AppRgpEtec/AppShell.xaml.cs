﻿using AppRgpEtec.ViewModels;
using AppRpgEtec.Views.Personagens;

namespace AppRgpEtec;

public partial class AppShell : Shell
{
	AppShellViewModel viewModel;
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("cadPersonagemView", typeof(CadastroPersonagemView));
		
		viewModel = new AppShellViewModel();
		BindingContext = viewModel;

		string login = Preferences.Get("UsuarioUsername", string.Empty);
		lblLogin.Text = $"Login: {login}";
	}
}
