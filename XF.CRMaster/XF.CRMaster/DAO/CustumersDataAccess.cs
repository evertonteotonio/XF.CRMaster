using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XF.CRMaster.Models;

namespace XF.CRMaster.DAO
{
    class CustumersDataAccess
    {

        private SQLiteConnection _connection { get; set; }
        private static object CollisionLock = new object();

        public ObservableCollection<LeadModel> Lead { get; set; }
        public ObservableCollection<OpportunityModel> Opportunity { get; set; }

        public CustumersDataAccess()
        {
            Setup();
        }

        public SQLiteConnection GetConnection()
        {
            return _connection;
        }

        private void Setup()
        {
            var Database = DependencyService.Get<IDatabaseConnection>();
            _connection = Database.GetConnection();
            _connection.CreateTable<LeadModel>();
            _connection.CreateTable<OpportunityModel>();

            this.Lead = new ObservableCollection<LeadModel>(_connection.Table<LeadModel>());
            this.Opportunity = new ObservableCollection<OpportunityModel>(_connection.Table<OpportunityModel>());

        }

        public IEnumerable<LeadModel> FindByEmail(string email)
        {

            lock(CollisionLock)
            {
                var query = from lead in _connection.Table<LeadModel>()
                            where lead.Email == email
                            select lead;
                return query.AsEnumerable();
            }

        }

        public IEnumerable<LeadModel> FindByEmail()
        {

            lock (CollisionLock)
            {
                return _connection.
                    Query<LeadModel>("select * from Lead where id = 1").AsEnumerable();
            }

        }

        public IEnumerable<LeadModel> GetAllLead()
        {

            lock (CollisionLock)
            {
                return _connection.
                    Query<LeadModel>("select * from Lead").AsEnumerable();
            }

        }

        public int SaveLead(LeadModel lead)
        {
            lock (CollisionLock)
            {
                if(lead.Id != 0)
                {
                    _connection.Update(lead);
                    return lead.Id;
                }
                else
                {
                    _connection.Insert(lead);
                    return lead.Id;
                }
            }
        }

        public int DeleteLead(LeadModel lead)
        {
            var id = lead.Id;
            if(id != 0)
            {
                lock (CollisionLock)
                {
                    _connection.Delete<LeadModel>(id);
                }
            }
            this.Lead.Remove(lead);
            return id;
        }

        public void DeleteAllLead()
        {
            lock (CollisionLock)
            {
                _connection.DropTable<LeadModel>();
                _connection.CreateTable<LeadModel>();
            }
            this.Lead = null;
            this.Lead = new ObservableCollection<LeadModel>(_connection.Table<LeadModel>());
        }

        public int MockLead()
        {
            LeadModel lead = new LeadModel();
            lead.FirstName = "Everton";
            lead.LastName = "Teotonio";
            lead.Email = "evertontt@gmail.com";
            return SaveLead(lead);
        }


    }
}
