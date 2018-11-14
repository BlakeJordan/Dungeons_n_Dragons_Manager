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
    public class EditMonsterWindowViewmodel
    {
        /// <summary>
        /// Constructor for the create monster viewmodel
        ///
        /// Pre: Create monster window has been opened
        ///
        /// Post: A new monster is created with a reference to an existing, blank monster
        /// </summary>
        /// /// <param name="monster">A reference to the new character</param>
        public EditMonsterWindowViewmodel(ref Monster monster)
        {
            EditedMonster = monster;
            populateDropdowns();
        }

        /// <summary>
        /// Private backing to store the currently selected monster in the combobox.
        /// </summary>
        private string m_selectedStrength;

        /// <summary>
        /// Public facing accessor to m_selectedMonster.
        /// </summary>
        public string SelectedStrength
        {
            get
            {
                if (m_selectedStrength == null)
                {
                    int temp = EditedMonster.Strength;
                    string temp2 = temp.ToString();
                    foreach (string entry in SkillValues)
                    {
                        if(entry == temp2)
                        {
                            m_selectedStrength = entry;
                        }
                    }
                }
                return m_selectedStrength;
            }
            set
            {
                if (value != m_selectedStrength)
                {
                    m_selectedStrength = value;
                    OnPropertyRaised(nameof(SelectedStrength));
                }
            }
        }
        /// <summary>
        /// The new monster being created
        /// </summary>
        public Monster EditedMonster { get; set; }

        /// <summary>
        /// The monster's options for armor
        /// </summary>
        public List<string> ArmorTypes { get; set; }

        /// <summary>
        /// The character's options for each skill's level
        /// </summary>
        public List<string> SkillValues { get; set; }

        /// <summary>
        /// The character's options for each Modifier
        /// </summary>
        public List<string> ModifierValues { get; set; }

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
        /// Command binded to the "Save Monster" button which calls UpdateEnvironment
        /// </summary>
        private ICommand m_UpdateEnvironments;

        /// <summary>
        /// Public facing accessor to m_chooseRandomEncounter.
        /// </summary>
        public ICommand UpdateEnvironments
        {
            get
            {
                return m_UpdateEnvironments ?? (m_UpdateEnvironments = new CommandHandler(() => updateEnvironments(), true));
            }
        }
        /// <summary>
        /// Populates the list of environments for the new monster
        ///
        /// Pre: monster has been created
        ///
        /// Post: The monster's list has all environments selected.
        /// </summary>
        public void updateEnvironments()
        {
            EditedMonster.Environments = new List<string>();
            if(IsArctic)
            {
                EditedMonster.Environments.Add("Arctic");
            }
            if(IsCoastal)
            {
                EditedMonster.Environments.Add("Coastal");
            }
            if(IsDesert)
            {
                EditedMonster.Environments.Add("Desert");
            }
            if(IsForest)
            {
                EditedMonster.Environments.Add("Forest");
            }
            if(IsGrassland)
            {
                EditedMonster.Environments.Add("Grassland");
            }
            if(IsHill)
            {
                EditedMonster.Environments.Add("Hill");
            }
            if(IsMountain)
            {
                EditedMonster.Environments.Add("Mountain");
            }
            if(IsSwamp)
            {
                EditedMonster.Environments.Add("Swamp");
            }
            if(IsUnderdark)
            {
                EditedMonster.Environments.Add("Underdark");
            }
            if(IsUnderwater)
            {
                EditedMonster.Environments.Add("Underwater");
            }
            if(IsUrban)
            {
                EditedMonster.Environments.Add("Urban");
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
            SkillValues = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" }.ToList();
            ModifierValues = new string[] { "-5", "-4", "-3", "-2", "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }.ToList();

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