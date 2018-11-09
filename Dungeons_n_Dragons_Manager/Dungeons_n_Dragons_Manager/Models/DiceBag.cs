using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dungeons_n_Dragons_Manager.Models
{
    /// <summary>
    /// DiceBag class containing rolling functions dice enum.
    /// </summary>
    public class DiceBag : INotifyPropertyChanged
    {
        /// <summary>
        /// private variable which will hold a random number for each roll
        /// </summary>
        private Random rng;

        /// <summary>
        /// contructor for the DiceBag class
        ///
        /// Pre: random number variable has been instantiated
        ///
        /// Post: rng is set to a new Random
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
        ///
        /// Pre: Roll has been clicked and a number exists in the textbox next to the specified dice
        ///
        /// Post: returns a list of strings containing the rolls for the specified dice
        /// </summary>
        /// <param name="dice"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public string Roll(int dice)
        {
            string rolls;
            rolls = (1 + rng.Next(dice)).ToString();
            return rolls;
        }

        /// <summary>
        /// uses the Roll function to roll all the dice if the number of times is not zero
        ///
        /// Pre: Roll has been clicked, none of the text boxes are empty, and an array of ints has been passed in
        ///
        /// Post: returns a list of lists of strings to the viewmodel containing all the rolls
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
     

        #region Interfaces

        /// <summary>
        /// Public instance of PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Private function which updates the UI's binding value to the current value.
        ///
        /// Pre: Private backing value has been changed.
        ///
        /// Post: UI now reflects current value.
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