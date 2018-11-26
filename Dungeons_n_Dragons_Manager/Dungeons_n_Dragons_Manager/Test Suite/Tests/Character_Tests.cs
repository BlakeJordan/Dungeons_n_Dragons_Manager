using System;
using System.Collections.Generic;
using System.Linq;
using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Text;
using System.Threading.Tasks;
using static Dungeons_n_Dragons_Manager.Models.Character;
using Attribute = Dungeons_n_Dragons_Manager.Models.Character.Attribute;

namespace Dungeons_n_Dragons_Manager.Test_Suite.Tests
{
    partial class Character_Tests
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Character_Tests() { }

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
            m_testingOutput.Add("\n\nCharacter Tests"); //Add header.
            defaultConstructorTest();
            copyConstructorTest();
            calculateStatsTest();
            calculateSkillsTest();
            setProficiencyTest();

            return m_testingOutput;
        }

        #region Tests

        /// <summary>
        /// Default constructor testing.
        /// </summary>
        private void defaultConstructorTest()
        {
            Character testCharacter = new Character();

            bool skillsAreSet = true;
            if (testCharacter.Acrobatics == null || testCharacter.AnimalHandling == null || testCharacter.Arcana == null ||
                testCharacter.Athletics == null || testCharacter.Deception == null || testCharacter.History == null || testCharacter.Insight == null ||
                testCharacter.Intimidation == null || testCharacter.Investigation == null || testCharacter.Medicine == null || testCharacter.Nature == null ||
                testCharacter.Perception == null || testCharacter.Performance == null || testCharacter.Persuasion == null || testCharacter.Religion == null ||
                testCharacter.SleightOfHand == null || testCharacter.Stealth == null || testCharacter.Survival == null)
            {
                skillsAreSet= false;
            }

            bool attributesAreSet = true;
            if (testCharacter.Strength == null || testCharacter.Dexterity == null || testCharacter.Wisdom == null || testCharacter.Intelligence == null ||
                testCharacter.Constitution == null || testCharacter.Charisma == null)
            {
                attributesAreSet = false;
            }

            bool skillsListContainsAllSkills = true;
            foreach (Skill testSkill in testCharacter.Skills)
            {
                if (testSkill == null)
                {
                    skillsListContainsAllSkills = false;
                }
            }

            bool attribuesListContainsAllAttributes = true;
            foreach (Attribute testAttribute in testCharacter.Attributes)
            {
                if (testAttribute == null)
                {
                    attribuesListContainsAllAttributes = false;
                }
            }

            m_testingOutput.Add("Default Constructor:");

            string test1 = "All skills exist --> ";
            if (skillsAreSet) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);

            string test2 = "All attributes exist --> ";
            if (attributesAreSet) test2 += "PASSED";
            else test2 += "FAILED";
            m_testingOutput.Add(test2);

            string test3 = "Skills collection contains all skills --> ";
            if (skillsListContainsAllSkills) test3 += "PASSED";
            else test3 += "FAILED";
            m_testingOutput.Add(test3);

            string test4 = "Attributes collection contains all attributes --> ";
            if (attribuesListContainsAllAttributes) test4 += "PASSED";
            else test3 += "FAILED";
            m_testingOutput.Add(test4);
        }

        /// <summary>
        /// Copy constructor testing.
        /// </summary>
        private void copyConstructorTest()
        {
            Character targetCharacter = new Character();
            targetCharacter.Name = "test";
            targetCharacter.Race = "human";
            foreach (Skill testSkill in targetCharacter.Skills)
            {
                testSkill.score = 3;
            }
            foreach (Attribute testAttribute in targetCharacter.Attributes)
            {
                testAttribute.score = 5;
            }
            targetCharacter.CalculateSkills();
            targetCharacter.SetProficiency();
            targetCharacter.CalculateStats();
            Character copyCharacter = new Character(targetCharacter);
            bool copiedCorrectly = copyCharacter.Equals(targetCharacter);
            m_testingOutput.Add("\nCopy Constructor:");
            string test1 = "Copied correctly --> ";
            if (copiedCorrectly) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }


        /// <summary>
        /// Calculate stats testing
        /// </summary>
        private void calculateStatsTest()
        {
            Character testCharacter = new Character();
            foreach (Attribute testAttribute in testCharacter.Attributes)
            {
                testAttribute.score = 5;
            }
            testCharacter.CalculateStats();
            bool statsAreCorrect = true;
            foreach (Attribute testAttribute in testCharacter.Attributes)
            {
                if (testAttribute.save != -3 || testAttribute.modifier != -3)
                {
                    statsAreCorrect = false;
                }
            }
            m_testingOutput.Add("\nCalculate Stats Function:");
            string test1 = "All stats are calculated correctly --> ";
            if (statsAreCorrect) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }

        /// <summary>
        /// Calculate stats testing
        /// </summary>
        private void calculateSkillsTest()
        {
            Character testCharacter = new Character();
            testCharacter.Level = 5;
            foreach (Attribute testAttribute in testCharacter.Attributes)
            {
                testAttribute.score = 5;
            }
            testCharacter.SetProficiency();
            foreach (Skill testSkill in testCharacter.Skills)
            {
                testSkill.isProficient = true;
            }
            testCharacter.CalculateSkills();
            bool skillsAreCorrect = true;
            foreach (Skill testSkill in testCharacter.Skills)
            {
                if (testSkill.score != 0)
                {
                    skillsAreCorrect = false;
                }
            }
            m_testingOutput.Add("\nCalculate Skills Function:");
            string test1 = "All skills are calculated correctly --> ";
            if (skillsAreCorrect) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }

        /// <summary>
        /// Set Proficiency Testing
        /// </summary>
        private void setProficiencyTest()
        {
            Character testCharacter = new Character();
            testCharacter.Level = 5;
            testCharacter.SetProficiency();
            bool proficiencyCorrect = true;
            if (testCharacter.ProficiencyBonus != 3)
            {
                proficiencyCorrect = false;
            }
            m_testingOutput.Add("\nSet Proficiency Function:");
            string test1 = "Proficiency bonus is set correctly --> ";
            if (proficiencyCorrect) test1 += "PASSED";
            else test1 += "FAILED";
            m_testingOutput.Add(test1);
        }
        #endregion Tests

        #endregion Functions
    }
}
