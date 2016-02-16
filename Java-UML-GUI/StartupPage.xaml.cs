using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            // Get the Dot Text File
/*
            Process javaUmlProc = new Process();
            javaUmlProc.StartInfo.UseShellExecute = false;
            javaUmlProc.StartInfo.FileName = ""; // Java Jar 
            javaUmlProc.StartInfo.Arguments = MainWindow.INSTANCE.config.getJavaUMLArguments();
            javaUmlProc.StartInfo.RedirectStandardOutput = true;
            javaUmlProc.StartInfo.RedirectStandardInput = true;
            javaUmlProc.EnableRaisingEvents = true;

            javaUmlProc.Start();


            // Get the Image
            Process dotProc = new Process();
            dotProc.StartInfo.UseShellExecute = false;
            dotProc.StartInfo.FileName = MainWindow.INSTANCE.config.DotPath; 
            dotProc.StartInfo.Arguments = "-Tpng umlOutput.txt -O";
            dotProc.StartInfo.RedirectStandardOutput = true;
            dotProc.StartInfo.RedirectStandardInput = true;
            dotProc.EnableRaisingEvents = true;

            dotProc.Start();
            */
            MainWindow.INSTANCE.mainFrame.Source = new Uri("UMLPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
