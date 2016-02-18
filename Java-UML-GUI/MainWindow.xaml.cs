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

        public MainWindow()
        {
            InitializeComponent();
            INSTANCE = this;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static ProcessStartInfo GetJavaUmlGenProcessStartInfo()
        {
            ProcessStartInfo javaUmlProc = new ProcessStartInfo();
            javaUmlProc.UseShellExecute = false;
            javaUmlProc.FileName = "java"; // Java Jar 
            javaUmlProc.Arguments = "-jar " + Directory.GetCurrentDirectory() + @"\Resources\javaUmlGenerator.jar JSON " + MainWindow.INSTANCE.configLocation;
            return javaUmlProc;
        }

        public static ProcessStartInfo GetDotProcessStartInfo()
        {
            ProcessStartInfo dotProc = new ProcessStartInfo();
            dotProc.UseShellExecute = false;
            dotProc.FileName = MainWindow.INSTANCE.config.DotPath;
            dotProc.Arguments = "-Tpng " + MainWindow.INSTANCE.config.OutputDirectory + @"\umlOutput.txt -O";
            return dotProc;
        }

        public static void runGeneration()
        {

            ProcessStartInfo javaUmlProc = GetJavaUmlGenProcessStartInfo();

            StartAndWaitForProcess(javaUmlProc);

            // Get the Image
            ProcessStartInfo dotProc = MainWindow.GetDotProcessStartInfo();

            StartAndWaitForProcess(dotProc);
        }

        public static void StartAndWaitForProcess(ProcessStartInfo javaUmlProc)
        {
            Process uml = Process.Start(javaUmlProc);
            uml.WaitForExit();
        }
    }
}
