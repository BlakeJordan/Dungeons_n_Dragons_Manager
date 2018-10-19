using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Windows;
using DungeonsDungeons_n_Dragons_Manager.Tools;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    internal class CharactersTabViewmodel
    {
        //Constructor
        public CharactersTabViewmodel()
        {
            Characters = new ObservableCollection<Character>();
            // parseMonstersResource();
        }

        #region Members

        public ObservableCollection<Character> Characters { get; set; }

        private Character m_SelectedCharacter;

        public Character SelectedCharacter
        {
            get
            {
                if (m_SelectedCharacter == null && Characters.Count != 0)
                {
                    m_SelectedCharacter = Characters[0];
                }
                return m_SelectedCharacter;
            }
            set
            {
                if (value != m_SelectedCharacter)
                {
                    m_SelectedCharacter = value;
                    OnPropertyRaised(nameof(SelectedCharacter));
                }
            }
        }

        #endregion Members

        #region Commands

        private bool m_canCreateCharacter
        {
            get { return true; } //Potentially add check to see if maximum number of characters has been reached later.
        }

        private ICommand m_createCharacter;

        public ICommand CreateCharacter
        {
            get
            {
                return m_createCharacter ?? (m_createCharacter = new CommandHandler(() => createNewCharacter(), m_canCreateCharacter));
            }
        }

        #endregion Commands

        #region Functions

        /// <summary>
        /// Creates a new character and passes it by reference to an instance of CreateCharacterWindow to be edited.
        /// @pre: "Create Character" button has been clicked.
        /// @post: A new character has been created.
        /// </summary>
        private void createNewCharacter()
        {
            Character newCharacter = new Character(); //Create blank character.
            CreateCharacterWindow createCharacterWindow = new CreateCharacterWindow(ref newCharacter); //Pass character to window by reference to be modified.
            createCharacterWindow.ShowDialog(); //Open window instance until closed.
            Characters.Add(newCharacter); //Add modified character to collection.
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