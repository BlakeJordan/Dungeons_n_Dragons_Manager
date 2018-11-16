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
    public class CreateMonsterWindowViewmodel : INotifyPropertyChanged
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
            newMonster.IsCustom = true;
            populateDropdowns();
        }

        #region Properties

        /// <summary>
        /// Determines if the user can save the new monster.
        /// </summary>
        public bool CanSave
        {
            get
            {
                if (string.IsNullOrWhiteSpace(newMonster.Name)) //Name check
                {
                    return false;
                }
                else if (!(IsArctic || IsCoastal || IsDesert || IsForest || IsGrassland || IsHill || IsMountain || IsSwamp || IsUnderdark || IsUnderwater || IsUrban)) //Envrionment check
                {
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(newMonster.ArmorClassType)) //ArmorClassType check
                {
                    return false;
                }

                return true;
            }
        }

        ///// <summary>
        ///// String bound to Name textbox.
        ///// </summary>
        //private string m_name;

        ///// <summary>
        ///// Public facing accessor for m_name.
        ///// </summary>
        //public string Name
        //{
        //    get { return m_name; }
        //    set
        //    {
        //        if (m_name != value)
        //        {
        //            m_name = value;
        //            OnPropertyRaised(nameof(CanSave));
        //        }
        //    }
        //}

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
        /// The character's options for each Modifier
        /// </summary>
        public List<string> ModifierValues { get; set; }

        #region Environment Checks

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

        #endregion

        #endregion

        #region Commands

        /// <summary>
        /// Command binded to the "Save Monster" button which calls UpdateEnvironment
        /// </summary>
        private ICommand m_updateEnvironments;

        /// <summary>
        /// Public facing accessor to m_updateEnvironments.
        /// </summary>
        public ICommand UpdateEnvironments
        {
            get
            {
                return m_updateEnvironments ?? (m_updateEnvironments = new CommandHandler(() => updateEnvironments(), true));
            }
        }

        /// <summary>
        /// Command binded to all environment checkboxes which will update CanSave.
        /// </summary>
        private ICommand m_updateCanSave;

        /// <summary>
        /// Public facing accessor to m_updateCanSave.
        /// </summary>
        public ICommand UpdateCanSave
        {
            get
            {
                return m_updateCanSave ?? (m_updateCanSave = new CommandHandler(() => updateCanSave(), true));
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Populates the list of environments for the new monster
        ///
        /// Pre: monster has been created
        ///
        /// Post: The monster's list has all environments selected.
        /// </summary>
        public void updateEnvironments()
        {
            //newMonster.Name = Name;

            int Count = 0;
            //newMonster.Environments = new List<string>();
            //if(IsArctic)
            //{
            //    newMonster.Environments.Add("Arctic");
            //    Count++;
            //}
            //if(IsCoastal)
            //{
            //    newMonster.Environments.Add("Coastal");
            //    Count++;
            //}
            //if(IsDesert)
            //{
            //    newMonster.Environments.Add("Desert");
            //    Count++;
            //}
            //if(IsForest)
            //{
            //    newMonster.Environments.Add("Forest");
            //    Count++;
            //}
            //if(IsGrassland)
            //{
            //    newMonster.Environments.Add("Grassland");
            //    Count++;
            //}
            //if(IsHill)
            //{
            //    newMonster.Environments.Add("Hill");
            //    Count++;
            //}
            //if(IsMountain)
            //{
            //    newMonster.Environments.Add("Mountain");
            //    Count++;
            //}
            //if(IsSwamp)
            //{
            //    newMonster.Environments.Add("Swamp");
            //    Count++;
            //}
            //if(IsUnderdark)
            //{
            //    newMonster.Environments.Add("Underdark");
            //    Count++;
            //}
            //if(IsUnderwater)
            //{
            //    newMonster.Environments.Add("Underwater");
            //    Count++;
            //}
            //if (IsUrban)
            //{
            //    newMonster.Environments.Add("Urban");
            //    Count++;
            //}
            //if(Count == 0)
            //{
                
            //}

        }

        /// <summary>
        /// Reevaluates the CanSave binding.
        /// 
        /// Pre: none
        /// 
        /// Post: CanSave has been reevaluated.
        /// </summary>
        public void updateCanSave()
        {
            OnPropertyRaised(nameof(CanSave));
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion Interfaces
    }
}