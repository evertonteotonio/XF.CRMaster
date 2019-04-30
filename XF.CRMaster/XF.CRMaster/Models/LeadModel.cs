using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace XF.CRMaster.Models
{
    [Table("Lead")]
    public class LeadModel : BaseModel
    {

        private string _firstname;
        [NotNull, MaxLength(50)]
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                this._firstname = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastname;
        [NotNull, MaxLength(50)]
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                this._lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _email;
        [NotNull, MaxLength(255)]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                this._email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public override string ToString()
        {
            return string.Format("Nome = {0}, Sobrenome = {1}, Email = {2} ", FirstName, LastName, Email);
        }



    }
}
