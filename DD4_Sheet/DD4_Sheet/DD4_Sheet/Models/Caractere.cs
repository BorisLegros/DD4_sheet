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

                foreach (int val in tabLvl)
                {
                    if (_xp < val) { break; }

                    rtn++;
                }

                return rtn;
            }
        }


        private string _name, _classe, _race, _paranP, _epicD, _lang, _descr, _bg, _paranBG, _epicBG;
        private int _xp;
       // private int[] tabLvl;
        private List<int> tabLvl;

        public event PropertyChangedEventHandler PropertyChanged;

        public Caractere ()
        {
            Xp = 0;

            tabLvl = new List<int>(30);
           
            tabLvl.Add(0);
            tabLvl.Add(1000);
            tabLvl.Add(2250);
            tabLvl.Add(3750);
            tabLvl.Add(5500);
            tabLvl.Add(7500);
            tabLvl.Add(10000);
            tabLvl.Add(13000);
            tabLvl.Add(16500);
            tabLvl.Add(20500);
            tabLvl.Add(26000);
            tabLvl.Add(32000);
            tabLvl.Add(39000);
            tabLvl.Add(47000);
            tabLvl.Add(57000);
            tabLvl.Add(69000);
            tabLvl.Add(83000);
            tabLvl.Add(99000);
            tabLvl.Add(119000);
            tabLvl.Add(143000);
            tabLvl.Add(175000);
            tabLvl.Add(210000);
            tabLvl.Add(255000);
            tabLvl.Add(310000);
            tabLvl.Add(375000);
            tabLvl.Add(450000);
            tabLvl.Add(550000);
            tabLvl.Add(675000);
            tabLvl.Add(825000);
            tabLvl.Add(1000000);
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
