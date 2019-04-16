using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DD4_Sheet.Models
{
    public struct Amend
    {
        public int Value;
        public string Reason;
        public bool IsModifiable;
    }


    public class Feature : INotifyPropertyChanged
    {
        public string Name
        {
            get { return _name; }
        }

        public int BaseValue
        {
            get
            {
                return _base;
            }
            set
            {
                if (_base != value)
                {
                    _base = value;
                    OnPropertyChanged("BaseValue");
                }
            }
        }

        public int BonusRace
        {
            get
            {
                return _race;
            }
            set
            {
                if (_race != value)
                {
                    _race = value;
                    OnPropertyChanged("BonusRace");
                }
            }
        }

        public List<Amend> Amends
        {
            get
            {
                return _listAmend;
            }
            set
            {
                if (_listAmend != value)
                {
                    _listAmend = value;
                    OnPropertyChanged("Amends");
                }
            }
        }

        public int Value
        {
            get
            {
                int rtn = 0;

                rtn += _base + _race;

                foreach (Amend a in _listAmend)
                {
                    rtn += a.Value;
                }

                return rtn;
            }
        }

        public int Modificateur { get { return (Value - 10) / 2; } }

        private readonly string _name;
        private int _base, _race;
        private List<Amend> _listAmend;

        public event PropertyChangedEventHandler PropertyChanged;


        public Feature (string nn)
        {
            _name = nn;
            _base = 0;
            _race = 0;

            _listAmend = new List<Amend>();
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ToStringAmends ()
        {
            string rtn = "";

            foreach(Amend a in _listAmend)
            {
                string signe = (a.Value > 0) ? "+" : "";
                rtn += signe + " : " + a.Reason + '\n';
            }

            return rtn;
        }
    }
}
