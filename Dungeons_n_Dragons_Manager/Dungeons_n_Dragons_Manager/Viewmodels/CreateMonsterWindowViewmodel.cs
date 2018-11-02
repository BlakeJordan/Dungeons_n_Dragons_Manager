using Dungeons_n_Dragons_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// The viewmodel for creating monsters
    /// </summary>
    public class CreateMonsterWindowViewmodel
    {
        /// <summary>
        /// Constructor for the create monster viewmodel
        ///
        /// Pre: Create monster window has been opened
        ///
        /// Post: A new monster is created with a reference to an existing, blank monster
        /// </summary>
        /// /// <param name="monster">A reference to the new character</param>
        public CreateMonsterWindowViewmodel(ref Monster monster)
        {
            newMonster = monster;
            populateDropdowns();
        }

        /// <summary>
        /// The new monster being created
        /// </summary>
        public Monster newMonster { get; set; }

        /// <summary>
        /// The monster's options for armor
        /// </summary>
        public List<string> ArmorTypes { get; set; }

        /// <summary>
        /// Boolean for if the artic environment is checked.
        /// </summary>
        public bool IsArctic { get; set; }

        /// <summary>
        /// Boolean for if the coastal environment is checked.
        /// </summary>
        public bool IsCoastal { get; set; }

        /// <summary>
        /// Boolean for if the Desert environment is checked.
        /// </summary>
        public bool IsDesert { get; set; }

        /// <summary>
        /// Boolean for if the forest environment is checked.
        /// </summary>
        public bool IsForest { get; set; }

        /// <summary>
        /// Boolean for if the grassland environment is checked.
        /// </summary>
        public bool IsGrassland { get; set; }

        /// <summary>
        /// Boolean for if the hill environment is checked.
        /// </summary>
        public bool IsHill { get; set; }

        /// <summary>
        /// Boolean for if the mountain environment is checked.
        /// </summary>
        public bool IsMountain { get; set; }

        /// <summary>
        /// Boolean for if the swamp environment is checked.
        /// </summary>
        public bool IsSwamp { get; set; }

        /// <summary>
        /// Boolean for if the underdark environment is checked.
        /// </summary>
        public bool IsUnderdark { get; set; }

        /// <summary>
        /// Boolean for if the underwater environment is checked.
        /// </summary>
        public bool IsUnderwater { get; set; }

        /// <summary>
        /// Boolean for if the urban environment is checked.
        /// </summary>
        public bool IsUrban { get; set; }

        /// <summary>
        /// Populates the dropdown menus for the armor type options
        ///
        /// Pre: None
        ///
        /// Post: The dropdown menus contain selectable armor type
        /// </summary>
        private void populateDropdowns()
        {
            ArmorTypes = Properties.Resources.ArmorTypes.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        #region Interfaces

        /// <summary>
        /// Public instance of PropertyChanged event.
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

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
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion Interfaces
    }
}