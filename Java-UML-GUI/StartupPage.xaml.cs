using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Java_UML_GUI
{
    /// <summary>
    /// Interaction logic for StartupPage.xaml
    /// </summary>
    public partial class StartupPage : Page
    {
        public StartupPage()
        {
            InitializeComponent();
        }

        private void ConfigurationButton_Click(object sender, RoutedEventArgs e)
        {
            new ConfigEditor().ShowDialog();
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO Check config file to make sure it has valid arguments

            MainWindow.runGeneration();

            MainWindow.INSTANCE.mainFrame.Source = new Uri("UMLPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
