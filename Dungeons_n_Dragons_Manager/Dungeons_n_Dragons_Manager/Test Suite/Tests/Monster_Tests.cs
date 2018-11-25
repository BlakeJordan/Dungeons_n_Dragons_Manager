using Dungeons_n_Dragons_Manager.Models;
using System.Collections.Generic;

namespace Dungeons_n_Dragons_Manager.Test_Suite.Tests
{
    internal class Monster_Tests
    {
        /// <summary>
        /// Defualt constructor.
        /// </summary>
        public Monster_Tests() { }

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
            m_testingOutput.Add("\n\nMonster Tests"); //Add header.

            defaultConstructorTest();
            stringArrayConstructorTest();
            copyConstructorTest();
            toStringTest();
            equalsTest();

            return m_testingOutput;
        }

        #region Tests

        /// <summary>
        /// Default constructor testing.
        /// </summary>
        private void defaultConstructorTest()
        {
            Monster testMonster = new Monster();

            bool stringsSetCorrectly = true;
            if (testMonster.Name != string.Empty || testMonster.HitPointsDice != string.Empty || testMonster.ArmorClassType != string.Empty) stringsSetCorrectly = false;

            bool modifersSetCorrectly = true;
            if (testMonster.StrengthMod != -6 || testMonster.DexterityMod != -6 || testMonster.ConstitutionMod != -6 || testMonster.IntelligenceMod != -6 || testMonster.WisdomMod != -6 || testMonster.CharismaMod != -6) modifersSetCorrectly = false;

            bool acAndCrSetCorrectly = true;
            if (testMonster.ArmorClass != -1 || testMonster.ChallengeRating != -1) acAndCrSetCorrectly = false;

            m_testingOutput.Add("Default Constructor:");

            string test1 = "String properties set correctly --> ";
            if (stringsSetCorrectly) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);

            string test2 = "Stat modifers set correctly --> ";
            if (modifersSetCorrectly) test2 += "PASSED";
            else test2 += "FAILED";
            m_testingOutput.Add(test2);

