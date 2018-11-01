﻿using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Tools;
using Dungeons_n_Dragons_Manager.Windows;
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
            parseMonstersResource();
            Environments = Properties.Resources.Environments.Split(';').ToList();
            SelectedEnvironment = Environments[0];
        }

        #region Members

        /// <summary>
        /// ObservableCollection of Monsters which is bound to a combobox.
        /// </summary>
        public ObservableCollection<Monster> Monsters { get; set; }

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
                    m_selectedMonster = Monsters[0];
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

        /// <summary>
        /// List of environments that are bound to a combobox.
        /// </summary>
        public List<string> Environments { get; set; }

        /// <summary>
        /// Stores the currently selected environment.
        /// </summary>
        public string SelectedEnvironment { get; set; }


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

        /// <summary>
        /// Boolean which determines if CreateMonster can be executed.
        /// </summary>
        private bool m_canCreateMonster
        {
            get { return true; } //Add check to see if characters are created later.
        }

        /// <summary>
        /// Command binded to the "create monster" button which calls createMonster if m_canCreateMonster is true.
        /// </summary>
        private ICommand m_createMonster;

        /// <summary>
        /// Public facing accessor to m_createMonster.
        /// </summary>
        public ICommand CreateMonster
        {
            get
            {
                return m_createMonster ?? (m_createMonster = new CommandHandler(() => createNewMonster(), m_canCreateMonster));
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
            List<Monster> listOfMonsters = new List<Monster>(); //Temp list to store monsters
            List<string> monsterDataEntries = Properties.Resources.Monsters.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            monsterDataEntries.RemoveAt(0); //Remove data header
            foreach (string entry in monsterDataEntries)
            {
                string[] values = entry.Split(';');
                listOfMonsters.Add(new Monster(values));
            }
            Monsters = new ObservableCollection<Monster>( listOfMonsters.OrderBy(o => o.Name).ToList() ); //Sort list by name and create observable collection
        }

        /// <summary>
        /// Private function that sets SelectedMonster to a random monster in CollectionOfMonsters based on chosen environment.
        ///
        /// Pre: "Random Encounter" button has been clicked.
        ///
        /// Post: SelectedMonster has been set to a random monster.
        /// </summary>
        private void chooseRandomEncounter()
        {
            Random randomNumberGenerator = new Random();
            List<Monster> filteredMonsters = Monsters.Where(o => o.Environments.Contains(SelectedEnvironment) == true).ToList();
            SelectedMonster = filteredMonsters[randomNumberGenerator.Next(0, filteredMonsters.Count - 1)]; //Chooses random index
        }

        /// <summary>
        /// Creates a new character and passes it by reference to an instance of CreateCharacterWindow to be edited.
        ///
        /// Pre: "Create Character" button has been clicked.
        ///
        /// Post: A new character has been created.
        /// </summary>
        public void createNewMonster()
        {
            Monster newMonster = new Monster(); //Create blank character.
            CreateMonsterWindow createMonsterWindow = new CreateMonsterWindow(ref newMonster); //Pass character to window by reference to be modified.
            createMonsterWindow.ShowDialog(); //Open window instance until closed.
            if (createMonsterWindow.SaveMonster)
            {
                Monsters.Add(newMonster); //Add modified character to collection.
            }
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