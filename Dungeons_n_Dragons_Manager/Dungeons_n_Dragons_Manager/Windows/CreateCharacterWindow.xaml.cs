using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for CreateCharacterWindow.xaml
    /// </summary>
    public partial class CreateCharacterWindow : Window
    {
        /// <summary>
        /// Constructor
        ///
        /// Pre: None
        ///
        /// Post: Data context is set with m_newCharacter as character passed by reference.
        /// </summary>
        public CreateCharacterWindow()
        {
            this.DataContext = m_viewmodel;
            InitializeComponent();
        }

        private CreateCharacterWindowViewmodel m_viewmodel = new CreateCharacterWindowViewmodel();

        /// <summary>
        /// Handles the clicking of the save button
        ///
        /// Pre: Save button is clicked
        ///
        /// Post: Window is closed.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_CheckCanSave(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            m_viewmodel.CheckCanSave.Execute(null);
        }

        private void ComboBox_CheckCanSave(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            m_viewmodel.CheckCanSave.Execute(null);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}