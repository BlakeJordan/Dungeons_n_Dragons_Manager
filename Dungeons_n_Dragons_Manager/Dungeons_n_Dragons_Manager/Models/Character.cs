using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dungeons_n_Dragons_Manager.Models
{
    /// <summary>
    /// A model to hold character data.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Character()
        {
        }

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
        /// Represents the maximum hit points
        /// </summary>
        public int MaxHP { get; set; }

        /// <summary>
        /// Represents the current hit points
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// Represents experience points
        /// </summary>
        public int XP { get; set; }

        /// <summary>
        /// Represents armor class
        /// </summary>
        public int AC { get; set; }

        /// <summary>
        /// Represents the charisma stat
        /// </summary>
        public int Charisma { get; set; }

        /// <summary>
        /// Represents the charisma modifier
        /// </summary>
        public int CharismaMod { get; set; }

        /// <summary>
        /// Represents the strength stat
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// Represents the strength modifier
        /// </summary>
        public int StrengthMod { get; set; }

        /// <summary>
        /// Represents the wisdom stat
        /// </summary>
        public int Wisdom { get; set; }

        /// <summary>
        /// Represents the wisdom modifier
        /// </summary>
        public int WisdomMod { get; set; }

        /// <summary>
        /// Represents the dexterity stat
        /// </summary>
        public int Dexterity { get; set; }

        /// <summary>
        /// Represents the dexterity modifier
        /// </summary>
        public int DexterityMod { get; set; }

        /// <summary>
        /// Represents the constitution stat
        /// </summary>
        public int Constitution { get; set; }

        /// <summary>
        /// Represents constitution modifier
        /// </summary>
        public int ConstitutionMod { get; set; }

        /// <summary>
        /// Represents the intelligence stat
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        /// Represents the intelligence modifier
        /// </summary>
        public int IntelligenceMod { get; set; }

        /// <summary>
        /// Represents the specific notes for a character
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Represents the character's athletics proficiency
        /// </summary>
        public bool Athletics { get; set; }

        /// <summary>
        /// Represents the character's Acrobatics proficiency
        /// </summary>
        public bool Acrobatics { get; set; }

        /// <summary>
        /// Represents the character's SleightOfHand proficiency
        /// </summary>
        public bool SleightOfHand { get; set; }

        /// <summary>
        /// Represents the character's Stealth proficiency
        /// </summary>
        public bool Stealth { get; set; }

        /// <summary>
        /// Represents the character's AnimalHandling proficiency
        /// </summary>
        public bool AnimalHandling { get; set; }

        /// <summary>
        /// Represents the character's Insight proficiency
        /// </summary>
        public bool Insight { get; set; }

        /// <summary>
        /// Represents the character's Medicine proficiency
        /// </summary>
        public bool Medicine { get; set; }

        /// <summary>
        /// Represents the character's Perception proficiency
        /// </summary>
        public bool Perception { get; set; }

        /// <summary>
        /// Represents the character's Survival proficiency
        /// </summary>
        public bool Survival { get; set; }

        /// <summary>
        /// Represents the character's Arcana proficiency
        /// </summary>
        public bool Arcana { get; set; }

        /// <summary>
        /// Represents the character's History proficiency
        /// </summary>
        public bool History { get; set; }

        /// <summary>
        /// Represents the character's Investigation proficiency
        /// </summary>
        public bool Investigation { get; set; }

        /// <summary>
        /// Represents the character's Nature proficiency
        /// </summary>
        public bool Nature { get; set; }

        /// <summary>
        /// Represents the character's Religion proficiency
        /// </summary>
        public bool Religion { get; set; }

        /// <summary>
        /// Represents the character's Deception proficiency
        /// </summary>
        public bool Deception { get; set; }

        /// <summary>
        /// Represents the character's Intimidation proficiency
        /// </summary>
        public bool Intimidation { get; set; }

        /// <summary>
        /// Represents the character's Performance proficiency
        /// </summary>
        public bool Performance { get; set; }

        /// <summary>
        /// Represents the character's Persuasion proficiency
        /// </summary>
        public bool Persuasion { get; set; }

        /// <summary>
        /// Represents the character's class-specific specialization
        /// </summary>
        public string Specialization { get; set; }

        /// <summary>
        /// Represents the character's weapons
        /// </summary>
        public List<string> Weapons { get; set; }

        /// <summary>
        /// Represents the character's abilities and spells
        /// </summary>
        public List<string> Abilities { get; set; }
    }
}