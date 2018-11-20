using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Collections.Generic;
using System.Linq;

namespace Dungeons_n_Dragons_Manager.Test_Suite.Tests
{
    internal class EncountersTabTests
    {
        public EncountersTabTests()
        {
            m_testingOutput = new List<string>();
            m_testingOutput.Add("\n\nEcountersTabViewmodel Tests"); //Add header.
        }

        #region Properties

        private List<string> m_testingOutput { get; set; }

        #endregion Properties

        #region Functions

        public List<string> RunAllTests()
        {
            constructorTest();
            chooseRandomEncounterTest();

            return m_testingOutput;
        }

        #region Tests

        private void constructorTest()
        {
            EncountersTabViewmodel encountersTabViewmodel = new EncountersTabViewmodel();

            m_testingOutput.Add("Constructor (function):");

            string test1 = "Monsters observable collection is filled --> ";
            if (encountersTabViewmodel.Monsters.Count != 0) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }

        private void chooseRandomEncounterTest()
        {
            EncountersTabViewmodel encountersTabViewmodel = new EncountersTabViewmodel();
            Monster previousMonster = encountersTabViewmodel.SelectedMonster;
            encountersTabViewmodel.ChooseRandomEncounter.Execute(null);
            Monster newMonster = encountersTabViewmodel.SelectedMonster;

            m_testingOutput.Add("\nChooseRandomEncounter (command):");

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