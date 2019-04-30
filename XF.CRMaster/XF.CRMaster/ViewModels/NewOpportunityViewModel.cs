using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XF.CRMaster.Models;
using XF.CRMaster.Repositories;

namespace XF.CRMaster.ViewModels
{
    public class NewOpportunityViewModel : BaseViewModel
    {
        private List<string> _leads = new List<string>();

        private OpportunityModel _model;

        private Repository<LeadModel> LeadRepository;


        public NewOpportunityViewModel()
        {
            LeadRepository = new Repository<LeadModel>();
            var leads = LeadRepository.GetAll();

            foreach(LeadModel lead in leads)
            {
                _leads.Add(lead.FirstName + " " + lead.LastName);
            }

        }

        public List<string> Leads
        {
            get { return _leads; }
            private set
            {
                _leads = value;
                OnPropertyChanged();
            }
        }

        public OpportunityModel Model
        {
            get { return _model; }
            private set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public RepositoryAsync<OpportunityModel> GetRepository()
        {
            return new RepositoryAsync<OpportunityModel>(GetConnection());
        }


    }
}
