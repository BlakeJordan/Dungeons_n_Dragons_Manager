using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;

namespace Dungeons_n_Dragons_Manager.Test_Suite.Tests
{
    internal class DiceRolls_Tests
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public DiceRolls_Tests() { }

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
            m_testingOutput.Add("\n\nDiceRollsTabViewmodel Tests"); //Add header.

            D4test();
            D6test();
            D8test();
            D10test();
            D12test();
            D20test();
            D100test();
            ClearRollsTest();

            return m_testingOutput;
        }

        #region Tests
        /// <summary>
        /// D4 button test
        /// </summary>
        private void D4test()
        {
            DiceRollTabViewmodel diceRollTabViewmodel = new DiceRollTabViewmodel();
            diceRollTabViewmodel.ClickD4.Execute(null);
            string rolypoly = diceRollTabViewmodel.rolls.Trim(' ');
            int testRoll = Convert.ToInt32(rolypoly);

            m_testingOutput.Add("\nD4 test:");

            string test1 = "The D4 dice has been rolled --> ";
            if (testRoll <= 0 || testRoll > 4) test1 += "FAILED";
            else test1 += "PASSED";
            m_testingOutput.Add(test1);
        }
        /// <summary>
        /// D6 button test
        /// </summary>
        private void D6test()
        {
            DiceRollTabViewmodel diceRollTabViewmodel = new DiceRollTabViewmodel();
            diceRollTabViewmodel.ClickD6.Execute(null);
            string rolypoly = diceRollTabViewmodel.rolls.Trim(' ');
            int testRoll = Convert.ToInt32(rolypoly);

            m_testingOutput.Add("\nD6 test:");

            string test1 = "The D6 dice has been rolled --> ";
            if (testRoll <= 0 || testRoll > 6) test1 += "FAILED";
            else test1 += "PASSED";
            m_testingOutput.Add(test1);
        }
        /// <summary>
        /// D8 button test
        /// </summary>
        private void D8test()
        {
            DiceRollTabViewmodel diceRollTabViewmodel = new DiceRollTabViewmodel();
            diceRollTabViewmodel.ClickD8.Execute(null);
            string rolypoly = diceRollTabViewmodel.rolls.Trim(' ');
            int testRoll = Convert.ToInt32(rolypoly);

            m_testingOutput.Add("\nD8 test:");

            string test1 = "The D8 dice has been rolled --> ";
            if (testRoll <= 0 || testRoll > 8) test1 += "FAILED";
            else test1 += "PASSED";
            m_testingOutput.Add(test1);
        }
        /// <summary>
        /// D10 button test
        /// </summary>
        private void D10test()
        {
            DiceRollTabViewmodel diceRollTabViewmodel = new DiceRollTabViewmodel();
            diceRollTabViewmodel.ClickD10.Execute(null);
            string rolypoly = diceRollTabViewmodel.rolls.Trim(' ');
            int testRoll = Convert.ToInt32(rolypoly);

            m_testingOutput.Add("\nD10 test:");

            string test1 = "The D10 dice has been rolled --> ";
            if (testRoll <= 0 || testRoll > 10) test1 += "FAILED";
            else test1 += "PASSED";
            m_testingOutput.Add(test1);
        }
        /// <summary>
        /// D12 button test
        /// </summary>
        private void D12test()
        {
            DiceRollTabViewmodel diceRollTabViewmodel = new DiceRollTabViewmodel();
            diceRollTabViewmodel.ClickD12.Execute(null);
            string rolypoly = diceRollTabViewmodel.rolls.Trim(' ');
            int testRoll = Convert.ToInt32(rolypoly);

            m_testingOutput.Add("\nD12 test:");

            string test1 = "The D12 dice has been rolled --> ";
            if (testRoll <= 0 || testRoll > 12) test1 += "FAILED";
            else test1 += "PASSED";
            m_testingOutput.Add(test1);
        }
        /// <summary>
        /// D20 button test
        /// </summary>
        private void D20test()
        {
            DiceRollTabViewmodel diceRollTabViewmodel = new DiceRollTabViewmodel();
            diceRollTabViewmodel.ClickD20.Execute(null);
            string rolypoly = diceRollTabViewmodel.rolls.Trim(' ');
            int testRoll = Convert.ToInt32(rolypoly);

            m_testingOutput.Add("\nD20 test:");

            string test1 = "The D20 dice has been rolled --> ";
            if (testRoll <= 0 || testRoll > 20) test1 += "FAILED";
            else test1 += "PASSED";
            m_testingOutput.Add(test1);
        }
        /// <summary>
        /// D100 button test
        /// </summary>
        private void D100test()
        {
            DiceRollTabViewmodel diceRollTabViewmodel = new DiceRollTabViewmodel();
            diceRollTabViewmodel.ClickD100.Execute(null);
            string rolypoly = diceRollTabViewmodel.rolls.Trim(' ');
            int testRoll = Convert.ToInt32(rolypoly);

            m_testingOutput.Add("\nD100 test:");

            string test1 = "The D100 dice has been rolled --> ";
            if (testRoll <= 0 || testRoll > 100) test1 += "FAILED";
            else test1 += "PASSED";
            m_testingOutput.Add(test1);
        }
        /// <summary>
        /// Clear Rolls button test
        /// </summary>
        private void ClearRollsTest()
        {
            DiceRollTabViewmodel diceRollTabViewmodel = new DiceRollTabViewmodel();
            diceRollTabViewmodel.ClickD4.Execute(null);
            diceRollTabViewmodel.Clear.Execute(null);
            

            m_testingOutput.Add("\nClear Rolls test:");

            string test1 = "The clear rolls button empties the rolls string --> ";
            if (diceRollTabViewmodel.rolls == "") test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }

        #endregion Tests

        #endregion Functions
    }
}
