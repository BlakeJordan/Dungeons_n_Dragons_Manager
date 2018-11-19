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
            this.DataContext = m_viewModel;
            InitializeComponent();
            if (m_viewModel.CloseAction == null)
                m_viewModel.CloseAction = new Action(this.Close);
        }

        private EditMonsterWindowViewmodel m_viewModel = new EditMonsterWindowViewmodel();

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
           //if(Properties.Settings.Default.CustomMonstersList.Count == 1)
            //{
              //  this.Close();
            //}         
        }

        private void TextBox_CheckCanSave(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            m_viewModel.CheckCanSave.Execute(null);
        }

        private void ComboBox_CheckCanSave(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            m_viewModel.CheckCanSave.Execute(null);
        }
    }
}