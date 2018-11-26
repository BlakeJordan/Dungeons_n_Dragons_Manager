using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for EditCharacterWindow.xaml
    /// </summary>
    public partial class EditCharacterWindow : Window
    {
        /// <summary>
        /// Constructor
        ///
        /// Pre: None
        ///
        /// Post: Data context is set with m_selectedCharacter as character passed by reference.
        /// </summary>
        public EditCharacterWindow(ref Character character)
        {
            m_viewmodel = new EditCharacterWindowViewModel(ref character);
            this.DataContext = m_viewmodel;
            InitializeComponent();
        }

        /// <summary>
        /// DataContext for the window.
        /// </summary>
        private EditCharacterWindowViewModel m_viewmodel { get; set; }

        /// <summary>
        /// Handles the clicking of the save button
        ///
        /// Pre: Save button is clicked
        ///
        /// Post: The Save Character boolean is set to true and the window is closed
        /// </summary>
        private void Save_Character(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the clicking of the delete button
        ///
        /// Pre: Delete button is clicked
        ///
        /// Post: The Delete Character boolean is set to true and the window is closed
        /// </summary>
        private void Delete_Character(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void TextBox_CheckCanSave(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // m_viewmodel.CheckCanSave.Execute(null);
        }

        private void ComboBox_CheckCanSave(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //m_viewmodel.CheckCanSave.Execute(null);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}