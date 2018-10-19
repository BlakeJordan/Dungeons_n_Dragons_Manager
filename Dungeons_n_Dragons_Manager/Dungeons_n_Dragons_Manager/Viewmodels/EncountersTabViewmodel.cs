using Dungeons_n_Dragons_Manager.Models;
using DungeonsDungeons_n_Dragons_Manager.Tools;
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
    internal class EncountersTabViewmodel : INotifyPropertyChanged
    {
        //Constructor
        public EncountersTabViewmodel()
        {
            CollectionOfMonsters = new ObservableCollection<Monster>();
            parseMonstersResource();
        }

        #region Members

        public ObservableCollection<Monster> CollectionOfMonsters { get; set; }

        private Monster m_selectedMonster;

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

        private bool m_canChooseRandomEncounter
        {
            get { return true; } //Add check to see if characters are created later.
        }

        private ICommand m_chooseRandomEncounter;

        public ICommand ChooseRandomEncounter
        {
            get
            {
                return m_chooseRandomEncounter ?? (m_chooseRandomEncounter = new CommandHandler(() => chooseRandomEncounter(), m_canChooseRandomEncounter));
            }
        }

        #endregion Commands

        #region Functions

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

        private void chooseRandomEncounter()
        {
            Random randomNumberGenerator = new Random();
            SelectedMonster = CollectionOfMonsters[randomNumberGenerator.Next(0, CollectionOfMonsters.Count - 1)]; //Chooses random index
        }

        #endregion Functions

        #region Interfaces

        public event PropertyChangedEventHandler PropertyChanged;

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