using System;
using System.Collections.Generic;
using System.Reflection;

namespace Dungeons_n_Dragons_Manager.Models
{
    /// <summary>
    /// A model to hold monster data.
    /// </summary>
    public class Monster
    {
        #region Constructors

        /// <summary>
        /// Blank Constructor for create Monster.
        /// </summary>
        public Monster()
        {
            Name = string.Empty;
            HitPointsDice = string.Empty;
            ArmorClassType = string.Empty;
            StrengthMod = DexterityMod = ConstitutionMod = IntelligenceMod = WisdomMod = CharismaMod = -6;
            ArmorClass = ChallengeRating = -1;
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

            if (values[19] == "All") //All environments except Underwater
            {
                IsArctic = true;
                IsCoastal = true;
                IsDesert = true;
                IsForest = true;
                IsGrassland = true;
                IsHill = true;
                IsMountain = true;
                IsSwamp = true;
                IsUnderdark = true;
                IsUrban = true;
            }
            else
            {
                foreach (string environment in values[19].Split(','))
                {
                    if (environment == "Arctic") IsArctic = true;
                    else if (environment == "Coastal") IsCoastal = true;
                    else if (environment == "Desert") IsDesert = true;
                    else if (environment == "Forest") IsForest = true;
                    else if (environment == "Grassland") IsGrassland = true;
                    else if (environment == "Hill") IsHill = true;
                    else if (environment == "Mountain") IsMountain = true;
                    else if (environment == "Swamp") IsSwamp = true;
                    else if (environment == "Underdark") IsUnderdark = true;
                    else if (environment == "Underwater") IsUnderwater = true;
                    else if (environment == "Urban") IsUrban = true;
                }
            }

            if (values[20] == "True")
            {
                IsCustom = true;
            }
            else
            {
                IsCustom = false;
            }
        }

