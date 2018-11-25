using Dungeons_n_Dragons_Manager.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_n_Dragons_Manager.Test_Suite.Tests
{
    class MainWindowViewmodel_Tests
    {
        /// <summary>
        /// Defualt constructor.
        /// </summary>
        public MainWindowViewmodel_Tests() { }

        /// <summary>
        /// Stores all testing results.
        /// </summary>
        private List<string> m_testingOutput = new List<string>();

        #region Functions

        /// <summary>
        /// Executes all tests.
        /// </summary>
        /// <returns>Returns m_testingOutput.</returns>
        public List<string> RunAllTests()
        {
            m_testingOutput.Add("\n\nMainWindowViewmodel Tests"); //Add header.

            defaultConstructorTest();

            return m_testingOutput;
        }

        #region Tests

        /// <summary>
        /// Default constructor testing.
        /// </summary>
        private void defaultConstructorTest()
        {
            Properties.Settings.Default.DefaultMonstersList = null;
            MainWindowViewmodel mainWindowViewmodel = new MainWindowViewmodel();

            bool subViewmodelsInitalized = mainWindowViewmodel.CharactersTabViewmodel != null && mainWindowViewmodel.DiceRollTabViewmodel != null &&
                                          mainWindowViewmodel.EncountersTabViewmodel != null && mainWindowViewmodel.MusicPlayerTabViewmodel != null;

            m_testingOutput.Add("Default Constructor:");

            string test1 = "DefaultMonstersList is initalized on first-time appliation opening --> ";
            if (Properties.Settings.Default.DefaultMonstersList != null) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);

            string test2 = "Sub-viewmodels initialized correctly --> ";
            if (subViewmodelsInitalized) test2 += "PASSED";
            else test2 += "PASSED";
            m_testingOutput.Add(test2);
        }

        #endregion Tests

        #endregion Functions
    }
}
