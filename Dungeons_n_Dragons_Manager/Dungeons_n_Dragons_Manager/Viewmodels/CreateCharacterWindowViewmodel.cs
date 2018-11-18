using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// The viewmodel for creating characters
    /// </summary>
    public class CreateCharacterWindowViewmodel : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor for the create character viewmodel
        ///
        /// Pre: Create Character window has been opened
        ///
        /// Post: A new character is created with a reference to an existing, blank character
        /// </summary>
        /// /// <param name="character">A reference to the new character</param>
        public CreateCharacterWindowViewmodel(ref Character character)
        {
            newCharacter = character;
            populateDropdowns();
        }

        /// <summary>
        /// The new character being created
        /// </summary>
        public Character newCharacter { get; set; }

        /// <summary>
        /// The character's options for race
        /// </summary>
        public List<string> Races { get; set; }

        /// <summary>
        /// The character's options for class
        /// </summary>
        public List<string> Classes { get; set; }

        /// <summary>
        /// The character's options for armor
        /// </summary>
        public List<string> ArmorTypes { get; set; }

        /// <summary>
        /// The character's options for each skill's level
        /// </summary>
        public List<string> Skills { get; set; }

        /// <summary>
        /// Command binded to proficiency checkboxes which calls proficiencyCheck
        /// </summary>
        private ICommand m_ProficiencyCheck;

        public bool IsProficiencyChecked { get; set; }

        /// <summary>
        /// Public facing accessor for m_ProficiencyCheck
        /// </summary>
        public ICommand ProficiencyCheck
        {
            get
            {
                return m_ProficiencyCheck ?? (m_ProficiencyCheck = new CommandHandler(() => SetProficiency(IsProficiencyChecked), true));
            }
        }

        /// <summary>
        /// Checks if a proficiency can be added, then adds the proficiency to the character's proficiency list
        /// </summary>
        public void SetProficiency(bool canSetProficiency)
        {
            if (IsProficiencyChecked == true)
            {
                Console.WriteLine("ayyy");
            }
            else
            {
                Console.WriteLine("awww");
            }
        }

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
            Skills = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" }.ToList();
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion Interfaces
    }
}