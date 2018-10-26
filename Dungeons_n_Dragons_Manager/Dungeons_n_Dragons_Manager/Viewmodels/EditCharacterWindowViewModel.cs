using Dungeons_n_Dragons_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// Viewmodel for the edit character window
    /// </summary>
    public class EditCharacterWindowViewModel
    {
        /// <summary>
        /// Constructor for the edit character viewmodel
        ///
        /// Pre: Edit Character window has been opened while a character is selected
        ///
        /// Post: A copy of the character is created and edited with a reference to the existing character
        /// </summary>
        /// /// <param name="character">A reference to the character being edited</param>
        public EditCharacterWindowViewModel(ref Character character)
        {
            EditedCharacter = character;
            populateDropdowns();
        }

        /// <summary>
        /// The new character being edited
        /// </summary>
        public Character EditedCharacter { get; set; }

        /// <summary>
        /// The character's options for armor
        /// </summary>
        public List<string> ArmorTypes { get; set; }

        /// <summary>
        /// The character's options for race
        /// </summary>
        public List<string> Races { get; set; }

        /// <summary>
        /// The character's options for class
        /// </summary>
        public List<string> Classes { get; set; }

        /// <summary>
        /// Populates the dropdown menus for the races and classes options
        ///
        /// Pre: None
        ///
        /// Post: The dropdown menus contain selectable race and class names
        /// </summary>
        private void populateDropdowns()
        {
            Races = Properties.Resources.Races.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Classes = Properties.Resources.Classes.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
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