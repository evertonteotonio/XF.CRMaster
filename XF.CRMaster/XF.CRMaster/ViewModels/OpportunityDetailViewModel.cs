using System;

using XF.CRMaster.Models;
using XF.CRMaster.Repositories;
using XF.CRMaster.Views;

namespace XF.CRMaster.ViewModels
{
    public class OpportunityDetailViewModel : BaseViewModel
    {

        private Repository<LeadModel> LeadRepository;

        private Repository<OpportunityModel> OpportunityRepository;

        public OpportunityModel Opportunity { get; set; }

        public LeadModel Lead { get; set; }

        public string Title
        {
            get
            {
                return "Detalhes da oportunidade";
            }
        }

        public void DeletOpportunity(int id)
        {
            try
            {
                
                OpportunityRepository = new Repository<OpportunityModel>();
                var entity = OpportunityRepository.Get(id);
                OpportunityRepository.Delete(entity);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public OpportunityDetailViewModel(OpportunityModel opportunity = null)
        {
            try
            {
                LeadRepository = new Repository<LeadModel>();
                Lead = LeadRepository.Get(opportunity.IdLead);
                Opportunity = opportunity;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public string FullName
        {
            get
            {
                if(Lead == null)
                {
                    Lead = new LeadModel
                    {
                        FirstName = "",
                        LastName = ""
                    };
                }
                return string.Format("{0}  {1} ", Lead.FirstName, Lead.LastName);
            }
        }

    }
}
