using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_n_Dragons_Manager.Models
{
    class Monster
    {
        public Monster(string[] values)
        {
            Name = values[0];

            ChallengeRating = Int32.Parse(values[1]);
            ChallengeXP = Int32.Parse(values[2]);

            if (string.IsNullOrEmpty(values[3]))
            {
                ArmorClassType = "None";
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
        }

        #region Properties

        public string Name { get; set; }

        public int ChallengeRating { get; set; }
        public int ChallengeXP { get; set; }

        public string ArmorClassType { get; set; }
        public int ArmorClass { get; set; }

        public int HitPoints { get; set; }
        public string HitPointsDice { get; set; }

        public int Strength { get; set; }
        public int StrengthMod { get; set; }

        public int Dexterity { get; set; }
        public int DexterityMod { get; set; }

        public int Constitution { get; set; }
        public int ConstitutionMod { get; set; }

        public int Intelligence { get; set; }
        public int IntelligenceMod { get; set; }

        public int Wisdom { get; set; }
        public int WisdomMod { get; set; }

        public int Charisma { get; set; }
        public int CharismaMod { get; set; }

        #endregion
    }
}
