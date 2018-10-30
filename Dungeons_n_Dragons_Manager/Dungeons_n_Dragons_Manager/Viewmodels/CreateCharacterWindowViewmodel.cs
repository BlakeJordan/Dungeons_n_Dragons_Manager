using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// The character's options for proficiencies
        /// </summary>
        public ObservableCollection<string> Proficiencies { get; set; }

        /// <summary>
        /// Used to store the proficiency names that the character chooses
        /// </summary>
        private string m_proficiency;

        /// <summary>
        /// Public facing accessor to m_proficiency
        /// </summary>
        public string Proficiency
        {
            get { return m_proficiency; }
            set
            {
                m_proficiency = value;
                OnPropertyRaised(nameof(m_proficiency));
                ProficiencyCheck(m_proficiency);
            }
        }

        #region Commands
        /// <summary>
        /// command binded to proficiency checkboxes which calls AddProficiency if CanAddProficiency is true
        /// </summary>
        public ICommand m_ProficiencyCheck { get; set; }

        /// <summary>
        /// Checks if a proficiency can be added, then adds the proficiency to the character's proficiency list
        /// </summary>
        public void ProficiencyCheck(object proficiencyName)
        {
            if (CanAddProficiency(proficiencyName))
            {
                AddProficiency(proficiencyName);
            }
        }

        private bool CanAddProficiency(object parameter)
        {
            return true;
        }

        private void AddProficiency(object parameter)
        {
            var values = (object[])parameter;
            string name = (string)values[0];
            bool check = (bool)values[1];
            if (check)
            {
                Proficiencies.Add(name);
            }
            else
            {
                Proficiencies.Remove(name);
            }
        }
        #endregion Commands

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion Interfaces
    }
}