            string test3 = "AC and CR set correctly --> ";
            if (acAndCrSetCorrectly) test3 += "PASSED";
            else test3 += "FAILED";
            m_testingOutput.Add(test3);
        }

        /// <summary>
        /// String array constructor testing.
        /// </summary>
        private void stringArrayConstructorTest()
        {
            /* Properties Ordering
             * 
             * Name;ChallengeRating;ChallengeXP;ACType;AC;STR;STRMod;DEX;DEXMod;CON;CONMod;INT;INTMod;WIS;WISMod;CHA;CHAMod;HPDice;HP;Environments;IsCustom
             * */

            string monsterString = "Adult Red Dragon;17;18000;Natural Armor;19;27;8;10;0;25;7;16;3;13;1;21;5;19d12 + 133;256;Hill,Mountain;False";
            string[] values = monsterString.Split(';');
            Monster testMonster = new Monster(values);

            bool allPropertiesSetCorrectly = true;

            #region Checks

            if (testMonster.Name != "Adult Red Dragon") allPropertiesSetCorrectly = false;

            //Challenge stats
            if (testMonster.ChallengeRating != 17) allPropertiesSetCorrectly = false;
            if (testMonster.ChallengeXP != 18000) allPropertiesSetCorrectly = false;
            
            //Armor classes
            if (testMonster.ArmorClassType != "Natural Armor") allPropertiesSetCorrectly = false;
            if (testMonster.ArmorClass != 19) allPropertiesSetCorrectly = false;

            //Stats
            if (testMonster.Strength != 27) allPropertiesSetCorrectly = false;
            if (testMonster.StrengthMod != 8) allPropertiesSetCorrectly = false;
            if (testMonster.Dexterity != 10) allPropertiesSetCorrectly = false;
            if (testMonster.DexterityMod != 0) allPropertiesSetCorrectly = false;
            if (testMonster.Constitution != 25) allPropertiesSetCorrectly = false;
            if (testMonster.ConstitutionMod != 7) allPropertiesSetCorrectly = false;
            if (testMonster.Intelligence != 16) allPropertiesSetCorrectly = false;
            if (testMonster.IntelligenceMod != 3) allPropertiesSetCorrectly = false;
            if (testMonster.Wisdom != 13) allPropertiesSetCorrectly = false;
            if (testMonster.WisdomMod != 1) allPropertiesSetCorrectly = false;
            if (testMonster.Charisma != 21) allPropertiesSetCorrectly = false;
            if (testMonster.CharismaMod != 5) allPropertiesSetCorrectly = false;

            //Hit points
            if (testMonster.HitPointsDice != "19d12 + 133") allPropertiesSetCorrectly = false;
            if (testMonster.HitPoints != 256) allPropertiesSetCorrectly = false;

            //Environments
            if (testMonster.IsArctic != false) allPropertiesSetCorrectly = false;
            if (testMonster.IsCoastal != false) allPropertiesSetCorrectly = false;
            if (testMonster.IsDesert != false) allPropertiesSetCorrectly = false;
            if (testMonster.IsForest != false) allPropertiesSetCorrectly = false;
            if (testMonster.IsGrassland != false) allPropertiesSetCorrectly = false;
            if (testMonster.IsHill != true) allPropertiesSetCorrectly = false;
            if (testMonster.IsMountain!= true) allPropertiesSetCorrectly = false;
            if (testMonster.IsSwamp != false) allPropertiesSetCorrectly = false;
            if (testMonster.IsUnderdark != false) allPropertiesSetCorrectly = false;
            if (testMonster.IsUnderwater != false) allPropertiesSetCorrectly = false;
            if (testMonster.IsUrban != false) allPropertiesSetCorrectly = false;
            if (string.Join(",", testMonster.Environments) != "Hill,Mountain") allPropertiesSetCorrectly = false;

            if (testMonster.IsCustom != false) allPropertiesSetCorrectly = false;

            #endregion

            m_testingOutput.Add("\nString Array Constructor:");

            string test1 = "All properties set correctly --> ";
            if (allPropertiesSetCorrectly) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }

        /// <summary>
        /// Copy constructor testing.
        /// </summary>
        private void copyConstructorTest()
        {
            string monsterString = "Adult Red Dragon;17;18000;Natural Armor;19;27;8;10;0;25;7;16;3;13;1;21;5;19d12 + 133;256;Hill,Mountain;False";
            string[] values = monsterString.Split(';');
            Monster monsterToCopy = new Monster(values);
            Monster copyOfMonster = new Monster(monsterToCopy);

            bool copiedCorrectly = copyOfMonster.Equals(monsterToCopy);

            m_testingOutput.Add("\nCopy Constructor:");

            string test1 = "Copied correctly --> ";
            if (copiedCorrectly) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }

        /// <summary>
        /// toString function testing.
        /// </summary>
        private void toStringTest()
        {
            string monsterString = "Adult Red Dragon;17;18000;Natural Armor;19;27;8;10;0;25;7;16;3;13;1;21;5;19d12 + 133;256;Hill,Mountain;False";
            string[] values = monsterString.Split(';');
            Monster monster = new Monster(values);

            bool toStringWorks = monsterString == monster.ToString();

            m_testingOutput.Add("\ntoString:");

            string test1 = "Outputs correctly --> ";
            if (toStringWorks) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }

        /// <summary>
        /// equals function testing.
        /// </summary>
        private void equalsTest()
        {
            string monsterString = "Adult Red Dragon;17;18000;Natural Armor;19;27;8;10;0;25;7;16;3;13;1;21;5;19d12 + 133;256;Hill,Mountain;False";
            string[] values = monsterString.Split(';');
            Monster monster1 = new Monster(values);
            Monster monster2 = new Monster(values);
            Monster monster3 = new Monster();
            monster3.Name = "TEST";

            bool equalsWorks = monster1.Equals(monster2);
            bool unequalWorks = monster1.Equals(monster3);

            m_testingOutput.Add("\nEquals:");

            string test1 = "Returns true with equal monsters --> ";
            if (equalsWorks) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);

            string test2 = "Returns false with unequal monsters --> ";
            if (!unequalWorks) test2 += "PASSED";
            else test2 += "FAILED";
            m_testingOutput.Add(test2);
        }

        #endregion Tests

        #endregion Functions
    }
}