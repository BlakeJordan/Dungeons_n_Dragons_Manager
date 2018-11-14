using System;
using System.Collections.Generic;
using System.IO;
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
