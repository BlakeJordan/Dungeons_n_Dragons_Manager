using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Text.RegularExpressions;
using System;
using System.Windows;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for EditMonsterWindow.xaml
    /// </summary>
    public partial class EditMonstersWindow : Window
    {
        /// <summary>
        /// Constructor
        ///
        /// Pre: None
        ///
        /// Post: viewmodel is given close window action and window is initialized.
        /// </summary>
        public EditMonstersWindow()
        {
            this.DataContext = m_viewModel;
            InitializeComponent();
            if (m_viewModel.CloseAction == null)
                m_viewModel.CloseAction = new Action(this.Close);
        }

        /// <summary>
        ///  EditMonster viewmodel for the editmonster window.
        /// </summary>
        private EditMonsterWindowViewmodel m_viewModel = new EditMonsterWindowViewmodel();

        /// <summary>
        /// regex for numeric input only.
        /// </summary>
        private static readonly Regex numericCheck_regex = new Regex("[^0-9]+");

        /// <summary>
        ///  regex for rollcheck. Makes sure we get correct input for dice roll input. 
        /// </summary>
        private static readonly Regex rollCheck_regex = new Regex("[^0-9d]+");

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
        /// Handles the clicking of the save button
        ///
        /// Pre: Save button is clicked
        ///
        /// Post: The monster is saved and the window is closed after the button is clicked.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the clicking of the delete button
        ///
        /// Pre: delete button has been clicked.
        ///
        /// Post: Closing of the window is handled in viewmodel, so this is just a button action to hold the button.
        /// </summary>
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {      
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
        /// CanSave updater for ComboBoxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_CheckCanSave(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            m_viewModel.CheckCanSave.Execute(null);
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

    }
}