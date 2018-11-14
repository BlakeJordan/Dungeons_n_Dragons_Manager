using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
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
        public CreateMonsterWindow(ref Monster monster)
        {
            m_dataContext = new CreateMonsterWindowViewmodel(ref monster); //Initialize viewmodel.
            this.DataContext = m_dataContext;
            InitializeComponent();
        }

        private CreateMonsterWindowViewmodel m_dataContext;

        /// <summary>
        /// A boolean indicating whether the save button has been clicked or not
        /// </summary>
        public bool SaveMonster { get; set; }

        /// <summary>
        /// Handles the clicking of the save button
        ///
        /// Pre: Save button is clicked
        ///
        /// Post: The Save Monster boolean is set to true and the window is closed
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveMonster = true;
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            m_dataContext.updateCanSave();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            m_dataContext.updateCanSave();
        }
    }
}