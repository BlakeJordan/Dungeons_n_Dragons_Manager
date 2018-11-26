﻿using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// The viewmodel for creating monsters
    /// </summary>
    public class CreateMonsterWindowViewmodel : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor for the create monster viewmodel
        ///
        /// Pre: Create monster window has been opened
        ///
        /// Post: A new monster is created with a reference to an existing, blank monster
        /// </summary>
        public CreateMonsterWindowViewmodel()
        {
            populateDropdowns();
        }

        #region Properties

        /// <summary>
        /// Public accessor for m_canSave.
        /// </summary>
        public bool CanSave
        {
            get
            {
                //Duplicate name logic.
                bool hasDuplicateName = false;
                foreach (Monster monster in m_customMonsters)
                {
                    if (monster.Name == EditableMonster.Name) hasDuplicateName = true;
                }

                //Atleast one environment logic.
                bool hasAtleastOneEnvironment = EditableMonster.IsArctic || EditableMonster.IsCoastal || EditableMonster.IsDesert || EditableMonster.IsForest ||
                                                EditableMonster.IsGrassland || EditableMonster.IsHill || EditableMonster.IsMountain || EditableMonster.IsSwamp ||
                                                EditableMonster.IsUnderdark || EditableMonster.IsUnderwater || EditableMonster.IsUrban;

                //Modifers picked logic.
                bool modifersNotPicked = EditableMonster.StrengthMod == -6 || EditableMonster.DexterityMod == -6 || EditableMonster.ConstitutionMod == -6 ||
                                          EditableMonster.IntelligenceMod == -6 || EditableMonster.WisdomMod == -6 || EditableMonster.CharismaMod == -6;

                bool statsNotPicked = EditableMonster.Strength == 0 || EditableMonster.Dexterity == 0 || EditableMonster.Constitution == 0 ||
                                      EditableMonster.Intelligence == 0 || EditableMonster.Wisdom == 0 || EditableMonster.Charisma == 0;

                bool challengeXpOrHPnotPicked = EditableMonster.ChallengeXP == 0 || EditableMonster.HitPoints == 0;

                bool hitPointsDiceNotPicked = string.IsNullOrWhiteSpace(EditableMonster.HitPointsDice);

                bool armorClassTypeNotPicked = string.IsNullOrWhiteSpace(EditableMonster.ArmorClassType);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Blank & duplicate name check.
                if (string.IsNullOrWhiteSpace(EditableMonster.Name) || hasDuplicateName)
                {
                    return false;
                }

                //Atleast one environment picked check.
                else if (!hasAtleastOneEnvironment)
                {
                    return false;
                }

                //ArmorClassType, modifers, and stats picked check.
                else if (modifersNotPicked || statsNotPicked || challengeXpOrHPnotPicked)
                {
                    return false;
                }
                else if (hitPointsDiceNotPicked || armorClassTypeNotPicked)
                {
                    return false;
                }

                //All checks pass.
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Monster that is bound to the UI.
        /// </summary>
        private Monster m_editableMonster;

        /// <summary>
        /// Public accessor for m_editableMonster.
        /// </summary>
        public Monster EditableMonster
        {
            get
            {
                if (m_editableMonster == null)
                {
                    m_editableMonster = new Monster();
                    m_editableMonster.IsCustom = true;
                }
                return m_editableMonster;
            }
            set
            {
                if (m_editableMonster != value)
                {
                    m_editableMonster = value;
                    OnPropertyRaised(nameof(EditableMonster));
                }
            }
        }

        /// <summary>
        /// A list of the currently saved monsters for reference.
        /// </summary>
        public List<Monster> m_customMonsters;

        /// <summary>
        /// Buffer binding for Monster.HitPoints.
        /// </summary>
        private string m_hitPointsString;

        /// <summary>
        /// Public accessor for m_hitPointsString.
        /// </summary>
        public string HitPointsString
        {
            get { return m_hitPointsString; }
            set
            {
                if (m_hitPointsString != value)
                {
                    m_hitPointsString = value;
                    OnPropertyRaised(nameof(HitPointsString));
                    if (!string.IsNullOrWhiteSpace(m_hitPointsString))
                    {
                        EditableMonster.HitPoints = Int32.Parse(m_hitPointsString);
                    }
                    else EditableMonster.HitPoints = 0;
                }
            }
        }

        /// <summary>
        /// Buffer binding for Monster.ChallengeXP.
        /// </summary>
        private string m_challengeXpString;

        /// <summary>
        /// Public accessor for m_challengeXpString.
        /// </summary>
        public string ChallengeXpString
        {
            get { return m_challengeXpString; }
            set
            {
                if (m_challengeXpString != value)
                {
                    m_challengeXpString = value;
                    OnPropertyRaised(nameof(ChallengeXpString));
                    if (!string.IsNullOrWhiteSpace(m_challengeXpString))
                    {
                        EditableMonster.ChallengeXP = Int32.Parse(m_challengeXpString);
                    }
                    else EditableMonster.ChallengeXP = 0;
                }
            }
        }

        #region ComboBox Sources

        /// <summary>
        /// The monster's options for armor
        /// </summary>
        public List<string> ArmorTypes { get; set; }

        /// <summary>
        /// The monsters's options for each skill's level
        /// </summary>
        public List<int> SkillValues { get; set; }

        /// <summary>
        /// The monsters's options for each Modifier
        /// </summary>
        public List<int> ModifierValues { get; set; }

        /// <summary>
        /// The monster's options for armor class.
        /// </summary>
        public List<int> ArmorClassValues { get; set; }

        /// <summary>
        /// The monster's options for challenge rating.
        /// </summary>
        public List<int> ChallengeRatingValues { get; set; }

        #endregion ComboBox Sources

        #endregion Properties

        #region Commands

        /// <summary>
        /// Command binded to Save button.
        /// </summary>
        private ICommand m_saveMonster;

        /// <summary>
        /// Public facing accessor to m_saveMonster.
        /// </summary>
        public ICommand SaveMonster
        {
            get
            {
                return m_saveMonster ?? (m_saveMonster = new CommandHandler(() => saveMonster(), true));
            }
        }

        /// <summary>
        /// Command binded to all ui components that executes when a selection is changed.
        /// </summary>
        private ICommand m_checkCanSave;

        /// <summary>
        /// Public facing accessor to m_checkCanSave.
        /// </summary>
        public ICommand CheckCanSave
        {
            get
            {
                return m_checkCanSave ?? (m_checkCanSave = new CommandHandler(() => checkCanSave(), true));
            }
        }

        #endregion Commands

        #region Functions

        /// <summary>
        /// Saves the monster to the settings.
        /// </summary>
        private void saveMonster()
        {
            if (Properties.Settings.Default.CustomMonstersList == null) Properties.Settings.Default.CustomMonstersList = new List<Monster>();
            Properties.Settings.Default.CustomMonstersList.Add(EditableMonster);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Reevaluates the CanSave binding.
        ///
        /// Pre: none
        ///
        /// Post: CanSave has been reevaluated.
        /// </summary>
        private void checkCanSave()
        {
            OnPropertyRaised(nameof(CanSave));
        }

        /// <summary>
        /// Populates the dropdown menus for the armor type options
        ///
        /// Pre: None
        ///
        /// Post: The dropdown menus contain selectable armor type
        /// </summary>
        private void populateDropdowns()
        {
            ArmorTypes = Properties.Resources.ArmorTypes.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            SkillValues = Enumerable.Range(1, 30).ToList();
            ModifierValues = Enumerable.Range(-5, 16).ToList();
            ArmorClassValues = Enumerable.Range(0, 32).ToList();
            ChallengeRatingValues = Enumerable.Range(0, 31).ToList();

            #region Custom Monsters

            m_customMonsters = new List<Monster>();

            //Generate list of custom monster by parsing settings
            if (Properties.Settings.Default.CustomMonstersList != null)
            {
                m_customMonsters = Properties.Settings.Default.CustomMonstersList;
            }
            else
            {
                m_customMonsters = new List<Monster>();
            }

            #endregion Custom Monsters
        }

        #endregion Functions

        #region Interfaces

        /// <summary>
        /// Public instance of PropertyChanged event.
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Private function which updates the UI's binding value to the current value.
        ///
        /// Pre: Private backing value has been changed.
        ///
        /// Post: UI now reflects current value.
        /// </summary>
        /// <param name="propertyname">Name of property to update to UI.</param>
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion Interfaces
    }
}