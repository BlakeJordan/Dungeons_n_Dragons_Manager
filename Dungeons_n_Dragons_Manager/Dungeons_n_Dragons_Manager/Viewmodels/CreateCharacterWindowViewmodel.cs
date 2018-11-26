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
            populateDropdowns();
         
        }

        #region Properties

        /// <summary>
        /// Bool binded to the IsEnabled property of the Save button.
        /// </summary>
        public bool CanSave
        {
            get
            {
                bool hasUniqueName = true;
                foreach (Character character in m_customCharacters)
                {
                    if (character.Name == EditableCharacter.Name) hasUniqueName = false;
                }
                bool hasAC = EditableCharacter.AC >= 0;
                bool hasHP = EditableCharacter.HP >= 0;
                bool hasName = !(string.IsNullOrWhiteSpace(EditableCharacter.Name));
                bool hasClass = !(string.IsNullOrWhiteSpace(EditableCharacter.Class));
                bool hasRace = !(string.IsNullOrWhiteSpace(EditableCharacter.Race));
                bool hasArmorType = !(string.IsNullOrWhiteSpace(EditableCharacter.ArmorType));
                bool hasLevel = (EditableCharacter.Level != 0);
                bool hasAllStats = EditableCharacter.Strength.score != 0 && EditableCharacter.Dexterity.score != 0 && EditableCharacter.Constitution.score != 0 &&
                                      EditableCharacter.Intelligence.score != 0 && EditableCharacter.Wisdom.score != 0 && EditableCharacter.Charisma.score != 0;

                if (hasUniqueName && hasName && hasClass && hasRace && hasArmorType && hasLevel && hasAllStats && hasHP && hasAC)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       

        /// <summary>
        /// Character that is bound to the UI.
        /// </summary>
        private Character m_editableCharacter;

        /// <summary>
        /// Public accessor for m_editableCharacter.
        /// </summary>
        public Character EditableCharacter
        {
            get
            {
                if (m_editableCharacter == null)
                {
                    m_editableCharacter = new Character();
                }
                return m_editableCharacter;
            }
            set
            {
                if (m_editableCharacter != value)
                {
                    m_editableCharacter = value;
                    OnPropertyRaised(nameof(EditableCharacter));
                }
            }
        }

        /// <summary>
        /// List of current characters for reference.
        /// </summary>
        private List<Character> m_customCharacters;

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

        #endregion

        #endregion Properties

        #region Commands

        /// <summary>
        /// Command binded to Save button.
        /// </summary>
        private ICommand m_saveCharacter;

        /// <summary>
        /// Public facing accessor to m_saveCharacter.
        /// </summary>
        public ICommand SaveCharacter
        {
            get
            {
                return m_saveCharacter ?? (m_saveCharacter = new CommandHandler(() => saveCharacter(), true));
            }
        }


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

        #endregion

        #region Functions

        /// <summary>
        /// Calculates the proficiency, skills, and stats based on user input, then saves the character
        /// 
        /// Pre: CanSave method must return true and save button must be clicked
        /// 
        /// Post: Stats for the character are set, and the details are written to the system settings
        /// </summary>
        private void saveCharacter()
        {
            EditableCharacter.CalculateStats();
            EditableCharacter.SetProficiency();
            EditableCharacter.CalculateSkills();
            if (Properties.Settings.Default.CustomCharactersList == null) Properties.Settings.Default.CustomCharactersList = new List<Character>();
            Properties.Settings.Default.CustomCharactersList.Add(EditableCharacter);
            Properties.Settings.Default.Save();

        }


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
            ArmorClasses = Enumerable.Range(0, 31).ToList();
            Skills = Enumerable.Range(1, 21).ToList();
            Levels = Enumerable.Range(1, 30).ToList();
            m_customCharacters = new List<Character>();

            if (Properties.Settings.Default.CustomCharactersList != null)
            {
                m_customCharacters = Properties.Settings.Default.CustomCharactersList;
            }
        }

        #endregion

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