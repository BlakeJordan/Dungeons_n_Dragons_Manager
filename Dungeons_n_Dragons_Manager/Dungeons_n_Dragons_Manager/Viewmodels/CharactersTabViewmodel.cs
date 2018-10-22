using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Windows;
using DungeonsDungeons_n_Dragons_Manager.Tools;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// Viewmodel for the Characters Tab in the Main Window.
    /// </summary>
    internal class CharactersTabViewmodel
    {
        /// <summary>
        /// This constructor calls parseMonsterResource.
        /// @Pre: None.
        /// @Post: CollectionOfCharacter is intialized.
        /// </summary>
        public CharactersTabViewmodel()
        {
            Characters = new ObservableCollection<Character>();
        }

        #region Members
        /// <summary>
        /// ObservableCollection of Characters which is bound to the combobox.
        /// </summary>
        public static ObservableCollection<Character> Characters { get; set; }

        /// <summary>
        /// Private backing to store the currently selected character in the combobox.
        /// </summary>
        public static Character m_SelectedCharacter;

        /// <summary>
        /// Public facing accessor to m_selectedCharacter.
        /// </summary>
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
        /// <summary>
        /// Boolean which determines if CreateCharacter can be executed.
        /// </summary>
        private bool m_canCreateCharacter
        {
            get { return true; } //Potentially add check to see if maximum number of characters has been reached later.
        }

        /// <summary>
        /// Command binded to the "create character" button which calls createCharacter if m_canCreateCharacter is true.
        /// </summary>
        private ICommand m_createCharacter;

        /// <summary>
        /// Public facing accessor to m_createCharacter.
        /// </summary>
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
        public void createNewCharacter()
        {
            Character newCharacter = new Character(); //Create blank character.
            CreateCharacterWindow createCharacterWindow = new CreateCharacterWindow(ref newCharacter); //Pass character to window by reference to be modified.
            createCharacterWindow.ShowDialog(); //Open window instance until closed.
            if(createCharacterWindow.SaveCharacter)
            {
                Characters.Add(newCharacter); //Add modified character to collection.
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
        /// @Pre: Private backing value has been changed.
        /// @Post: UI now reflects current value.
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