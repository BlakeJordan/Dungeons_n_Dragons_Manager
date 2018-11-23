using Dungeons_n_Dragons_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            m_selectedCharacter = character;
            //EditableCharacter = new Character(m_selectedCharacter);     //Need to make copy constructor to make a deep copy to reference between the edited version and old version.
            populateDropdowns();
        }

        #region Properties

        /// <summary>
        /// Character object that references the selected character before openning the edit window.
        /// </summary>
        private Character m_selectedCharacter { get; set; }

        /// <summary>
        /// Character binded to UI.
        /// </summary>
        private Character m_editableCharacter;

        /// <summary>
        /// Public accessor for m_editableCharacter.
        /// </summary>
        public Character EditableCharacter
        {
            get { return m_editableCharacter; }
            set
            {
                if (m_editableCharacter != value)
                {
                    m_editableCharacter = value;
                    OnPropertyRaised(nameof(EditableCharacter));
                }
            }
        }

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
        /// The character's options for armor class.
        /// </summary>
        public List<int> ArmorClasses { get; set; }

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

        #region Functions

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
            ArmorClasses = Enumerable.Range(0, 31).ToList();
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion Interfaces
    }
}