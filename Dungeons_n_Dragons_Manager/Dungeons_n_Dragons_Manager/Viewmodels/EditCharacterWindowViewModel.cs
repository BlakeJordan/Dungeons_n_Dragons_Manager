using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// Viewmodel for the edit character window
    /// </summary>
    public class EditCharacterWindowViewModel : INotifyPropertyChanged
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
            EditableCharacter = character;
            populateDropdowns();
        }

        #region Properties

        /// <summary>
        /// Character object that references the selected character before opening the edit window.
        /// </summary>
        private Character m_selectedCharacter { get; set; }

        /// <summary>
        /// Public accessor to m_selectedCharacter.
        /// </summary>
        public Character SelectedCharacter
        {
            get
            {
                if (m_selectedCharacter == null && CustomCharacters.Count != 0)
                {
                    m_selectedCharacter = CustomCharacters[0];
                }
                return m_selectedCharacter;
            }
            set
            {
                if (m_selectedCharacter != value)
                {
                    m_selectedCharacter = value;
                    OnPropertyRaised(nameof(SelectedCharacter));
                    EditableCharacter = new Character(SelectedCharacter); //Create deep copy of SelectedCharacter to edit without actually editing SelectedCharacter.
                }
            }
        }

        /// <summary>
        /// A collection of the currently saved Characters.
        /// </summary>
        public List<Character> CustomCharacters { get; set; }

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

        /// <summary>
        /// Bool that determines if the user can save.
        /// </summary>
        public bool CanSave
        {
            get
            {


                bool hasUniqueName = true;
                foreach (Character character in CustomCharacters)
                {
                    if (!SelectedCharacter.Equals(character))
                    {
                        if (character.Name == EditableCharacter.Name) hasUniqueName = false;
                    }
                }

                bool hasName = !(string.IsNullOrWhiteSpace(EditableCharacter.Name));
                bool hasClass = !(string.IsNullOrWhiteSpace(EditableCharacter.Class));
                bool hasRace = !(string.IsNullOrWhiteSpace(EditableCharacter.Race));
                bool hasArmorType = !(string.IsNullOrWhiteSpace(EditableCharacter.ArmorType));
                bool hasLevel = (EditableCharacter.Level != 0);
                bool hasAllStats = EditableCharacter.Strength.score != 0 && EditableCharacter.Dexterity.score != 0 && EditableCharacter.Constitution.score != 0 &&
                                      EditableCharacter.Intelligence.score != 0 && EditableCharacter.Wisdom.score != 0 && EditableCharacter.Charisma.score != 0;

                if (hasUniqueName && hasName && hasClass && hasRace && hasArmorType && hasLevel && hasAllStats)
                {
                    return true;
                }
                else
                {
                    return false;
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

        #endregion Commands

        #region Functions

        /// <summary>
        /// Populates the dropdown menus for the races and classes options
        ///
        /// Pre: None
        ///
        /// Post: The dropdown menus contain selectable classses, skills, armor types, etc.
        /// </summary>
        private void populateDropdowns()
        {
            Races = Properties.Resources.Races.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Classes = Properties.Resources.Classes.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ArmorTypes = Properties.Resources.ArmorTypes.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ArmorClasses = Enumerable.Range(0, 31).ToList();
            Skills = Enumerable.Range(0, 21).ToList();
            Levels = Enumerable.Range(1, 30).ToList();
            CustomCharacters = Properties.Settings.Default.CustomCharactersList;
        }
        
        /// <summary>
        /// Calculates the proficiency, skills, and stats based on user input, then saves the character
        /// 
        /// Pre: CanSave method must return true and save button must be clicked
        /// 
        /// Post: Stats for the character are set, and the details are written to the system settings
        /// </summary>
        private void saveCharacter()
        {
            if (!CanSave) return;
            EditableCharacter.CalculateStats();
            EditableCharacter.SetProficiency();
            EditableCharacter.CalculateSkills();
            Properties.Settings.Default.CustomCharactersList.Remove(SelectedCharacter);
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