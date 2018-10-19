using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_n_Dragons_Manager.Models
{
    class Character
    {
        public Character()
        {

        }
        public string Name { get; set; }
        public string ArmorType { get; set; }
        public int Level { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int XP { get; set; }
        public int AC { get; set; }
        public int Charisma { get; set; }
        public int CharismaMod { get; set; }
        public int Strength { get; set; }
        public int StrengthMod { get; set; }
        public int Wisdom { get; set; }
        public int WisdomMod { get; set; }
        public int Dexterity { get; set; }
        public int DexterityMod { get; set; }
        public int Constitution { get; set; }
        public int ConstitutionMod { get; set; }
        public int Intelligence { get; set; }
        public int IntelligenceMod { get; set; }
    }
}
