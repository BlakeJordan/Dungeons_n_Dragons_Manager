using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Windows;
using DungeonsDungeons_n_Dragons_Manager.Tools;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// The viewmodel for creating characters
    /// </summary>
    internal class CreateCharacterWindowViewmodel
    {
        /// <summary>
        /// Constructor for the create character viewmodel
        /// @Pre: Create Character window has been opened
        /// @Post: A new character is created with a reference to an existing, blank character
        /// </summary>
        /// /// <param name="character">A reference to the new character</param>
        public CreateCharacterWindowViewmodel(ref Character character)
        {
            m_newCharacter = character;
        }

        /// <summary>
        /// The new character being created
        /// </summary>
        private Character m_newCharacter { get; set; }

        /// <summary>
        /// The current character selected
        /// </summary>
        private Character m_selectedCharacter;

        /// <summary>
        /// A collection of all existing characters 
        /// </summary>
        public ObservableCollection<Character> Characters { get; set; }

        /// <summary>
        /// Handles the saving of the new created character
        /// @Pre: The Create Character button has been clicked
        /// @Post: Adds the new character to 
        /// </summary>
        public void OnSaveCharacter()
        {
            Console.WriteLine("AYYYY");
        }

        public Character SelectedCharacter
        {
            get
            {
                if (m_selectedCharacter == null)
                {
                    m_selectedCharacter = Characters[0];
                }
                return m_selectedCharacter;
            }
            set
            {
                if (value != m_selectedCharacter)
                {
                    m_selectedCharacter = value;
                    OnPropertyRaised(nameof(SelectedCharacter));
                }
            }
        }

        #region Commands

        private bool m_canClick
        {
            get { return true; }
        }

        private ICommand m_Click;

        public ICommand Click
        {
            get
            {
                return m_Click ?? (m_Click = new CommandHandler(() => OnSaveCharacter(), m_canClick));
            }
        }

        #endregion Commands

        #region Interfaces

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

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