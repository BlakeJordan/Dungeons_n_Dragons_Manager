using System;
using System.Collections.Generic;
using System.Linq;

namespace Dungeons_n_Dragons_Manager.Models
{
    /// <summary>
    /// A model to hold monster data.
    /// </summary>
    public class Monster
    {
        /// <summary>
        /// Blank Constructor for create Monster.
        /// </summary>
        
        public Monster()
        {
        }

        /// <summary>
        /// Constructor which takes in an array of strings representing the values of attributes.
        /// </summary>
        /// <param name="values">Array of strings representing the values to be assigned.</param>
        public Monster(string[] values)
        {
            Name = values[0];

            ChallengeRating = Int32.Parse(values[1]);
            ChallengeXP = Int32.Parse(values[2]);

            if (string.IsNullOrEmpty(values[3]))
            {
                ArmorClassType = "none";
            }
            else
            {
                ArmorClassType = values[3];
            }
            ArmorClass = Int32.Parse(values[4]);

            Strength = Int32.Parse(values[5]);
            StrengthMod = Int32.Parse(values[6]);

            Dexterity = Int32.Parse(values[7]);
            DexterityMod = Int32.Parse(values[8]);

            Constitution = Int32.Parse(values[9]);
            ConstitutionMod = Int32.Parse(values[10]);

            Intelligence = Int32.Parse(values[11]);
            IntelligenceMod = Int32.Parse(values[12]);

            Wisdom = Int32.Parse(values[13]);
            WisdomMod = Int32.Parse(values[14]);

            Charisma = Int32.Parse(values[15]);
            CharismaMod = Int32.Parse(values[16]);

            HitPointsDice = values[17];
            HitPoints = Int32.Parse(values[18]);

            Environments = new List<string>();
            if(values[19] == "All") //All environments except Underwater
            {
                Environments.Add("Arctic");
                Environments.Add("Coastal");
                Environments.Add("Desert");
                Environments.Add("Forest");
                Environments.Add("Grassland");
                Environments.Add("Hill");
                Environments.Add("Mountain");
                Environments.Add("Swamp");
                Environments.Add("Underdark");
                Environments.Add("Urban");
            }
            else
            {
                Environments = values[19].Split(',').OfType<string>().ToList(); //Parse string of enviroments
            }
        }

        #region Properties

        /// <summary>
        /// Represents the enviroments of the monster.
        /// </summary>
        public List<string> Environments { get; set; }

        /// <summary>
        /// Represents the name of the monster.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the challenge rating.
        /// </summary>
        public int ChallengeRating { get; set; }

        /// <summary>
        /// Represents the challenge XP.
        /// </summary>
        public int ChallengeXP { get; set; }

        /// <summary>
        /// Represents the the armor class type.
        /// </summary>
        public string ArmorClassType { get; set; }

        /// <summary>
        /// Represents the armor class.
        /// </summary>
        public int ArmorClass { get; set; }

        /// <summary>
        /// Represents the hit points.
        /// </summary>
        public int HitPoints { get; set; }

        /// <summary>
        /// Represents the hit points dice.
        /// </summary>
        public string HitPointsDice { get; set; }

        /// <summary>
        /// Represents the strength rating.
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// Represents the strength modifier.
        /// </summary>
        public int StrengthMod { get; set; }

        /// <summary>
        /// Represents the dexterity rating.
        /// </summary>
        public int Dexterity { get; set; }

        /// <summary>
        /// Represents the dexterity modifier.
        /// </summary>
        public int DexterityMod { get; set; }

        /// <summary>
        /// Represents the constitution rating.
        /// </summary>
        public int Constitution { get; set; }

        /// <summary>
        /// Represents the constitution modifier.
        /// </summary>
        public int ConstitutionMod { get; set; }

        /// <summary>
        /// Represents the intelligence rating.
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        /// Represents the intelligence modifier.
        /// </summary>
        public int IntelligenceMod { get; set; }

        /// <summary>
        /// Represents the widsom rating.
        /// </summary>
        public int Wisdom { get; set; }

        /// <summary>
        /// Represents the widsom modifier.
        /// </summary>
        public int WisdomMod { get; set; }

        /// <summary>
        /// Represents the charisma rating.
        /// </summary>
        public int Charisma { get; set; }

        /// <summary>
        /// Represents the charisma modifier.
        /// </summary>
        public int CharismaMod { get; set; }

        #endregion Properties
    }
}