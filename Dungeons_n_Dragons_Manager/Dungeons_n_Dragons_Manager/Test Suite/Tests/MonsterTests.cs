using Dungeons_n_Dragons_Manager.Models;
using System.Collections.Generic;

namespace Dungeons_n_Dragons_Manager.Test_Suite.Tests
{
    internal class MonsterTests
    {
        public MonsterTests()
        {
            m_testingOutput = new List<string>();
            m_testingOutput.Add("\n\nMonster Tests"); //Add header.
        }

        #region Properties

        private List<string> m_testingOutput { get; set; }

        #endregion Properties

        #region Functions

        public List<string> RunAllTests()
        {
            emptyConstructorTest();
            stringArrayConstructorTest();
            copyConstructorTest();
            toStringTest();
            equalsTest();

            return m_testingOutput;
        }

        #region Tests

        private void emptyConstructorTest()
        {

        }

        private void stringArrayConstructorTest()
        {

        }

        private void copyConstructorTest()
        {

        }

        private void toStringTest()
        {

        }

        private void equalsTest()
        {

        }

        #endregion Tests

        #endregion Functions
    }
}