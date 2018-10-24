using System.Collections.Generic;

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
        /// Represents the character's proficiencies
        /// </summary>
        public List<string> Proficiencies { get; set; }

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