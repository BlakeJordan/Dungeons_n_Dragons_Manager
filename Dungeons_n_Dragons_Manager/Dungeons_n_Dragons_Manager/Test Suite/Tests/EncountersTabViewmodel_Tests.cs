using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Collections.Generic;
using System.Linq;

namespace Dungeons_n_Dragons_Manager.Test_Suite.Tests
{
    /// <summary>
    /// Test class for the EncountersTabViewmodel class.
    /// </summary>
    internal class EncountersTabViewmodel_Tests
    {
        /// <summary>
        /// Defualt constructor.
        /// </summary>
        public EncountersTabViewmodel_Tests() { }

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
            m_testingOutput.Add("\n\nEncountersTabViewmodel Tests"); //Add header.

            defaultConstructorTest();
            chooseRandomEncounterTest();

            return m_testingOutput;
        }

        #region Tests

        /// <summary>
        /// Default constructor testing.
        /// </summary>
        private void defaultConstructorTest()
        {
            EncountersTabViewmodel encountersTabViewmodel = new EncountersTabViewmodel();

            m_testingOutput.Add("Default Constructor:");

            string test1 = "Monsters observable collection is filled --> ";
            if (encountersTabViewmodel.Monsters.Count != 0) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }

        /// <summary>
        /// ChooseRandomEncounter command testing.
        /// </summary>
        private void chooseRandomEncounterTest()
        {
            EncountersTabViewmodel encountersTabViewmodel = new EncountersTabViewmodel();
            Monster previousMonster = encountersTabViewmodel.SelectedMonster;
            encountersTabViewmodel.ChooseRandomEncounter.Execute(null);
            Monster newMonster = encountersTabViewmodel.SelectedMonster;

            m_testingOutput.Add("\nChooseRandomEncounter:");

            string test1 = "New monster has been selected --> ";
            if (previousMonster != newMonster) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);

            string test2 = "Newly selected monster is associated with selected environment --> ";
            var match = newMonster.Environments.FirstOrDefault(o => o.Contains(encountersTabViewmodel.SelectedEnvironment));
            if (match != null) test2 += "PASSED";
            else test2 += "FAILED";
            m_testingOutput.Add(test2);
        }

        #endregion Tests

        #endregion Functions
    }
}