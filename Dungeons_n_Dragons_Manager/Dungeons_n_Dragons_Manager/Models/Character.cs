using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dungeons_n_Dragons_Manager.Models
{
    /// <summary>
    /// A model to hold character data.
    /// </summary>
    public class Character
    {
        #region Properties

        /// <summary>
        /// A collection of the charcter's attributes
        /// </summary>
        public ObservableCollection<Attribute> Attributes { get; set; }

        /// <summary>
        /// A collection of the character's skills
        /// </summary>
        public ObservableCollection<Skill> Skills { get; set; }

        /// <summary>
        /// Represents the character's Strength attribute
        /// </summary>
        public Attribute Strength { get; set; }

        /// <summary>
        /// Represents the character's Constitution attribute
        /// </summary>
        public Attribute Constitution { get; set; }

        /// <summary>
        /// Represents the character's Dexterity attribute
        /// </summary>
        public Attribute Dexterity { get; set; }

        /// <summary>
        /// Represents the character's Intelligence attribute
        /// </summary>
        public Attribute Intelligence { get; set; }

        /// <summary>
        /// Represents the character's Wisdom attribute
        /// </summary>
        public Attribute Wisdom { get; set; }

        /// <summary>
        /// Represents the character's Charisma attribute
        /// </summary>
        public Attribute Charisma { get; set; }

        /// <summary>
        /// Represents the character's athletics proficiency
        /// </summary>
        public Skill Athletics { get; set; }

        /// <summary>
        /// Represents the character's Acrobatics proficiency
        /// </summary>
        public Skill Acrobatics { get; set; }

        /// <summary>
        /// Represents the character's SleightOfHand proficiency
        /// </summary>
        public Skill SleightOfHand { get; set; }

        /// <summary>
        /// Represents the character's Stealth proficiency
        /// </summary>
        public Skill Stealth { get; set; }

        /// <summary>
        /// Represents the character's AnimalHandling proficiency
        /// </summary>
        public Skill AnimalHandling { get; set; }

        /// <summary>
        /// Represents the character's Insight proficiency
        /// </summary>
        public Skill Insight { get; set; }

        /// <summary>
        /// Represents the character's Medicine proficiency
        /// </summary>
        public Skill Medicine { get; set; }

        /// <summary>
        /// Represents the character's Perception proficiency
        /// </summary>
        public Skill Perception { get; set; }

        /// <summary>
        /// Represents the character's Survival proficiency
        /// </summary>
        public Skill Survival { get; set; }

        /// <summary>
        /// Represents the character's Arcana proficiency
        /// </summary>
        public Skill Arcana { get; set; }

        /// <summary>
        /// Represents the character's History proficiency
        /// </summary>
        public Skill History { get; set; }

        /// <summary>
        /// Represents the character's Investigation proficiency
        /// </summary>
        public Skill Investigation { get; set; }

        /// <summary>
        /// Represents the character's Nature proficiency
        /// </summary>
        public Skill Nature { get; set; }

        /// <summary>
        /// Represents the character's Religion proficiency
        /// </summary>
        public Skill Religion { get; set; }

        /// <summary>
        /// Represents the character's Deception proficiency
        /// </summary>
        public Skill Deception { get; set; }

        /// <summary>
        /// Represents the character's Intimidation proficiency
        /// </summary>
        public Skill Intimidation { get; set; }

        /// <summary>
        /// Represents the character's Performance proficiency
        /// </summary>
        public Skill Performance { get; set; }

        /// <summary>
        /// Represents the character's Persuasion proficiency
        /// </summary>
        public Skill Persuasion { get; set; }

        /// <summary>
        /// The character's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The character's race
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        /// The character's class
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Represents the armor type
        /// </summary>
        public string ArmorType { get; set; }

        /// <summary>
        /// Represents the current level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Represents the current hit points
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// Represents armor class
        /// </summary>
        public int AC { get; set; }

        /// <summary>
        /// Represents the specific notes for a character
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The added bonus a character gets on skill-related rolls
        /// </summary>
        public int ProficiencyBonus { get; set; }

        #endregion Properties

        /// <summary>
        /// Constructs a new, blank character
        /// </summary>
        public Character()
        {
            //Initalize AC to -1 so it is not auto populated in create character window.
            //AC = -1;

            Attributes = new ObservableCollection<Attribute>();
            Strength = new Attribute();
            Constitution = new Attribute();
            Dexterity = new Attribute();
            Intelligence = new Attribute();
            Wisdom = new Attribute();
            Charisma = new Attribute();
            Attributes.Add(Charisma);
            Attributes.Add(Wisdom);
            Attributes.Add(Strength);
            Attributes.Add(Dexterity);
            Attributes.Add(Constitution);
            Attributes.Add(Intelligence);

            Skills = new ObservableCollection<Skill>();
            Athletics = new Skill("Strength");
            Acrobatics = new Skill("Dexterity");
            AnimalHandling = new Skill("Dexterity");
            SleightOfHand = new Skill("Dexterity");
            Stealth = new Skill("Dexterity");
            Persuasion = new Skill("Charisma");
            Intimidation = new Skill("Charisma");
            Performance = new Skill("Charisma");
            Deception = new Skill("Charisma");
            Insight = new Skill("Wisdom");
            Medicine = new Skill("Wisdom");
            Survival = new Skill("Wisdom");
            Perception = new Skill("Wisdom");
            History = new Skill("Intelligence");
            Arcana = new Skill("Intelligence");
            Investigation = new Skill("Intelligence");
            Nature = new Skill("Intelligence");
            Religion = new Skill("Intelligence");
            Skills.Add(Athletics);
            Skills.Add(Acrobatics);
            Skills.Add(AnimalHandling);
            Skills.Add(SleightOfHand);
            Skills.Add(Insight);
            Skills.Add(History);
            Skills.Add(Arcana);
            Skills.Add(Persuasion);
            Skills.Add(Intimidation);
            Skills.Add(Stealth);
            Skills.Add(Deception);
            Skills.Add(Medicine);
            Skills.Add(Survival);
            Skills.Add(Investigation);
            Skills.Add(Nature);
            Skills.Add(Religion);
            Skills.Add(Performance);
            Skills.Add(Perception);
        }

        /// <summary>
        /// Copy constructor for characters
        /// </summary>
        /// <param name="copyCharacter">Character to be copied</param>
        public Character(Character copyCharacter)
        {
            Name = copyCharacter.Name;
            Level = copyCharacter.Level;
            Class = copyCharacter.Class;
            Race = copyCharacter.Race;
            HP = copyCharacter.HP;
            ArmorType = copyCharacter.ArmorType;
            AC = copyCharacter.AC;
            ProficiencyBonus = copyCharacter.ProficiencyBonus;
            Notes = copyCharacter.Notes;

            Attributes = new ObservableCollection<Attribute>();
            Strength = new Attribute(copyCharacter.Strength);
            Constitution = new Attribute(copyCharacter.Constitution);
            Dexterity = new Attribute(copyCharacter.Dexterity);
            Intelligence = new Attribute(copyCharacter.Intelligence);
            Wisdom = new Attribute(copyCharacter.Wisdom);
            Charisma = new Attribute(copyCharacter.Charisma);
            Attributes.Add(Charisma);
            Attributes.Add(Wisdom);
            Attributes.Add(Strength);
            Attributes.Add(Dexterity);
            Attributes.Add(Constitution);
            Attributes.Add(Intelligence);

            Skills = new ObservableCollection<Skill>();
            Athletics = new Skill(copyCharacter.Athletics);
            Acrobatics = new Skill(copyCharacter.Acrobatics);
            AnimalHandling = new Skill(copyCharacter.AnimalHandling);
            SleightOfHand = new Skill(copyCharacter.SleightOfHand);
            Stealth = new Skill(copyCharacter.Stealth);
            Persuasion = new Skill(copyCharacter.Persuasion);
            Intimidation = new Skill(copyCharacter.Intimidation);
            Performance = new Skill(copyCharacter.Performance);
            Deception = new Skill(copyCharacter.Deception);
            Insight = new Skill(copyCharacter.Insight);
            Medicine = new Skill(copyCharacter.Medicine);
            Survival = new Skill(copyCharacter.Survival);
            Perception = new Skill(copyCharacter.Perception);
            History = new Skill(copyCharacter.History);
            Arcana = new Skill(copyCharacter.Arcana);
            Investigation = new Skill(copyCharacter.Investigation);
            Nature = new Skill(copyCharacter.Nature);
            Religion = new Skill(copyCharacter.Religion);
            Skills.Add(Athletics);
            Skills.Add(Acrobatics);
            Skills.Add(AnimalHandling);
            Skills.Add(SleightOfHand);
            Skills.Add(Insight);
            Skills.Add(History);
            Skills.Add(Arcana);
            Skills.Add(Persuasion);
            Skills.Add(Intimidation);
            Skills.Add(Stealth);
            Skills.Add(Deception);
            Skills.Add(Medicine);
            Skills.Add(Survival);
            Skills.Add(Investigation);
            Skills.Add(Nature);
            Skills.Add(Religion);
            Skills.Add(Performance);
            Skills.Add(Perception);
        }

        /// <summary>
        /// Calculates the modifier and save bonuses for each attribute based on the attribute score
        /// </summary>
        public void CalculateStats()
        {
            foreach (Attribute stat in Attributes)
            {
                if (stat.score < 2)
                {
                    stat.modifier = -5;
                    stat.save = -5;
                }
                else if (stat.score < 4)
                {
                    stat.modifier = -4;
                    stat.save = -4;
                }
                else if (stat.score < 6)
                {
                    stat.modifier = -3;
                    stat.save = -3;
                }
                else if (stat.score < 8)
                {
                    stat.modifier = -2;
                    stat.save = -2;
                }
                else if (stat.score < 10)
                {
                    stat.modifier = -1;
                    stat.save = -1;
                }
                else if (stat.score < 12)
                {
                    stat.modifier = 0;
                    stat.save = 0;
                }
                else if (stat.score < 14)
                {
                    stat.modifier = 1;
                    stat.save = 1;
                }
                else if (stat.score < 16)
                {
                    stat.modifier = 2;
                    stat.save = 2;
                }
                else if (stat.score < 18)
                {
                    stat.modifier = 3;
                    stat.save = 3;
                }
                else if (stat.score < 20)
                {
                    stat.modifier = 4;
                    stat.save = 4;
                }
                else if (stat.score >= 20)
                {
                    stat.modifier = 5;
                    stat.save = 5;
                }
            }
        }

        /// <summary>
        /// Sets the proficiency bonus for the character based on the character's level
        /// </summary>
        public void SetProficiency()
        {
            double bonus = Level / 4;
            ProficiencyBonus = Convert.ToInt32((Math.Ceiling(bonus) + 1));
        }

        /// <summary>
        /// Calculates the skill bonuses for the character based on proficiency bonuses and attribute modifiers
        /// </summary>
        public void CalculateSkills()
        {
            foreach (Skill stat in Skills)
            {
                if (stat.isProficient)
                {
                    stat.score += ProficiencyBonus;
                }
                if (stat.skillAttribute == "Strength")
                {
                    stat.skillMod = Strength.modifier;
                }
                else if (stat.skillAttribute == "Dexterity")
                {
                    stat.skillMod = Dexterity.modifier;
                }
                else if (stat.skillAttribute == "Intelligence")
                {
                    stat.skillMod = Intelligence.modifier;
                }
                else if (stat.skillAttribute == "Charisma")
                {
                    stat.skillMod = Charisma.modifier;
                }
                else if (stat.skillAttribute == "Wisdom")
                {
                    stat.skillMod = Wisdom.modifier;
                }
                stat.score += stat.skillMod;
            }
        }

        /// <summary>
        /// Holds all the stats for a certain character attribute
        /// </summary>
        public class Attribute
        {
            /// <summary>
            /// Represents the score for a certain attribute, which modifies the save and modifier scores for that attribute
            /// </summary>
            public int score { get; set; }

            /// <summary>
            /// The chance a character can use this skill to escape danger
            /// </summary>
            public int save { get; set; }

            /// <summary>
            /// The chance a character will succeed in performing tasks related to the attribute
            /// </summary>
            public int modifier { get; set; }

            /// <summary>
            /// Copy Constructor for the Attribute Class
            /// </summary>
            /// <param name="CopyAttribute"></param>
            public Attribute(Attribute CopyAttribute)
            {
                score = CopyAttribute.score;
                save = CopyAttribute.save;
                modifier = CopyAttribute.modifier;
            }

            /// <summary>
            /// Default constructor.
            /// </summary>
            public Attribute() { }
        }

        /// <summary>
        /// Holds the details for a certain skill the character has
        /// </summary>
        public class Skill
        {
            /// <summary>
            /// Indicates whether or not the character is proficient with this skill
            /// </summary>
            public bool isProficient { get; set; }

            /// <summary>
            /// Represents the modifier for the skill
            /// </summary>
            public int skillMod { get; set; }

            /// <summary>
            /// Represents the attribute this skill pertains to
            /// </summary>
            public string skillAttribute { get; set; }

            /// <summary>
            /// The total score for the skill
            /// </summary>
            public int score { get; set; }

            /// <summary>
            /// Constructor for the skill class
            /// </summary>
            /// <param name="attribute"></param>
            public Skill(string attribute)
            {
                skillAttribute = attribute;
            }

            /// <summary>
            /// Copy Constructor for the skill class
            /// </summary>
            /// <param name="CopySkill">The skill to be copied</param>
            public Skill(Skill CopySkill)
            {
                isProficient = CopySkill.isProficient;
                skillMod = CopySkill.skillMod;
                skillAttribute = CopySkill.skillAttribute;
                score = CopySkill.score;
            }

            /// <summary>
            /// Default constructor.
            /// </summary>
            public Skill() { }
        }
    }
}