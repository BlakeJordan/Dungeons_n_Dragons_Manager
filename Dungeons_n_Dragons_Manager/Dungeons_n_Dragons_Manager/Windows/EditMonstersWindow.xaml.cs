using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Text.RegularExpressions;
using System;
using System.Windows;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for CreateMonsterWindow.xaml
    /// </summary>
    public partial class EditMonstersWindow : Window
    {
        /// <summary>
        /// Constructor
        ///
        /// Pre: None
        ///
        /// Post: Data context is set with m_newMonster as monster passed by reference.
        /// </summary>
        public EditMonstersWindow()
        {
            this.DataContext = m_viewModel;
            InitializeComponent();
            if (m_viewModel.CloseAction == null)
                m_viewModel.CloseAction = new Action(this.Close);
        }

        private EditMonsterWindowViewmodel m_viewModel = new EditMonsterWindowViewmodel();

        private static readonly Regex numericCheck_regex = new Regex("[^0-9]+");

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
        /// Post: The Save Monster boolean is set to true and the window is closed
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the clicking of the save button
        ///
        /// Pre: Save button is clicked
        ///
        /// Post: The Save Monster boolean is set to true and the window is closed
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