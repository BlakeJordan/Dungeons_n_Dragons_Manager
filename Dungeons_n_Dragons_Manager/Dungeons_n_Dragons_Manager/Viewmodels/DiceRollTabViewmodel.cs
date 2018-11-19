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
        /// parses through the resulting list of lits of strings from the RollMultiple fucntion and populates roll with the values
        ///
        /// Pre: RollMultiple has been called and all of thr roll quantity textboxes have values
        ///
        /// Post: rolls string is populated by all of the rolls for the die
        /// </summary>
        private void roll_D4()
        {
            rolls = rolls + " " + bag.Roll(4);
        }

        private void roll_D6()
        {
            rolls = rolls + " " + bag.Roll(6);
        }

        private void roll_D8()
        {
            rolls = rolls + " " + bag.Roll(8);
        }

        private void roll_D10()
        {
            rolls = rolls + " " + bag.Roll(10);
        }

        private void roll_D12()
        {
            rolls = rolls + " " + bag.Roll(12);
        }

        private void roll_D20()
        {
            rolls = rolls + " " + bag.Roll(20);
        }

        private void roll_D100()
        {
            rolls = rolls + " " + bag.Roll(100);
        }

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
        ///
        /// </summary>
        private ICommand m_Clear;

        /// <summary>
        ///
        /// </summary>
        public ICommand Clear
        {
            get
            {
                return m_Clear ?? (m_Clear = new CommandHandler(() => clear_Rolls(), m_canClick));
            }
        }

        /// <summary>
        /// commnd binded to Roll button which calls roll_button_click if canClick is true
        /// </summary>
        private ICommand m_ClickD4;

        /// <summary>
        /// public facing accessor for m_Click
        /// </summary>
        public ICommand ClickD4
        {
            get
            {
                return m_ClickD4 ?? (m_ClickD4 = new CommandHandler(() => roll_D4(), m_canClick));
            }
        }

        /// <summary>
        /// commnd binded to Roll button which calls roll_button_click if canClick is true
        /// </summary>
        private ICommand m_ClickD6;

        /// <summary>
        /// public facing accessor for m_Click
        /// </summary>
        public ICommand ClickD6
        {
            get
            {
                return m_ClickD6 ?? (m_ClickD6 = new CommandHandler(() => roll_D6(), m_canClick));
            }
        }

        private ICommand m_ClickD8;

        /// <summary>
        /// public facing accessor for m_Click
        /// </summary>
        public ICommand ClickD8
        {
            get
            {
                return m_ClickD8 ?? (m_ClickD8 = new CommandHandler(() => roll_D8(), m_canClick));
            }
        }

        private ICommand m_ClickD10;

        /// <summary>
        /// public facing accessor for m_Click
        /// </summary>
        public ICommand ClickD10
        {
            get
            {
                return m_ClickD10 ?? (m_ClickD10 = new CommandHandler(() => roll_D10(), m_canClick));
            }
        }

        private ICommand m_ClickD12;

        /// <summary>
        /// public facing accessor for m_Click
        /// </summary>
        public ICommand ClickD12
        {
            get
            {
                return m_ClickD12 ?? (m_ClickD12 = new CommandHandler(() => roll_D12(), m_canClick));
            }
        }

        private ICommand m_ClickD20;

        /// <summary>
        /// public facing accessor for m_Click
        /// </summary>
        public ICommand ClickD20
        {
            get
            {
                return m_ClickD20 ?? (m_ClickD20 = new CommandHandler(() => roll_D20(), m_canClick));
            }
        }

        private ICommand m_ClickD100;

        /// <summary>
        /// public facing accessor for m_Click
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