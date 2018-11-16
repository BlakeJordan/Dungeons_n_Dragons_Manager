using Dungeons_n_Dragons_Manager.Models;
using Dungeons_n_Dragons_Manager.Viewmodels;
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
            this.DataContext = new EditMonsterWindowViewmodel(); //Initialize viewmodel.
            InitializeComponent();
        }

        ///// <summary>
        ///// A boolean indicating whether the save button has been clicked or not
        ///// </summary>
        //public bool SaveMonster { get; set; }

        /// <summary>
        /// Handles the clicking of the save button
        ///
        /// Pre: Save button is clicked
        ///
        /// Post: The Save Monster boolean is set to true and the window is closed
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SaveMonster = true;
            this.Close();
        }

    }
}