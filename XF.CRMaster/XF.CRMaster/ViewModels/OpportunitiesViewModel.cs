using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF.CRMaster.Models;
using XF.CRMaster.Repositories;
using XF.CRMaster.Views;

namespace XF.CRMaster.ViewModels
{
    public class OpportunitiesViewModel : BaseViewModel
    {
        private RepositoryAsync<OpportunityModel> OpportunityRepository;

        public ObservableCollection<OpportunityModel> Opportunities { get; set; }
        public Command LoadOpportunitiesCommand { get; set; }

        public OpportunitiesViewModel()
        {
            OpportunityRepository = new RepositoryAsync<OpportunityModel>(GetConnection());
            Title = "Oportunidades";
            Opportunities = new ObservableCollection<OpportunityModel>();
            LoadOpportunitiesCommand = new Command(async () => await ExecuteLoadOpportunitiesCommand());

            MessagingCenter.Subscribe<NewOpportunityPage, OpportunityModel>(this, "Adicionar", async (obj, item) =>
            {
                var newOpportunity = item as OpportunityModel;
                Opportunities.Add(newOpportunity);
                await OpportunityRepository.Insert(newOpportunity);
            });
        }

        async Task ExecuteLoadOpportunitiesCommand()
        {
            if (IsBusy)
                return;

            //IsBusy = true;

            try
            {

                List<OpportunityModel> opportunities = await OpportunityRepository.Get();
                
                foreach(OpportunityModel opportunity in opportunities)
                {   
                    Opportunities.Add(opportunity);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}