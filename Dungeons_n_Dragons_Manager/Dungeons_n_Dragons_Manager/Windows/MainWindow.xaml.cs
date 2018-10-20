using Dungeons_n_Dragons_Manager.Viewmodels;
using System.Windows;

namespace Dungeons_n_Dragons_Manager.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewmodel(); //Initialize viewmodel.
            InitializeComponent();
        }
    }
}