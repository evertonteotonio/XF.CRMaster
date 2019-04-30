using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF.CRMaster.Models;
using XF.CRMaster.Services.viacep;
using XF.CRMaster.ViewModels;

namespace XF.CRMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOpportunityPage : ContentPage
    {

        NewOpportunityViewModel viewModel;

        public NewOpportunityPage()
        {
            viewModel = new NewOpportunityViewModel();
            InitializeComponent();
            BindingContext = viewModel;
        }


        private void PckLead_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelecionado = PckLead.Items[PckLead.SelectedIndex];
            DisplayAlert(itemSelecionado, "Selecionado", "OK");
        }

        async void Save_Clicked(object sender, EventArgs e)
        {

            OpportunityModel Model = new OpportunityModel()
            {
                IdLead = Convert.ToInt32(IdLead.Text),
                Description = Description.Text,
                Cep = Cep.Text,
                Logradouro = Logradouro.Text,
                Complemento = Complemento.Text,
                Bairro = Bairro.Text,
                Localidade = Localidade.Text,
                Uf = Uf.Text,
                Numero = Numero.Text,
                Status = ""

            };

            await viewModel.GetRepository().Insert(Model);

            //MessagingCenter.Send(this, "AddItem", Item);
            //await Navigation.PopModalAsync();
            //await Navigation.PushAsync(new MainPage());
            Application.Current.MainPage = new MainPage();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void OnEnterPressed(object sender, EventArgs e)
        {
            if(Cep.Text.Length == 8)
            {
                ViaCepService viaCep = new ViaCepService();
                ViaCepDTO address = await viaCep.GetAddressByAsync(Cep.Text);

                Logradouro.Text = address.Logradouro;
                Bairro.Text = address.Bairro;
                Localidade.Text = address.Localidade;
                Uf.Text = address.Uf;
                Complemento.Text = address.Complemento;


            }


        }
    }
}