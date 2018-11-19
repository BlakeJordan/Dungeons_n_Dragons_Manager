using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// The viewmodel for creating monsters
    /// </summary>
    public class EditMonsterWindowViewmodel : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor for the create monster viewmodel
        ///
        /// Pre: Create monster window has been opened
        ///
        /// Post: A new monster is created with a reference to an existing, blank monster
        /// </summary>
        public EditMonsterWindowViewmodel()
        {
            populateDropdowns();
        }

        #region Properties

        /// <summary>
        /// Represents the currently selected Monster in the combobox.
        /// </summary>
        private Monster m_selectedMonster;

        /// <summary>
        /// Public accessor to m_selectedMonster.
        /// </summary>
        public Monster SelectedMonster
        {
            get
            {
                if (m_selectedMonster == null && CustomMonsters.Count != 0)
                {
                    m_selectedMonster = CustomMonsters[0];
                }
                return m_selectedMonster;
            }
            set
            {
                if (m_selectedMonster != value)
                {
                    m_selectedMonster = value;
                    OnPropertyRaised(nameof(SelectedMonster));
                    EditableMonster = new Monster(SelectedMonster); //Create deep copy of SelectedMonster to edit without actually editing SelectedMonster.
                }
            }
        }

        /// <summary>
        /// Deep clone of SelectedMonster. Used to edit without affecting currently selected monster.
        /// </summary>
        private Monster m_editableMonster;

        /// <summary>
        /// Public accessor for m_editableMonster.
        /// </summary>
        public Monster EditableMonster
        {
            get
            {
                if (m_editableMonster == null && CustomMonsters.Count != 0)
                {
                    m_editableMonster = new Monster(CustomMonsters[0]);
                }
                return m_editableMonster;
            }
            set
            {
                if (m_editableMonster != value)
                {
                    m_editableMonster = value;
                    OnPropertyRaised(nameof(EditableMonster));
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
                if (SelectedMonster != null) return SelectedMonster.Equals(EditableMonster) == false;
                return false;
            }
        }

        public Action CloseAction { get; set; }

        #region ComboBox Sources

        /// <summary>
        /// A collection of the currently saved monsters.
        /// </summary>
        public List<Monster> CustomMonsters { get; set; }

        /// <summary>
        /// The monster's options for armor
        /// </summary>
        public List<string> ArmorTypes { get; set; }

        /// <summary>
        /// The character's options for each skill's level
        /// </summary>
        public List<int> SkillValues { get; set; }

        /// <summary>
        /// The character's options for each Modifier
        /// </summary>
        public List<int> ModifierValues { get; set; }

        #endregion ComboBox Sources

        #endregion Properties

        #region Commands

        /// <summary>
        /// Command binded to the "Save Monster" button which calls saveMonster.
        /// </summary>
        private ICommand m_saveMonster;

        /// <summary>
        /// Public facing accessor to m_saveMonster.
        /// </summary>
        public ICommand SaveMonster
        {
            get
            {
                return m_saveMonster ?? (m_saveMonster = new CommandHandler(() => saveMonster(), true));
            }
        }

        /// <summary>
        /// Command binded to the "Save Monster" button which calls saveMonster.
        /// </summary>
        private ICommand m_deleteMonster;

        /// <summary>
        /// Public facing accessor to m_saveMonster.
        /// </summary>
        public ICommand DeleteMonster
        {
            get
            {
                return m_deleteMonster ?? (m_deleteMonster = new CommandHandler(() => deleteMonster(), true));
            }
        }

        /// <summary>
        /// Command binded to the "Save Monster" button which calls saveMonster.
        /// </summary>
        private ICommand m_checkCanSave;

        /// <summary>
        /// Public facing accessor to m_saveMonster.
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
        /// Populates the list of environments for the new monster
        ///
        /// Pre: monster has been created
        ///
        /// Post: The monster's list has all environments selected.
        /// </summary>
        private void saveMonster()
        {
            if (!CanSave) return; //Redundancy check.

            Properties.Settings.Default.CustomMonstersList.Remove(SelectedMonster);
            Properties.Settings.Default.CustomMonstersList.Add(EditableMonster);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// deletes the monster from the custom monster list.
        ///
        /// Pre: monster has been created
        ///
        /// Post: The monster's list has been updated with the selected monster removed.
        /// </summary>
        private void deleteMonster()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this monster?",
            "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Properties.Settings.Default.CustomMonstersList.Remove(SelectedMonster);
                Properties.Settings.Default.Save();
                CloseAction();
            }
            else
            {
                
            }
        }


        /// <summary>
        /// Reevaluates CanSave.
        /// </summary>
        private void checkCanSave()
        {
            OnPropertyRaised(nameof(CanSave));
        }

        /// <summary>
        /// Populates the lists that are bound to  UI comboBoxes.
        ///
        /// Pre: None
        ///
        /// Post: The dropdown menus contain data.
        /// </summary>
        private void populateDropdowns()
        {
            ArmorTypes = Properties.Resources.ArmorTypes.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            SkillValues = Enumerable.Range(1, 30).ToList();
            ModifierValues = Enumerable.Range(-5, 16).ToList();
            CustomMonsters = Properties.Settings.Default.CustomMonstersList;
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