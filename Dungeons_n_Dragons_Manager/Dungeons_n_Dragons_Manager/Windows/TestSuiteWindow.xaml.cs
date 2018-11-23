
using Dungeons_n_Dragons_Manager.Test_Suite;
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
    /// Interaction logic for TestSuiteWindow.xaml
    /// </summary>
    public partial class TestSuiteWindow : Window
    {
        public TestSuiteWindow()
        {
            InitializeComponent();

            TestSuite testSuite = new TestSuite();
            foreach(string line in testSuite.RunAllTests())
            {
                ui_textBox.Text += line + "\n";
            }
        }
    }
}
