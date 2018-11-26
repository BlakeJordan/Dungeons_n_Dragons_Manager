using System;
using System.Collections.Generic;
using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_n_Dragons_Manager.Test_Suite.Tests
{
    internal class CharactersTabViewmodel_Tests 
    {
        /// <summary>
        /// Defualt constructor.
        /// </summary>
        public CharactersTabViewmodel_Tests() { }

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
            m_testingOutput.Add("\n\nCharactersTabViewmodel Tests"); //Add header.

            defaultConstructorTest();

            return m_testingOutput;
        }

        #region Tests

        /// <summary>
        /// Default constructor testing.
        /// </summary>
        private void defaultConstructorTest()
        {
            CharactersTabViewmodel CharactersTabViewmodel = new CharactersTabViewmodel();

            m_testingOutput.Add("Default Constructor:");

            string test1 = "Characters observable collection is filled --> ";
            if (CharactersTabViewmodel.Characters.Count == CreateCharacterWindowViewmodel.CharacterCount()) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }


        #endregion Tests

        #endregion Functions
    }
}
