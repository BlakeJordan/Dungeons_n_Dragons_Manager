using Dungeons_n_Dragons_Manager.Models;
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
    /// Viewmodel for the Characters Tab in the Main Window.
    /// </summary>
    public class CharactersTabViewmodel : INotifyPropertyChanged
    {
        /// <summary>
        /// This constructor initializes a collection of characters
        ///
        /// Pre: None.
        ///
        /// Post: An observable collection of Characters is intialized.
        /// </summary>
        public CharactersTabViewmodel() { }

        #region Properties

        /// <summary>
        /// Private backing to store the currently selected character in the combobox.
        /// </summary>
        private Character m_SelectedCharacter;

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

        /// <summary>
        /// Boolean which determines if EditCharacter can be executed.
        /// </summary>
        public bool CanEdit
        {
            get
            {
                if (Properties.Settings.Default.CustomCharactersList == null || Properties.Settings.Default.CustomCharactersList.Count == 0) return false;
                else return true;
            }
        }

        #endregion Properties

        #region ComboBox Sources

        /// <summary>
        /// An observable collection of Characters which is bound to the combobox.
        /// </summary>
        private ObservableCollection<Character> m_Characters;

        /// <summary>
        /// Public accessor for m_Characters
        /// </summary>
        public ObservableCollection<Character> Characters
        {
            get
            {
                if (m_Characters == null)
                {
                    m_Characters = new ObservableCollection<Character>();
                    parseCharactersResource();
                }
                return m_Characters;
            }
            set
            {
                if (m_Characters != value)
                {
                    m_Characters = value;
                    if (m_Characters.Count != 0)
                    {
                        SelectedCharacter = Characters[0];
                    }
                    OnPropertyRaised(nameof(Characters));
                }
            }
        }
        #endregion ComboBox Sources

        #region Commands

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
                return m_createCharacter ?? (m_createCharacter = new CommandHandler(() => createNewCharacter(), true));
            }
        }

        /// <summary>
        /// Command binded to the "edit character" button which calls editCharacter if m_canEditCharacter is true.
        /// </summary>
        private ICommand m_editCharacter;

        /// <summary>
        /// Public facing accessor to m_editCharacter.
        /// </summary>
        public ICommand EditCharacter
        {
            get
            {
                return m_editCharacter ?? (m_editCharacter = new CommandHandler(() => CharacterRevision(), true));
            }
        }

        #endregion Commands

        #region Functions

        private void parseCharactersResource()
        {
            List<Character> listOfCharacters = new List<Character>(); //Temp list to store Characters

            if (Properties.Settings.Default.CustomCharactersList != null)
            {
                listOfCharacters.AddRange(Properties.Settings.Default.CustomCharactersList);
            }

            Characters = new ObservableCollection<Character>(listOfCharacters.OrderBy(o => o.Name).ToList()); //Sort list by name and create observable collection
        }

        /// <summary>
        /// Creates a new character and passes it by reference to an instance of CreateCharacterWindow to be edited.
        ///
        /// Pre: "Create Character" button has been clicked.
        ///
        /// Post: A new character has been created.
        /// </summary>
        public void createNewCharacter()
        {
            CreateCharacterWindow createCharacterWindow = new CreateCharacterWindow();
            createCharacterWindow.ShowDialog(); //Open window instance until closed.
            OnPropertyRaised(nameof(CanEdit));
            parseCharactersResource();
        }

        /// <summary>
        /// Copies an existing character and passes it by reference to an instance of EditCharacterWindow to be edited.
        ///
        /// Pre: "Edit Character" button has been clicked and m_canEditCharacter is true
        ///
        /// Post: The edit character window is opened and the user can start editing
        /// </summary>
        public void CharacterRevision()
        {
            Character EditedCharacter = new Character(SelectedCharacter); //Copy existing character.
            EditCharacterWindow editCharacterWindow = new EditCharacterWindow(ref EditedCharacter); //Pass character to window by reference to be modified.
            editCharacterWindow.ShowDialog(); //Open window instance until closed.
            parseCharactersResource();
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