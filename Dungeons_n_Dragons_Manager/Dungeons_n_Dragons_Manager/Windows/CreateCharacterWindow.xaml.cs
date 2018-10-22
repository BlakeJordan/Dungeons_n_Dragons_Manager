using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Windows;

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
        public CreateCharacterWindow(ref Character character)
        {
            this.DataContext = new CreateCharacterWindowViewmodel(ref character); //Initialize viewmodel.
            InitializeComponent();
        }

        /// <summary>
        /// A boolean indicating whether the save button has been clicked or not
        /// </summary>
        public bool SaveCharacter { get; set; }

        /// <summary>
        /// Handles the clicking of the save button
        ///
        /// Pre: Save button is clicked
        ///
        /// Post: The Save Character boolean is set to true and the window is closed
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveCharacter = true;
            this.Close();
        }
    }
}