        /// <summary>
        /// Constructor that deep copies an already created monster.
        /// </summary>
        /// <param name="monsterToCopy">Monster to be copied.</param>
        public Monster(Monster monsterToCopy)
        {
            IsCustom = monsterToCopy.IsCustom;
            Name = monsterToCopy.Name;

            IsArctic = monsterToCopy.IsArctic;
            IsCoastal = monsterToCopy.IsCoastal;
            IsDesert = monsterToCopy.IsDesert;
            IsForest = monsterToCopy.IsForest;
            IsGrassland = monsterToCopy.IsGrassland;
            IsHill = monsterToCopy.IsHill;
            IsMountain = monsterToCopy.IsMountain;
            IsSwamp = monsterToCopy.IsSwamp;
            IsUnderdark = monsterToCopy.IsUnderdark;
            IsUnderwater = monsterToCopy.IsUnderwater;
            IsUrban = monsterToCopy.IsUrban;

            ChallengeRating = monsterToCopy.ChallengeRating;
            ChallengeXP = monsterToCopy.ChallengeXP;
            ArmorClassType = monsterToCopy.ArmorClassType;
            ArmorClass = monsterToCopy.ArmorClass;
            HitPoints = monsterToCopy.HitPoints;
            HitPointsDice = monsterToCopy.HitPointsDice;

            Strength = monsterToCopy.Strength;
            StrengthMod = monsterToCopy.StrengthMod;
            Dexterity = monsterToCopy.Dexterity;
            DexterityMod = monsterToCopy.DexterityMod;
            Constitution = monsterToCopy.Constitution;
            ConstitutionMod = monsterToCopy.ConstitutionMod;

            Intelligence = monsterToCopy.Intelligence;
            IntelligenceMod = monsterToCopy.IntelligenceMod;
            Wisdom = monsterToCopy.Wisdom;
            WisdomMod = monsterToCopy.WisdomMod;
            Charisma = monsterToCopy.Charisma;
            CharismaMod = monsterToCopy.CharismaMod;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Represents if the monster is user create.
        /// </summary>
        public bool IsCustom { get; set; }

        /// <summary>
        /// Represents the name of the monster.
        /// </summary>
        public string Name { get; set; }

        #region Environments

        /// <summary>
        /// List representing the monster's environments.
        /// </summary>
        public List<string> Environments
        {
            get
            {
                List<string> enviroments = new List<string>();
                if (IsArctic) enviroments.Add("Arctic");
                if (IsCoastal) enviroments.Add("Coastal");
                if (IsDesert) enviroments.Add("Desert");
                if (IsForest) enviroments.Add("Forest");
                if (IsGrassland) enviroments.Add("Grassland");
                if (IsHill) enviroments.Add("Hill");
                if (IsMountain) enviroments.Add("Mountain");
                if (IsSwamp) enviroments.Add("Swamp");
                if (IsUnderdark) enviroments.Add("Underdark");
                if (IsUnderwater) enviroments.Add("Underwater");
                if (IsUrban) enviroments.Add("Urban");
                return enviroments;
            }
        }

        /// <summary>
        /// Boolean for if the artic environment is checked.
        /// </summary>
        public bool IsArctic { get; set; }

        /// <summary>
        /// Boolean for if the coastal environment is checked.
        /// </summary>
        public bool IsCoastal { get; set; }

        /// <summary>
        /// Boolean for if the Desert environment is checked.
        /// </summary>
        public bool IsDesert { get; set; }

        /// <summary>
        /// Boolean for if the forest environment is checked.
        /// </summary>
        public bool IsForest { get; set; }

        /// <summary>
        /// Boolean for if the grassland environment is checked.
        /// </summary>
        public bool IsGrassland { get; set; }

        /// <summary>
        /// Boolean for if the hill environment is checked.
        /// </summary>
        public bool IsHill { get; set; }

        /// <summary>
        /// Boolean for if the mountain environment is checked.
        /// </summary>
        public bool IsMountain { get; set; }

        /// <summary>
        /// Boolean for if the swamp environment is checked.
        /// </summary>
        public bool IsSwamp { get; set; }

        /// <summary>
        /// Boolean for if the underdark environment is checked.
        /// </summary>
        public bool IsUnderdark { get; set; }

        /// <summary>
        /// Boolean for if the underwater environment is checked.
        /// </summary>
        public bool IsUnderwater { get; set; }

        /// <summary>
        /// Boolean for if the urban environment is checked.
        /// </summary>
        public bool IsUrban { get; set; }

        #endregion Environment Bools

        #region Stats

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

        #endregion

        #endregion Properties

        #region Functions

        /// <summary>
        /// Overrides the ToString function.
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            string sc = ";";
            string c = ",";
            string stringRep = Name + sc + ChallengeRating.ToString()
                        + sc + ChallengeXP.ToString()
                        + sc + ArmorClassType
                        + sc + ArmorClass.ToString()
                        + sc + Strength.ToString()
                        + sc + StrengthMod.ToString()
                        + sc + Dexterity.ToString()
                        + sc + DexterityMod.ToString()
                        + sc + Constitution.ToString()
                        + sc + ConstitutionMod.ToString()
                        + sc + Intelligence.ToString()
                        + sc + IntelligenceMod.ToString()
                        + sc + Wisdom.ToString()
                        + sc + WisdomMod.ToString()
                        + sc + Charisma.ToString()
                        + sc + CharismaMod.ToString()
                        + sc + HitPointsDice
                        + sc + HitPoints.ToString()
                        + sc;

            string environments = string.Empty;
            if (IsArctic) environments += "Arctic" + c;
            if (IsCoastal) environments += "Coastal" + c;
            if (IsDesert) environments += "Desert" + c;
            if (IsForest) environments += "Forest" + c;
            if (IsGrassland) environments += "Grassland" + c;
            if (IsHill) environments += "Hill" + c;
            if (IsMountain) environments += "Mountain" + c;
            if (IsSwamp) environments += "Swamp" + c;
            if (IsUnderdark) environments += "Underdark" + c;
            if (IsUnderwater) environments += "Underwater" + c;
            if (IsUrban) environments += "Urban" + c;
            if (!string.IsNullOrWhiteSpace(environments) && environments.EndsWith(","))
            {
                environments = environments.TrimEnd(',');
            }
            environments += sc;
            stringRep += environments;

            stringRep += IsCustom.ToString();

            return stringRep;
        }

        /// <summary>
        /// Implementation of equals function for the class.
        /// </summary>
        /// <param name="monster">Other monster.</param>
        /// <returns>True if equal, false if not.</returns>
        public bool Equals(Monster monster)
        {
            PropertyInfo[] properties = new Monster().GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Object value1 = new Monster().GetType().GetProperty(property.Name).GetValue(this);
                Object value2 = new Monster().GetType().GetProperty(property.Name).GetValue(monster);
                if (value1.ToString() != value2.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Functions
    }
}