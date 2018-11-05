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
        /// The character's options for each skill's level
        /// </summary>
        public List<string> SkillValues { get; set; }
        /// <summary>
        /// Command binded to proficiency checkboxes which calls proficiencyCheck
        /// </summary>
        private ICommand m_EnvironmentCheck;

        public bool IsEnvironmentChecked { get; set; }

        /// <summary>
        /// Public facing accessor for m_ProficiencyCheck
        /// </summary>
        public ICommand EnvironmentCheck
        {
            get
            {
                return m_EnvironmentCheck ?? (m_EnvironmentCheck = new CommandHandler(() => SetEnvironment(IsEnvironmentChecked), true));
            }
        }

        /// <summary>
        /// Checks if a environment can be added, then adds the environment to the monster's environment list
        /// </summary>
        public void SetEnvironment(bool canSetEnvironemnt)
        {
            if (IsEnvironmentChecked == true)
            {
                
            }
            else
            {
           
            }
        }


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
            SkillValues = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" }.ToList();
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