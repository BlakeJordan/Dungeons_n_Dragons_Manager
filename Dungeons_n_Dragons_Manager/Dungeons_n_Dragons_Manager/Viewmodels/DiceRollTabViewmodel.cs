﻿using Dungeons_n_Dragons_Manager.Models;
using DungeonsDungeons_n_Dragons_Manager.Tools;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// viewmodel for the roll dice tab
    /// </summary>
    internal class DiceRollTabViewmodel : INotifyPropertyChanged
    {
        /// <summary>
        /// instantiation of private facing bag object which gives access to DiceBag functions
        /// </summary>
        private DiceBag bag { get; set; }
        /// <summary>
        /// constructor for the roll tabs viewmodel
        /// @Pre: DiceBag object has been instantiated
        /// @Post: bag object is set to a new DiceBag
        /// </summary>
        public DiceRollTabViewmodel()
        {
            bag = new DiceBag();
        }
        /// <summary>
        /// private facing int which will hold the number of times the D4 should be rolled
        /// </summary>
        private int m_D4Input;
        /// <summary>
        /// public facing accessor for m_D4Input
        /// </summary>
        public int D4Input
        {
            get
            {
                return m_D4Input;
            }
            set
            {
                if (value != m_D4Input)
                {
                    m_D4Input = value;
                    OnPropertyRaised(nameof(D4Input));
                }
            }
        }
        /// <summary>
        /// private facing int which will hold the number of times the D6 should be rolled
        /// </summary>
        private int m_D6Input;
        /// <summary>
        /// public facing accessor for m_D6Input
        /// </summary>
        public int D6Input
        {
            get
            {
                return m_D6Input;
            }
            set
            {
                if (value != m_D6Input)
                {
                    m_D6Input = value;
                    OnPropertyRaised(nameof(D6Input));
                }
            }
        }
        /// <summary>
        /// private facing int which will hold the number of times the D8 should be rolled
        /// </summary>
        private int m_D8Input;
        /// <summary>
        /// public facing accessor for m_D8Input
        /// </summary>
        public int D8Input
        {
            get
            {
                return m_D8Input;
            }
            set
            {
                if (value != m_D8Input)
                {
                    m_D8Input = value;
                    OnPropertyRaised(nameof(D8Input));
                }
            }
        }
        /// <summary>
        /// private facing int which will hold the number of times the D10 should be rolled
        /// </summary>
        private int m_D10Input;

        public int D10Input
        {
            get
            {
                return m_D10Input;
            }
            set
            {
                if (value != m_D10Input)
                {
                    m_D10Input = value;
                    OnPropertyRaised(nameof(D10Input));
                }
            }
        }
        /// <summary>
        /// private facing int which will hold the number of times the D12 should be rolled
        /// </summary>
        private int m_D12Input;

        public int D12Input
        {
            get
            {
                return m_D12Input;
            }
            set
            {
                if (value != m_D12Input)
                {
                    m_D12Input = value;
                    OnPropertyRaised(nameof(D12Input));
                }
            }
        }
        /// <summary>
        /// private facing int which will hold the number of times the D20 should be rolled
        /// </summary>
        private int m_D20Input;

        public int D20Input
        {
            get
            {
                return m_D20Input;
            }
            set
            {
                if (value != m_D20Input)
                {
                    m_D20Input = value;
                    OnPropertyRaised(nameof(D20Input));
                }
            }
        }
        /// <summary>
        /// private facing int which will hold the number of times the D100 should be rolled
        /// </summary>
        private int m_D100Input;

        public int D100Input
        {
            get
            {
                return m_D100Input;
            }
            set
            {
                if (value != m_D100Input)
                {
                    m_D100Input = value;
                    OnPropertyRaised(nameof(D100Input));
                }
            }
        }

        private int[] rollTimes { get; set; }

        private string m_Rolls;

        public string rolls
        {
            get
            {
                if (m_Rolls == null)
                {
                    m_Rolls = "Your rolls will appear here.";
                }
                return m_Rolls;
            }
            set
            {
                if (value != m_Rolls)
                {
                    m_Rolls = value;
                    OnPropertyRaised(nameof(rolls));
                }
            }
        }

        private void roll_button_click()
        {
            rollTimes = new int[] { D4Input, D6Input, D8Input, D10Input, D12Input, D20Input, D100Input };
            string rollstemp = "rolls: \n";
            List<List<string>> temp = bag.RollMultiple(rollTimes);
            foreach (List<string> roll in temp)
            {
                rollstemp += "\n";
                foreach (string num in roll)
                {
                    rollstemp += num + " ";
                }
            }
            rolls = rollstemp;
        }

        #region Commands

        private bool m_canClick
        {
            get { return true; }
        }

        private ICommand m_Click;

        public ICommand Click
        {
            get
            {
                return m_Click ?? (m_Click = new CommandHandler(() => roll_button_click(), m_canClick));
            }
        }

        #endregion Commands

        #region Interfaces
        /// <summary>
        /// Public instance of PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Private function which updates the UI's binding value to the current value.
        /// @Pre: Private backing value has been changed.
        /// @Post: UI now reflects current value.
        /// </summary>
        /// <param name="propertyname">Name of property to update to UI.</param>
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion Interfaces
    }
}