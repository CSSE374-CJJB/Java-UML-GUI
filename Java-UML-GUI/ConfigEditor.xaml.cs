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
            SaveFileDialog fileD = new SaveFileDialog();
            if (fileD.ShowDialog() == true)
            {
                MainWindow.INSTANCE.config.SaveToFile(fileD.FileName);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileD = new OpenFileDialog();
            if (fileD.ShowDialog() == true)
            {
                MainWindow.INSTANCE.config = JsonConfig.LoadFromFile(fileD.FileName);
                loadConfig();
            }  
        }

        private void Output_Directory_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.INSTANCE.config.OutputDirectory = Output_Directory_Text.Text;
        }

        private void Input_Classes_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.INSTANCE.config.InputClasses = Input_Class_Text.Text.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < MainWindow.INSTANCE.config.InputClasses.Length; i++)
            {
                Console.WriteLine(MainWindow.INSTANCE.config.InputClasses.GetValue(i));
            }
        }

        private void Input_Folder_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.INSTANCE.config.InputFolder = Input_Folder_Text.Text;
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
            Singleton_Check.IsChecked = MainWindow.INSTANCE.config.Singleton_RequireGetInstance;
            Decorator_Delegation_Number.SelectedIndex = MainWindow.INSTANCE.config.Decorator_MethodDelegation;
            Adapter_Delegation_Number.SelectedIndex = MainWindow.INSTANCE.config.Adapter_MethodDelegation;
            Phases_Text.Text = String.Join(", ", MainWindow.INSTANCE.config.Phases);
            Dot_Path_Text.Text = MainWindow.INSTANCE.config.DotPath;
            Input_Folder_Text.Text = MainWindow.INSTANCE.config.InputFolder;
            Input_Class_Text.Text = String.Join(", ", MainWindow.INSTANCE.config.InputClasses);
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
    }
}
