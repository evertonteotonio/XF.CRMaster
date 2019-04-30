using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF.CRMaster.Models;
using XF.CRMaster.Views;
using XF.CRMaster.ViewModels;

namespace XF.CRMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpportunitiesPage : ContentPage
    {
        OpportunitiesViewModel viewModel;

        public OpportunitiesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new OpportunitiesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var opportunity = args.SelectedItem as OpportunityModel;
            if (opportunity == null)
                return;

            await Navigation.PushAsync(new OpportunityDetailPage(new OpportunityDetailViewModel(opportunity)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewOpportunityPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Opportunities == null || viewModel.Opportunities.Count == 0)
                viewModel.LoadOpportunitiesCommand.Execute(null);
        }
    }
}