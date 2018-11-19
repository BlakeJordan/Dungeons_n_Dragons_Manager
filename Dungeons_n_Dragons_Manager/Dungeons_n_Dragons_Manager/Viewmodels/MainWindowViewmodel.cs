using Dungeons_n_Dragons_Manager.Test_Suite;
using Dungeons_n_Dragons_Manager.Tools;
using Dungeons_n_Dragons_Manager.Windows;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// Viewmodel for the main window.
    /// </summary>
    public class MainWindowViewmodel
    {
        /// <summary>
        /// Constructor for the MainWindowViewmodel.
        /// 
        /// Pre: None.
        /// 
        /// Post: Sub-Viewmodels have been intialized.
        /// </summary>
        public MainWindowViewmodel()
        {
            DiceRollTabViewmodel = new DiceRollTabViewmodel();
            CharactersTabViewmodel = new CharactersTabViewmodel();
            EncountersTabViewmodel = new EncountersTabViewmodel();
            MusicPlayerTabViewmodel = new MusicPlayerTabViewmodel();

            TestSuite test = new TestSuite();
            List<string> test2 = test.RunAllTests();
        }

        #region Sub-Viewmodels

        /// <summary>
        /// DataContext for the Dice Tab.
        /// </summary>
        public DiceRollTabViewmodel DiceRollTabViewmodel { get; set; }

        /// <summary>
        /// DataContext for the Characters Tab.
        /// </summary>
        public CharactersTabViewmodel CharactersTabViewmodel { get; set; }

        /// <summary>
        /// DataContext for the Encounters Tab.
        /// </summary>
        public EncountersTabViewmodel EncountersTabViewmodel { get; set; }

        /// <summary>
        /// DataContext for the Music Tab.
        /// </summary>
        public MusicPlayerTabViewmodel MusicPlayerTabViewmodel { get; set; }

        #endregion Sub Viewmodels

        #region Commands

        /// <summary>
        /// Command binded to the "Help" button.
        /// </summary>
        private ICommand m_openUserManual;

        /// <summary>
        /// Public facing accessor to m_openUserManual.
        /// </summary>
        public ICommand OpenUserManual
        {
            get
            {
                return m_openUserManual ?? (m_openUserManual = new CommandHandler(() => openUserManual(), true));
            }
        }

        private ICommand m_openAboutBox;

        /// <summary>
        /// Public facing accessor to m_openUserManual.
        /// </summary>
        public ICommand OpenAboutBox
        {
            get
            {
                return m_openAboutBox ?? (m_openAboutBox = new CommandHandler(() => openAboutBox(), true));
            }
        }

        #endregion Commands

        #region Functions

        /// <summary>
        /// Opens user manual in preferred web browser.
        /// </summary>
        private void openUserManual()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string userManualFilePath = currentDirectory + "\\Assets\\UserManual\\UserManual.html";
            System.Diagnostics.Process.Start(userManualFilePath);
        }

        /// <summary>
        /// Creates and opens an about box.
        /// </summary>
        private void openAboutBox()
        {
            AboutBoxWindow aboutBoxWindow = new AboutBoxWindow();
            aboutBoxWindow.Show();
        }

        #endregion Functions
    }
}