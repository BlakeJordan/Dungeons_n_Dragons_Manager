using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_n_Dragons_Manager.Models
{
    class DiceBag : INotifyPropertyChanged
    {
        private Random rng;
        public DiceBag()
        {
            rng = new Random();
        }

        public enum Dice : uint { D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20, D100 = 100 };

        private List<string> Roll(int dice, int times)
        {
            List<string> rolls = new List<string>();
            for(int i = 0; i < times; i++)
            {
                rolls.Add((1 + rng.Next(dice)).ToString());
            }
            return rolls;
            
        }

        public List<List<string>> RollMultiple(int[] times)
        {
            List<List<string>> rollList = new List<List<string>>();
            if(times[0] != 0) { rollList.Add(Roll((int)4, times[0])); }
            if(times[1] != 0) { rollList.Add(Roll((int)6, times[1])); }
            if (times[2] != 0) { rollList.Add(Roll((int)8, times[2])); }
            if (times[3] != 0) { rollList.Add(Roll((int)10, times[3])); }
            if (times[4] != 0) { rollList.Add(Roll((int)12, times[4])); }
            if (times[5] != 0) { rollList.Add(Roll((int)20, times[5])); }
            if (times[6] != 0) { rollList.Add(Roll((int)100, times[6])); }
            return rollList;
        }

        #region Interfaces

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion Interfaces
    }
}
