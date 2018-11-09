using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Windows;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main window for the application.
        /// </summary>
        public MainWindow()
        {
            this.DataContext = new MainWindowViewmodel(); //Initialize viewmodel.
            InitializeComponent();


            #region Window Size and Location Continuity

            Height = Properties.Settings.Default.MainWindow_Height;
            Width = Properties.Settings.Default.MainWindow_Width;

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

            //If first time openning app -> center window vertically
            if (Properties.Settings.Default.MainWindow_Top == 0)
            { Top = (screenHeight / 2) - (Height / 2); }
            else { Top = Properties.Settings.Default.MainWindow_Top; }

            //If first time openning app -> center window horizontally
            if (Properties.Settings.Default.MainWindow_Left == 0)
            { Left = (screenWidth / 2) - (Width / 2); }
            else
            { Left = Properties.Settings.Default.MainWindow_Left; }

            if (Properties.Settings.Default.MainWindow_Maximized)
            { WindowState = WindowState.Maximized; }

            #endregion
        }

        /// <summary>
        /// Event for window closing which saves window location and size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                // Use the RestoreBounds as the current values will be 0, 0 and the size of the screen
                Properties.Settings.Default.MainWindow_Top = RestoreBounds.Top;
                Properties.Settings.Default.MainWindow_Left = RestoreBounds.Left;
                Properties.Settings.Default.MainWindow_Height = RestoreBounds.Height;
                Properties.Settings.Default.MainWindow_Width = RestoreBounds.Width;
                Properties.Settings.Default.MainWindow_Maximized = true;
            }
            else
            {
                Properties.Settings.Default.MainWindow_Top = Top;
                Properties.Settings.Default.MainWindow_Left = Left;
                Properties.Settings.Default.MainWindow_Height = Height;
                Properties.Settings.Default.MainWindow_Width = Width;
                Properties.Settings.Default.MainWindow_Maximized = false;
            }

            Properties.Settings.Default.Save();
        }
    }
}