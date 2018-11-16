using System;
using System.IO;
using System.Windows;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for UserManualWindow.xaml
    /// </summary>
    public partial class UserManualWindow : Window
    {
        public UserManualWindow()
        {
            InitializeComponent();

            //Navigate WebBrowser to local HTML
            string currentDirectory = Directory.GetCurrentDirectory();
            string HTML = System.IO.File.ReadAllText(currentDirectory + "\\Assets\\UserManual.html");
            HTML = HTML.Replace("\n", String.Empty).Replace("\r", String.Empty);
            ui_webBrowser.NavigateToString(HTML);
        }
    }
}