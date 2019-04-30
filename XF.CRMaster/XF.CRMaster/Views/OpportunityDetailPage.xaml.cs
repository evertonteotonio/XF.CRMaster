using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF.CRMaster.Models;
using XF.CRMaster.ViewModels;

namespace XF.CRMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpportunityDetailPage : ContentPage
    {
        OpportunityDetailViewModel viewModel;

        public OpportunityDetailPage(OpportunityDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public OpportunityDetailPage()
        {
            InitializeComponent();

            var opportunity = new OpportunityModel
            {
                Status = "Bloqueado",
                Description = "Descrição de oportunidade!",
                CreatedAt = new DateTime()

            };

            viewModel = new OpportunityDetailViewModel(opportunity);
            BindingContext = viewModel;
        }

        async void DeletButtonClicked(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(IdOpportunityLabel.Text);
            viewModel.DeletOpportunity(id);

            //await Navigation.PushAsync(new MainPage());
            //await Navigation.PushAsync(new NavigationPage(new MainPage()));
            //await Navigation.PushAsync(new MainPage());
            Application.Current.MainPage = new MainPage();
        }
    }
}