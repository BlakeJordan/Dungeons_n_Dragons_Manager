using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Text.RegularExpressions;
using System.Windows;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for CreateMonsterWindow.xaml
    /// </summary>
    public partial class CreateMonsterWindow : Window
    {
        /// <summary>
        /// Constructor
        ///
        /// Pre: None
        ///
        /// Post: Data context is set with m_newMonster as monster passed by reference.
        /// </summary>
        public CreateMonsterWindow()
        {
            this.DataContext = m_viewModel;
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        ///  Create monster viewmodel for the create monster window.
        /// </summary>
        private CreateMonsterWindowViewmodel m_viewModel = new CreateMonsterWindowViewmodel();

        /// <summary>
        /// regex for numeric input only.
        /// </summary>
        private static readonly Regex numericCheck_regex = new Regex("[^0-9]+");

        /// <summary>
        ///  regex for rollcheck. Makes sure we get correct input for dice roll input. 
        /// </summary>
        private static readonly Regex rollCheck_regex = new Regex("[^0-9d+]+");

        #endregion Properties

        #region Functions

        /// <summary>
        /// Regex function for numeric input.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool NumericCheck(string text)
        {
            return !numericCheck_regex.IsMatch(text);
        }

        /// <summary>
        /// Regex function for roll input.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool RollCheck(string text)
        {
            return !rollCheck_regex.IsMatch(text);
        }

        /// <summary>
        /// CanSave updater for ComboBoxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_CheckCanSave(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            m_viewModel.CheckCanSave.Execute(null);
        }

        /// <summary>
        /// CanSave updater for TextBoxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_CheckCanSave(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            m_viewModel.CheckCanSave.Execute(null);
        }

        /// <summary>
        /// Event to close window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Regex validation for numeric textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_NumericCheck(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !NumericCheck(e.Text);
        }

        /// <summary>
        /// Regex validation for roll textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_RollCheck(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !RollCheck(e.Text);
        }

        #endregion Functions
    }
}