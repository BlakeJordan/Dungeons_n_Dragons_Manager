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
    /// Viewmodel for the Encounters Tab in the Main Window.
    /// </summary>
    public class EncountersTabViewmodel : INotifyPropertyChanged
    {
        /// <summary>
        /// This constructor calls parseMonsterResource.
        /// 
        /// Pre: None.
        /// 
        /// Post: CollectionOfMonsters is filled.
        /// </summary>
        public EncountersTabViewmodel()
        {
            CollectionOfMonsters = new ObservableCollection<Monster>();
            parseMonstersResource();
        }

        #region Members

        /// <summary>
        /// ObservableCollection of Monsters which is bound to the combobox.
        /// </summary>
        public ObservableCollection<Monster> CollectionOfMonsters { get; set; }
        
        /// <summary>
        /// Private backing to store the currently selected monster in the combobox.
        /// </summary>
        private Monster m_selectedMonster;
        /// <summary>
        /// Public facing accessor to m_selectedMonster.
        /// </summary>
        public Monster SelectedMonster
        {
            get
            {
                if (m_selectedMonster == null)
                {
                    m_selectedMonster = CollectionOfMonsters[0];
                }
                return m_selectedMonster;
            }
            set
            {
                if (value != m_selectedMonster)
                {
                    m_selectedMonster = value;
                    OnPropertyRaised(nameof(SelectedMonster));
                }
            }
        }

        #endregion Members

        #region Commands

        /// <summary>
        /// Boolean which determines if ChooseRandomEncounter can be executed.
        /// </summary>
        private bool m_canChooseRandomEncounter
        {
            get { return true; } //Add check to see if characters are created later.
        }

        /// <summary>
        /// Command binded to the "Random Encounter" button which calls chooseRandomEncounter if m_canChooseRandomEncounter is true.
        /// </summary>
        private ICommand m_chooseRandomEncounter;
        /// <summary>
        /// Public facing accessor to m_chooseRandomEncounter.
        /// </summary>
        public ICommand ChooseRandomEncounter
        {
            get
            {
                return m_chooseRandomEncounter ?? (m_chooseRandomEncounter = new CommandHandler(() => chooseRandomEncounter(), m_canChooseRandomEncounter));
            }
        }

        #endregion Commands

        #region Functions

        /// <summary>
        /// Private function that parses through the string that represents the monster data in the app resources.
        /// 
        /// Pre: None.
        /// 
        /// Post: CollectionOfMonsters has been filled.
        /// </summary>
        private void parseMonstersResource()
        {
            List<string> monsterDataEntries = Properties.Resources.Monsters.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            monsterDataEntries.RemoveAt(0); //Remove data header
            foreach (string entry in monsterDataEntries)
            {
                string[] values = entry.Split(';');
                CollectionOfMonsters.Add(new Monster(values));
            }
        }

        /// <summary>
        /// Private function that sets SelectedMonster to a random monster in CollectionOfMonsters.
        /// 
        /// Pre: "Random Encounter" button has been clicked.
        /// 
        /// Post: SelectedMonster has been set to a random monster.
        /// </summary>
        private void chooseRandomEncounter()
        {
            Random randomNumberGenerator = new Random();
            SelectedMonster = CollectionOfMonsters[randomNumberGenerator.Next(0, CollectionOfMonsters.Count - 1)]; //Chooses random index
        }

        #endregion Functions

        #region Interfaces

        /// <summary>
        /// Public instance of PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion Interfaces
    }
}