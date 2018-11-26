using Dungeons_n_Dragons_Manager.Test_Suite.Tests;
using System;
using System.Collections.Generic;

namespace Dungeons_n_Dragons_Manager.Test_Suite
{
    /// <summary>
    /// Executive class for all test classes.
    /// </summary>
    internal class TestSuite
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TestSuite() { }

        /// <summary>
        /// Stores all tests outputs.
        /// </summary>
        private List<String> m_testingOutput = new List<string>();

        /// <summary>
        /// Executes all test classes.
        /// </summary>
        /// <returns>Output of all test classes.</returns>
        public List<string> RunAllTests()
        {
            m_testingOutput.AddRange(new MainWindowViewmodel_Tests().RunAllTests()); //Add MainWindowViewmodel tests.
            m_testingOutput.AddRange(new EncountersTabViewmodel_Tests().RunAllTests()); //Add EncountersTabViewmodel tests.
            m_testingOutput.AddRange(new CharactersTabViewmodel_Tests().RunAllTests()); //Add CharactersTabViewmodel tests.
            m_testingOutput.AddRange(new Monster_Tests().RunAllTests()); //Add Monster tests.
            m_testingOutput.AddRange(new Character_Tests().RunAllTests()); // Add Character tests.
            m_testingOutput.AddRange(new DiceRolls_Tests().RunAllTests()); //Add dice roll tests.
            return m_testingOutput;
        }
    }
}