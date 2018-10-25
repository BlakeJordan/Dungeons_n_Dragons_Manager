using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for EditCharacterWindow.xaml
    /// </summary>
    public partial class EditCharacterWindow : Window
    {
        public EditCharacterWindow(ref Character character)
        {
            this.DataContext = new EditCharacterWindowViewModel(ref character); //Initialize viewmodel.
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
