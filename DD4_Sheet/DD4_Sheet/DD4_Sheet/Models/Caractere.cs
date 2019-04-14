using System;
using System.Collections.Generic;
using System.Text;

namespace DD4_Sheet.Models
{
    public class Caractere
    {
        public String Name { get; set; }
        public int Xp { get; set; }
        public int Lvl
        {
            get
            {
                int rtn = 0;

                while (tabLvl[rtn] < Xp) { rtn++; }

                return rtn;
            }
        }
        public String Class { get; set; }
        public String Race { get; set; }
        public String ParagonPath { get; set; }
        public String EpicDestiny { get; set; }
        public String Langages { get; set; }
        public String Description { get; set; }
        public String Background { get; set; }
        public String ParangonBG { get; set; }
        public String EpicDestinyBG { get; set; }


        private int[] tabLvl;

        public Caractere ()
        {
            tabLvl = new int[30];
            tabLvl[0] = 0;
            tabLvl[1] = 1000;
            tabLvl[2] = 2250;
            tabLvl[3] = 3750;
            tabLvl[4] = 5500;
            tabLvl[5] = 7500;
            tabLvl[6] = 10000;
            tabLvl[7] = 13000;
            tabLvl[8] = 16500;
            tabLvl[9] = 20500;
            tabLvl[10] = 26000;
            tabLvl[11] = 32000;
            tabLvl[12] = 39000;
            tabLvl[13] = 47000;
            tabLvl[14] = 57000;
            tabLvl[15] = 69000;
            tabLvl[16] = 83000;
            tabLvl[17] = 99000;
            tabLvl[18] = 119000;
            tabLvl[19] = 143000;
            tabLvl[20] = 175000;
            tabLvl[21] = 210000;
            tabLvl[22] = 255000;
            tabLvl[23] = 310000;
            tabLvl[24] = 375000;
            tabLvl[25] = 450000;
            tabLvl[26] = 550000;
            tabLvl[27] = 675000;
            tabLvl[28] = 825000;
            tabLvl[29] = 1000000;
        }

        public void save()
        {
            var x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            x.Serialize(Console.Out, this);
        }
    }
}
