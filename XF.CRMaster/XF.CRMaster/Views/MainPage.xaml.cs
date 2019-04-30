using XF.CRMaster.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.CRMaster.DAO;
using XF.CRMaster.Services.viacep;

namespace XF.CRMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        private CustumersDataAccess _dataAccess;

        public MainPage()
        {
            // Chamada assincrona
            //Task<ViaCepDTO> viaCep = new ViaCepService().GetAddressByAsync("05882050");
            //Chamada sincrona
            //ViaCepDTO address = new ViaCepService().GetAddressBy("05882050");


            //_dataAccess = new CustumersDataAccess();
            //var id = _dataAccess.MockLead();

            //var repository = new Repositories.Repository<OpportunityModel>();
            //OpportunityModel model = new OpportunityModel();
            //model.Description = "Descrição com id: " + 1;
            //model.CreatedAt = new DateTime(2013, 01, 01);
            //model.Status = "Ativo";
            //model.IdLead = 1;
            //repository.Insert(model);




            //var teste = _dataAccess.GetAllLead();

            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Oportunidades, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Oportunidades:
                        MenuPages.Add(id, new NavigationPage(new OpportunitiesPage()));
                        break;
                    case (int)MenuItemType.Sobre:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}