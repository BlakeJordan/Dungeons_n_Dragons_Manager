using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dungeons_n_Dragons_Manager.Models
{
    /// <summary>
    /// DiceBag class containing rolling functions dice enum.
    /// </summary>
    internal class DiceBag : INotifyPropertyChanged
    {
        /// <summary>
        /// private variable which will hold a random number for each roll
        /// </summary>
        private Random rng;
        /// <summary>
        /// contructor for the DiceBag class
        /// @Pre: random number variable has been instantiated
        /// @Post: rng is set to a new Random
        /// </summary>
        public DiceBag()
        {
            rng = new Random();
        }
        /// <summary>
        /// private facing enum holding each type of dice set to their numerical max
        /// </summary>
        public enum Dice : uint { D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20, D100 = 100 };
        /// <summary>
        /// rolls a single dice the number of times specified by the user
        /// @Pre: Roll has been clicked and a number exists in the textbox next to the specified dice
        /// @Post: returns a list of strings containing the rolls for the specified dice
        /// </summary>
        /// <param name="dice"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        private List<string> Roll(int dice, int times)
        {
            List<string> rolls = new List<string>();
            for (int i = 0; i < times; i++)
            {
                rolls.Add((1 + rng.Next(dice)).ToString());
            }
            return rolls;
        }

        public List<List<string>> RollMultiple(int[] times)
        {
            List<List<string>> rollList = new List<List<string>>();
            if (times[0] != 0) { rollList.Add(Roll((int)4, times[0])); }
            if (times[1] != 0) { rollList.Add(Roll((int)6, times[1])); }
            if (times[2] != 0) { rollList.Add(Roll((int)8, times[2])); }
            if (times[3] != 0) { rollList.Add(Roll((int)10, times[3])); }
            if (times[4] != 0) { rollList.Add(Roll((int)12, times[4])); }
            if (times[5] != 0) { rollList.Add(Roll((int)20, times[5])); }
            if (times[6] != 0) { rollList.Add(Roll((int)100, times[6])); }
            return rollList;
        }

        #region Interfaces
        /// <summary>
        /// Public instance of PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Private function which updates the UI's binding value to the current value.
        /// @Pre: Private backing value has been changed.
        /// @Post: UI now reflects current value.
        /// </summary>
        /// <param name="propertyname">Name of property to update to UI.</param>
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