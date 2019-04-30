using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XF.CRMaster.Models
{
    [Table("Opportunity")]
    public class OpportunityModel : BaseModel
    {

        private int _idLead;
        [NotNull]
        public int IdLead
        {
            get
            {
                return _idLead;
            }
            set
            {
                this._idLead = value;
                OnPropertyChanged(nameof(IdLead));
            }
        }

        private string _description;
        [NotNull, MaxLength(250)]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                this._description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _status;
        [NotNull, MaxLength(250)]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                this._status = value;
                OnPropertyChanged(nameof(Status));
            }
        }


        private string _cep;
        public string Cep
        {
            get
            {
                return _cep;
            }
            set
            {
                this._cep = value;
                OnPropertyChanged(nameof(Cep));
            }
        }

        private string _logradouro;
        public string Logradouro
        {
            get
            {
                return _logradouro;
            }
            set
            {
                this._logradouro = value;
                OnPropertyChanged(nameof(Logradouro));
            }
        }

        private string _complemento;
        public string Complemento
        {
            get
            {
                return _complemento;
            }
            set
            {
                this._complemento = value;
                OnPropertyChanged(nameof(Complemento));
            }
        }

        private string _bairro;
        public string Bairro
        {
            get
            {
                return _bairro;
            }
            set
            {
                this._bairro = value;
                OnPropertyChanged(nameof(Bairro));
            }
        }

        private string _localidade;
        public string Localidade
        {
            get
            {
                return _localidade;
            }
            set
            {
                this._localidade = value;
                OnPropertyChanged(nameof(Localidade));
            }
        }

        private string _uf;
        public string Uf
        {
            get
            {
                return _uf;
            }
            set
            {
                this._uf = value;
                OnPropertyChanged(nameof(Uf));
            }
        }

        private string _numero;
        public string Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                this._numero = value;
                OnPropertyChanged(nameof(Numero));
            }
        }



    }
}
