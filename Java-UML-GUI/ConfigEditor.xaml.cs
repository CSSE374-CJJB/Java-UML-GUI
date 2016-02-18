using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Java_UML_GUI
{
    /// <summary>
    /// Interaction logic for ConfigEditor.xaml
    /// </summary>
    public partial class ConfigEditor : Window
    {
        public ConfigEditor()
        {
            MainWindow.INSTANCE.config = new JsonConfig();
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog fileD = new Microsoft.Win32.SaveFileDialog();
            if (fileD.ShowDialog() == true)
            {
                MainWindow.INSTANCE.config.SaveToFile(fileD.FileName);
                MainWindow.INSTANCE.configLocation = fileD.FileName;
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileD = new Microsoft.Win32.OpenFileDialog();
            if (fileD.ShowDialog() == true)
            {
                MainWindow.INSTANCE.config = JsonConfig.LoadFromFile(fileD.FileName);
                MainWindow.INSTANCE.configLocation = fileD.FileName;
                loadConfig();
            }  
        }

        private void Input_Classes_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.INSTANCE.config.InputClasses = Input_Classes_Text.Text.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < MainWindow.INSTANCE.config.InputClasses.Length; i++)
            {
                Console.WriteLine(MainWindow.INSTANCE.config.InputClasses[i]);
            }
        }

        private void Dot_Path_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.INSTANCE.config.DotPath = Dot_Path_Text.Text;
        }

        private void Phases_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.INSTANCE.config.Phases = Phases_Text.Text.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void Singleton_Check_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.INSTANCE.config.Singleton_RequireGetInstance = Singleton_Check.IsChecked;

        }

        private void loadConfig()
        {
            Singleton_Check.IsChecked = MainWindow.INSTANCE.config.Singleton_RequireGetInstance == null ? false: MainWindow.INSTANCE.config.Singleton_RequireGetInstance;
            Adapter_Delegation_Number.SelectedIndex = MainWindow.INSTANCE.config.Adapter_MethodDelegation;
            Decorator_Delegation_Number.SelectedIndex = MainWindow.INSTANCE.config.Decorator_MethodDelegation;
            Phases_Text.Text = String.Join(", ", MainWindow.INSTANCE.config.Phases);
            Dot_Path_Text.Text = MainWindow.INSTANCE.config.DotPath;
            Input_Folder_Text.Text = MainWindow.INSTANCE.config.InputFolder;
            Input_Classes_Text.Text = String.Join(", ", MainWindow.INSTANCE.config.InputClasses);
            Output_Directory_Text.Text = MainWindow.INSTANCE.config.OutputDirectory;
        }

        private void Decorator_Delegation_Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.INSTANCE.config.Decorator_MethodDelegation = Decorator_Delegation_Number.SelectedIndex;
        }

        private void Adapter_Delegation_Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.INSTANCE.config.Adapter_MethodDelegation = Adapter_Delegation_Number.SelectedIndex;
        }

        private void Output_Directory_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Output_Directory_Text.Text = dialog.SelectedPath;
                MainWindow.INSTANCE.config.OutputDirectory = dialog.SelectedPath;
            }
        }

        private void Input_Folder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Input_Folder_Text.Text = dialog.SelectedPath;
                MainWindow.INSTANCE.config.InputFolder = dialog.SelectedPath;
            }
        }

        private void Dot_Path_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileD = new Microsoft.Win32.OpenFileDialog();
            fileD.Filter = "DotProgram|dot.exe";
            if (fileD.ShowDialog() == true)
            {
                Dot_Path_Text.Text = fileD.FileName;
                MainWindow.INSTANCE.config.DotPath = fileD.FileName;
            }
        }
    }
}
