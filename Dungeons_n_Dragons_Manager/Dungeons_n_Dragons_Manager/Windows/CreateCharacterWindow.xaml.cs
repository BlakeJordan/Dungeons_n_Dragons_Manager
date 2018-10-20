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
        /// @Pre: None
        /// @Post: Data context is set with m_newCharacter as character passed by reference.
        /// </summary>
        public CreateCharacterWindow(ref Character character)
        {
            this.DataContext = new CreateCharacterWindowViewmodel(ref character); //Initialize viewmodel.
            InitializeComponent();
        }
    }
}