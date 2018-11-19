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
        public CreateCharacterWindowViewmodel()
        {
            NewCharacter = new Character();
            populateDropdowns();
        }

        #region Properties

        /// <summary>
        /// The new character being created
        /// </summary>
        public Character NewCharacter { get; set; }

        /// <summary>
        /// Bool binded to the IsEnabled property of the Save button.
        /// </summary>
        public bool CanSave
        {
            get
            {
                return true; //Add logic for saving.
            }
        }

        /// <summary>
        /// List of current characters for reference.
        /// </summary>
        private List<Character> m_characters;

        #region ComboBox Sources

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
        public List<int> Skills { get; set; }

        /// <summary>
        /// The character's options for character level.
        /// </summary>
        public List<int> Levels { get; set; }

        #endregion ComboBox Sources

        #endregion Properties

        #region Commands

        /// <summary>
        /// Command binded to UI that updates CanSave.
        /// </summary>
        private ICommand m_checkCanSave;

        /// <summary>
        /// Public facing accessor for m_CheckCanSave
        /// </summary>
        public ICommand CheckCanSave
        {
            get
            {
                return m_checkCanSave ?? (m_checkCanSave = new CommandHandler(() => checkCanSave(), true));
            }
        }

        #endregion Commands

        #region Functions

        /// <summary>
        /// Reevaluates CanSave.
        /// </summary>
        private void checkCanSave()
        {
            OnPropertyRaised(nameof(CanSave));
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
            Skills = Enumerable.Range(0, 21).ToList();
            Levels = Enumerable.Range(1, 30).ToList();
        }

        #endregion Functions

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