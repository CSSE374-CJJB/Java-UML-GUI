using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Java_UML_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow INSTANCE;
        public JsonConfig config;
        public String configLocation;

        public UMLPage umlPage;

        public MainWindow()
        {
            InitializeComponent();
            INSTANCE = this;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static Process GetJavaUmlGenProcess()
        {
            Process toReturn = new Process();
            toReturn.StartInfo.UseShellExecute = false;
            toReturn.StartInfo.CreateNoWindow = true;
            toReturn.StartInfo.RedirectStandardOutput = true;
            toReturn.StartInfo.FileName = "java"; // Java Jar 
            toReturn.StartInfo.Arguments = "-jar " + Directory.GetCurrentDirectory() + @"\Resources\javaUmlGenerator.jar JSON " + MainWindow.INSTANCE.configLocation;

            toReturn.EnableRaisingEvents = true;

            return toReturn;
        }

        public static Process GetDotProcess()
        {
            ProcessStartInfo dotProc = new ProcessStartInfo();
            dotProc.UseShellExecute = false;
            dotProc.FileName = MainWindow.INSTANCE.config.DotPath;
            dotProc.CreateNoWindow = true;
            //dotProc.RedirectStandardOutput = true;
            dotProc.Arguments = "-Tpng " + MainWindow.INSTANCE.config.OutputDirectory + @"\umlOutput.txt -O";

            Process toReturn = new Process();
            toReturn.StartInfo = dotProc;
            toReturn.EnableRaisingEvents = true;

            return toReturn;
        }

        public static void runGeneration()
        {
            new Loading().ShowDialog();
        }

        public static void StartAndWaitForProcess(ProcessStartInfo javaUmlProc)
        {
            Process uml = Process.Start(javaUmlProc);
            uml.WaitForExit();
        }

        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().ShowDialog();
        }

        private void GuideMenu_Click(object sender, RoutedEventArgs e)
        {
            new GuideWindow().ShowDialog();
        }

        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.INSTANCE.mainFrame.Navigate(new StartupPage());
        }

        private void ExportMenu_Click(object sender, RoutedEventArgs e)
        {
            if(umlPage != null)
                umlPage.ExportImage();
        }
    }
}
