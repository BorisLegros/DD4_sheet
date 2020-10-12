using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace DD4_Sheet.Models
{
    public class Amend
    {
        public int Value
        {
            get
            {
                return Value;
            }
            set
            {
                if (IsModifiable)
                {
                    Value = value;
                }
            }
        }

        public string Reason
        {
            get
            {
                return Reason;
            }
            set
            {
                if (IsModifiable)
                {
                    Reason = value;
                }
            }
        }

        public readonly bool IsModifiable = true;

        public Amend (int v, string r, bool m = true)
        {
            Value = v;
            Reason = r;
            IsModifiable = m;
        }

        public string ToXML ()
        {
            using (var writer = new StringWriter())
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
                return writer.ToString();
            }
        }

        public static Amend LoadXML (string xml)
        {
            using (var reader = new StringReader(xml))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Amend));
                return serializer.Deserialize(reader) as Amend;
            }
        }
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

            foreach (Amend a in _listAmend)
            {
                string signe = (a.Value > 0) ? "+" : "";
                rtn += signe + " : " + a.Reason + '\n';
            }

            return rtn;
        }

        public string ToXML()
        {
            using (var writer = new StringWriter())
            {
                FeatureXML fXml = new FeatureXML(this);

                var serializer = new System.Xml.Serialization.XmlSerializer(fXml.GetType());
                serializer.Serialize(writer, fXml);
                return writer.ToString();
            }
        }

        public static Feature LoadXML (string xml)
        {
            using (var reader = new StringReader(xml))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(FeatureXML));
                FeatureXML fXml = serializer.Deserialize(reader) as FeatureXML;

                return fXml.ToFeature();
            }
        }
    }

    public class FeatureXML
    {
        private string _name;
        private int _base, _race;
        private List<string> _listAmend;

        public FeatureXML (Feature f)
        {
            _name = f.Name;
            _base = f.BaseValue;
            _race = f.BonusRace;

            _listAmend = new List<string>(f.Amends.Count);
            foreach (Amend a in f.Amends)
            {
                _listAmend.Add(a.ToXML());
            }
        }

        public Feature ToFeature ()
        {
            Feature rtn = new Feature(_name);

            rtn.BaseValue = _base;
            rtn.BonusRace = _race;

            rtn.Amends = new List<Amend>();
            foreach (string s in _listAmend)
            {
                rtn.Amends.Add(Amend.LoadXML(s));
            }

            return rtn;
        }
    }
}
