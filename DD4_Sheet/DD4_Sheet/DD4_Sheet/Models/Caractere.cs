using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace DD4_Sheet.Models
{
    public class Caractere : INotifyPropertyChanged
    {
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Classe
        {
            get
            {
                return _classe;
            }
            set
            {
                if (_classe != value)
                {
                    _classe = value;
                    OnPropertyChanged("Classe");
                }
            }
        }

        public string Race
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
                    OnPropertyChanged("Race");
                }
            }
        }

        public string ParangonPath
        {
            get
            {
                return _paranP;
            }
            set
            {
                if (_paranP != value)
                {
                    _paranP = value;
                    OnPropertyChanged("ParangonPath");
                }
            }
        }

        public string EpicDestiny
        {
            get
            {
                return _epicD;
            }
            set
            {
                if (_epicD != value)
                {
                    _epicD = value;
                    OnPropertyChanged("EpicDestiny");
                }
            }
        }

        public string Languages
        {
            get
            {
                return _lang;
            }
            set
            {
                if (_lang != value)
                {
                    _lang = value;
                    OnPropertyChanged("Languages");
                }
            }
        }

        public string Description
        {
            get
            {
                return _descr;
            }
            set
            {
                if (_descr != value)
                {
                    _descr = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string Background
        {
            get
            {
                return _bg;
            }
            set
            {
                if (_bg != value)
                {
                    _bg = value;
                    OnPropertyChanged("Background");
                }
            }
        }

        public string ParangonBG
        {
            get
            {
                return _paranBG;
            }
            set
            {
                if (_paranBG != value)
                {
                    _paranBG = value;
                    OnPropertyChanged("ParangonBG");
                }
            }
        }

        public string EpicDestinyBG
        {
            get
            {
                return _epicBG;
            }
            set
            {
                if (_epicBG != value)
                {
                    _epicBG = value;
                    OnPropertyChanged("EpicDestinyBG");
                }
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }
            set
            {
                if (_xp != value)
                {
                    _xp = value;
                    OnPropertyChanged("Xp");
                    OnPropertyChanged("Lvl");
                }
            }
        }

        public int Lvl
        {
            get
            {
                int rtn = 0;

                foreach (int val in _tabLvl)
                {
                    if (_xp < val) { break; }

                    rtn++;
                }

                return rtn;
            }
        }

        public Dictionary<string, Feature> Features { get; set; }



        public Feature Strenght { get { return _for; } set { _for = value; } }
          /*public Feature Constitution { get { return _con; } set { _con = value; } }
         public Feature Dexterity { get { return _dex; } set { _dex = value; } }
         public Feature Intelligence { get { return _int; } set { _int = value; } }
         public Feature Wisdom { get { return _sag; } set { _sag = value; } }
         public Feature Charisma { get { return _cha; } set { _cha = value; } }

         private Feature _for, _con, _dex, _int, _sag, _cha;
         */

        private Feature _for;
        private string _name, _classe, _race, _paranP, _epicD, _lang, _descr, _bg, _paranBG, _epicBG;
        private int _xp;
        private List<int> _tabLvl;
        //private Dictionary<string, Feature> _features;

        public event PropertyChangedEventHandler PropertyChanged;

        public Caractere ()
        {
            Xp = 0;

            _tabLvl = new List<int>(30);
            _tabLvl.Add(0);
            _tabLvl.Add(1000);
            _tabLvl.Add(2250);
            _tabLvl.Add(3750);
            _tabLvl.Add(5500);
            _tabLvl.Add(7500);
            _tabLvl.Add(10000);
            _tabLvl.Add(13000);
            _tabLvl.Add(16500);
            _tabLvl.Add(20500);
            _tabLvl.Add(26000);
            _tabLvl.Add(32000);
            _tabLvl.Add(39000);
            _tabLvl.Add(47000);
            _tabLvl.Add(57000);
            _tabLvl.Add(69000);
            _tabLvl.Add(83000);
            _tabLvl.Add(99000);
            _tabLvl.Add(119000);
            _tabLvl.Add(143000);
            _tabLvl.Add(175000);
            _tabLvl.Add(210000);
            _tabLvl.Add(255000);
            _tabLvl.Add(310000);
            _tabLvl.Add(375000);
            _tabLvl.Add(450000);
            _tabLvl.Add(550000);
            _tabLvl.Add(675000);
            _tabLvl.Add(825000);
            _tabLvl.Add(1000000);

            Features = new Dictionary<string, Feature>(6);
            Features.Add("for", new Feature("Force"));
            Features.Add("con", new Feature("Constitution"));
            Features.Add("dex", new Feature("Dexterité"));
            Features.Add("int", new Feature("Intelligence"));
            Features.Add("sag", new Feature("Sagesse"));
            Features.Add("cha", new Feature("Charisme"));

            
            _for = new Feature("Force");
            /*_con = new Feature("Constitution");
            _dex = new Feature("Dexterité");
            _int = new Feature("Intelligence");
            _sag = new Feature("Sagesse");
            _cha = new Feature("Charisme");
            */
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public static Caractere LoadFromXML (string xml)
        {
            using (var reader = new StringReader(xml))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Caractere));
                return serializer.Deserialize(reader) as Caractere;
            }
        }

        /*
        public void save ()
        {
            IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            string docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            Stream stream = new FileStream(docPath, FileMode.Create, FileAccess.Write);

            Debug.WriteLine(docPath);

            formatter.Serialize(stream, this);
            stream.Close();
        }
        */
    }
}
