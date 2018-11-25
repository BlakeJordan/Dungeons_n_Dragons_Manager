using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Tools;
using System.ComponentModel;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Viewmodels
{
    /// <summary>
    /// viewmodel for the roll dice tab
    /// </summary>
    public class DiceRollTabViewmodel : INotifyPropertyChanged
    {
        /// <summary>
        /// instantiation of private facing bag object which gives access to DiceBag functions
        /// </summary>
        private DiceBag bag { get; set; }

        /// <summary>
        /// constructor for the roll tabs viewmodel
        ///
        /// Pre: DiceBag object has been instantiated
        ///
        /// Post: bag object is set to a new DiceBag
        /// </summary>
        public DiceRollTabViewmodel()
        {
            bag = new DiceBag();
        }

        /// <summary>
        /// private facing string which will hold all of the rolls in one long string
        /// </summary>
        private string m_Rolls;

        /// <summary>
        /// public accessor for m_Rolls
        /// </summary>
        public string rolls
        {
            get
            {
                if (m_Rolls == null)
                {
                    m_Rolls = "";
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

        /// <summary>
        /// calls the d4 roll function and appends the result to the rolls string
        ///
        /// Pre: D4 button has been clicked
        ///
        /// Post: rolls string is appended with d4 roll
        /// </summary>
        private void roll_D4()
        {
            rolls = rolls + " " + bag.Roll(4);
        }
        /// <summary>
        /// calls the d6 roll function and appends the result to the rolls string
        ///
        /// Pre: D6 button has been clicked
        ///
        /// Post: rolls string is appended with d6 roll
        /// </summary>
        private void roll_D6()
        {
            rolls = rolls + " " + bag.Roll(6);
        }
        /// <summary>
        /// calls the d8 roll function and appends the result to the rolls string
        ///
        /// Pre: D8 button has been clicked
        ///
        /// Post: rolls string is appended with d8 roll
        /// </summary>
        private void roll_D8()
        {
            rolls = rolls + " " + bag.Roll(8);
        }
        /// <summary>
        /// calls the d10 roll function and appends the result to the rolls string
        ///
        /// Pre: D10 button has been clicked
        ///
        /// Post: rolls string is appended with d10 roll
        /// </summary>
        private void roll_D10()
        {
            rolls = rolls + " " + bag.Roll(10);
        }
        /// <summary>
        /// calls the d12 roll function and appends the result to the rolls string
        ///
        /// Pre: D12 button has been clicked
        ///
        /// Post: rolls string is appended with d12 roll
        /// </summary>
        private void roll_D12()
        {
            rolls = rolls + " " + bag.Roll(12);
        }
        /// <summary>
        /// calls the d20 roll function and appends the result to the rolls string
        ///
        /// Pre: D20 button has been clicked
        ///
        /// Post: rolls string is appended with d20 roll
        /// </summary>
        private void roll_D20()
        {
            rolls = rolls + " " + bag.Roll(20);
        }
        /// <summary>
        /// calls the d100 roll function and appends the result to the rolls string
        ///
        /// Pre: D100 button has been clicked
        ///
        /// Post: rolls string is appended with d100 roll
        /// </summary>
        private void roll_D100()
        {
            rolls = rolls + " " + bag.Roll(100);
        }
        /// <summary>
        /// clears the rolls string by setting it to null
        ///
        /// Pre: clear rolls button has been clicked
        ///
        /// Post: rolls string is set to null
        /// </summary>
        private void clear_Rolls()
        {
            rolls = "";
        }

        #region Commands

        /// <summary>
        /// boolean which determines if the dice can be rolled. Conditions should be added in the future.
        /// </summary>
        private bool m_canClick
        {
            get { return true; }
        }

        /// <summary>
        /// private facing command handler for clear button
        /// </summary>
        private ICommand m_Clear;

        /// <summary>
        /// public facing accessor for clear button
        /// </summary>
        public ICommand Clear
        {
            get
            {
                return m_Clear ?? (m_Clear = new CommandHandler(() => clear_Rolls(), m_canClick));
            }
        }

        /// <summary>
        /// commnd binded to D4 button which calls roll_D4 if canClick is true
        /// </summary>
        private ICommand m_ClickD4;

        /// <summary>
        /// public facing accessor for m_Clickd4
        /// </summary>
        public ICommand ClickD4
        {
            get
            {
                return m_ClickD4 ?? (m_ClickD4 = new CommandHandler(() => roll_D4(), m_canClick));
            }
        }

        /// <summary>
        /// commnd binded to D6 button which calls roll_D6 if canClick is true
        /// </summary>
        private ICommand m_ClickD6;

        /// <summary>
        /// public facing accessor for m_ClickD6
        /// </summary>
        public ICommand ClickD6
        {
            get
            {
                return m_ClickD6 ?? (m_ClickD6 = new CommandHandler(() => roll_D6(), m_canClick));
            }
        }
        /// <summary>
        /// commnd binded to D8 button which calls roll_D8 if canClick is true
        /// </summary>
        private ICommand m_ClickD8;

        /// <summary>
        /// public facing accessor for m_ClickD8
        /// </summary>
        public ICommand ClickD8
        {
            get
            {
                return m_ClickD8 ?? (m_ClickD8 = new CommandHandler(() => roll_D8(), m_canClick));
            }
        }
        /// <summary>
        /// commnd binded to D10 button which calls roll_D10 if canClick is true
        /// </summary>
        private ICommand m_ClickD10;

        /// <summary>
        /// public facing accessor for m_ClickD10
        /// </summary>
        public ICommand ClickD10
        {
            get
            {
                return m_ClickD10 ?? (m_ClickD10 = new CommandHandler(() => roll_D10(), m_canClick));
            }
        }
        /// <summary>
        /// commnd binded to D12 button which calls roll_D12 if canClick is true
        /// </summary>
        private ICommand m_ClickD12;

        /// <summary>
        /// public facing accessor for m_ClickD12
        /// </summary>
        public ICommand ClickD12
        {
            get
            {
                return m_ClickD12 ?? (m_ClickD12 = new CommandHandler(() => roll_D12(), m_canClick));
            }
        }
        /// <summary>
        /// commnd binded to D20 button which calls roll_D20 if canClick is true
        /// </summary>
        private ICommand m_ClickD20;

        /// <summary>
        /// public facing accessor for m_ClickD20
        /// </summary>
        public ICommand ClickD20
        {
            get
            {
                return m_ClickD20 ?? (m_ClickD20 = new CommandHandler(() => roll_D20(), m_canClick));
            }
        }
        /// <summary>
        /// commnd binded to D100 button which calls roll_D100 if canClick is true
        /// </summary>
        private ICommand m_ClickD100;

        /// <summary>
        /// public facing accessor for m_ClickD100
        /// </summary>
        public ICommand ClickD100
        {
            get
            {
                return m_ClickD100 ?? (m_ClickD100 = new CommandHandler(() => roll_D100(), m_canClick));
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
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion Interfaces
    }
}