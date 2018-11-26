 using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Test_Suite;
using Dungeons_n_Dragons_Manager.Tools;
using Dungeons_n_Dragons_Manager.Windows;
using System;
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
            Properties.Settings.Default.Reset();                                              //Uncomment to delete current settings!

            initalizeMonstersList();

            DiceRollTabViewmodel = new DiceRollTabViewmodel();
            CharactersTabViewmodel = new CharactersTabViewmodel();
            EncountersTabViewmodel = new EncountersTabViewmodel();
            MusicPlayerTabViewmodel = new MusicPlayerTabViewmodel();
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

        #endregion Sub-Viewmodels

        #region Commands

        /// <summary>
        /// Command binded to the "Test Suite" menu item.
        /// </summary>
        private ICommand m_openTestSuite;

        /// <summary>
        /// Public facing accessor to m_openTestSuite.
        /// </summary>
        public ICommand OpenTestSuite
        {
            get
            {
                return m_openTestSuite ?? (m_openTestSuite = new CommandHandler(() => openTestSuite(), true));
            }
        }

        /// <summary>
        /// Command binded to the "User Manual" menu item.
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

        /// <summary>
        /// Command binded to the "About" menu item.
        /// </summary>
        private ICommand m_openAboutBox;

        /// <summary>
        /// Public facing accessor to m_openAboutBox.
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
        /// Creates and opens a TestSuiteWindow.
        /// 
        /// Pre: "Test Suite" menu item has been clicked.
        /// 
        /// Post: The test suite window is open.
        /// </summary>
        private void openTestSuite()
        {
            TestSuiteWindow testSuiteWindow = new TestSuiteWindow();
            testSuiteWindow.ShowDialog();
        }

        /// <summary>
        /// Opens user manual in preferred web browser.
        /// 
        /// Pre: None.
        /// 
        /// Post: The user manual PDF has been opened in the preferred web browser.
        /// </summary>
        private void openUserManual()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string userManualFilePath = currentDirectory + "\\Assets\\UserManual\\UserManual.pdf";
            System.Diagnostics.Process.Start(userManualFilePath);
        }

        /// <summary>
        /// Creates and opens the about box.
        /// 
        /// Pre: "About" menu item has been clicked.
        /// 
        /// Post: About box has been opened.
        /// </summary>
        private void openAboutBox()
        {
            AboutBoxWindow aboutBoxWindow = new AboutBoxWindow();
            aboutBoxWindow.Show();
        }

        /// <summary>
        /// Parses the Monsters string in resources and assigns the DefualtMonstersList the parsed monsters.
        /// 
        /// Pre: None.
        /// 
        /// Post: DefaultMonstersList is not null or empty.
        /// </summary>
        private void initalizeMonstersList()
        {
            //If DefaultMonstersList has not been parsed, parse it.
            if (Properties.Settings.Default.DefaultMonstersList == null || Properties.Settings.Default.DefaultMonstersList.Count != 159)
            {
                Properties.Settings.Default.DefaultMonstersList = new List<Monster>();

                //Parse Monsters string in Resources.
                List<string> defaultMonstersData = new List<string>(Properties.Resources.Monsters.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
                defaultMonstersData.RemoveAt(0); //Remove data header.

                foreach (string monsterString in defaultMonstersData)
                {
                    string[] values = monsterString.Split(';');
                    Properties.Settings.Default.DefaultMonstersList.Add(new Monster(values));
                }
                Properties.Settings.Default.Save();
            }
        }

        #endregion Functions
    }
}