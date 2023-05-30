
using AppRpgEtec.Models;
using AppRpgEtec.Services.Armas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Armas
{
    public class ListagemArmaViewModel : BaseViewModel
    {
        private ArmaService aService;
        public ObservableCollection<Arma> Armas { get; set; }

        public ListagemArmaViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            aService = new ArmaService(token);
            Armas = new ObservableCollection<Arma>();
            _ = ObterArmas();

        }
        public ICommand NovoArma { get; }
        public ICommand RemoverArmaCommand { get; }

        public async Task ObterArmas()
        {
            try
            {
                Armas = await aService.GetArmasAsync();
                OnPropertyChanged(nameof(Armas));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task ExibirCadastroArma()
        {
            try
            {
                await Shell.Current.GoToAsync("cadArmaView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private Arma armaSelecionado;

        public Arma ArmaSelecionado
        {
            get { return armaSelecionado; }
            set
            {
                if (value != null)
                {
                    ArmaSelecionado = value;

                    Shell.Current.GoToAsync($"cadArmaView?pId={ArmaSelecionado.Id}");
                }
            }
        }

        public async Task RemoverArma(Arma a)
        {
            try
            {
                if (await Application.Current.MainPage.DisplayAlert("Confirmação", $"Confirma a remoção de {a.Nome}?", "Sim", "Não"))
                {
                    await aService.DeleteArmaAsync(a.Id);

                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Arma removida com sucesso!", "Ok");

                    _ = ObterArmas();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                  .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }



    }
}
