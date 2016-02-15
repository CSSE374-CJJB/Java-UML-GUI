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
        JsonConfig conf;

        public ConfigEditor()
        {
            conf = new JsonConfig();
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileD = new SaveFileDialog();
            if (fileD.ShowDialog() == true)
            {
                conf.SaveToFile(fileD.FileName);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileD = new OpenFileDialog();
            if (fileD.ShowDialog() == true)
            {
                conf = JsonConfig.LoadFromFile(fileD.FileName);
                loadConfig();
            }  
        }

        private void Output_Directory_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            conf.OutputDirectory = Output_Directory_Text.Text;
        }

        private void Input_Classes_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            conf.InputClasses = Input_Classes_Text.Text;
        }

        private void Input_Folder_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            conf.InputFolder = Input_Folder_Text.Text;
        }

        private void Dot_Path_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            conf.DotPath = Dot_Path_Text.Text;
        }

        private void Phases_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            conf.Phases = Phases_Text.Text;
        }

        private void Singleton_Check_Checked(object sender, RoutedEventArgs e)
        {
            conf.Singleton_RequireGetInstance = Singleton_Check.IsChecked;

        }

        private void loadConfig()
        {
            Singleton_Check.IsChecked = conf.Singleton_RequireGetInstance;
            Decorator_Delegation_Number.SelectedIndex = conf.Decorator_MethodDelegation;
            Adapter_Delegation_Number.SelectedIndex = conf.Adapter_MethodDelegation;
            Phases_Text.Text = conf.Phases;
            Dot_Path_Text.Text = conf.DotPath;
            Input_Folder_Text.Text = conf.InputFolder;
            Input_Classes_Text.Text = conf.InputClasses;
            Output_Directory_Text.Text = conf.OutputDirectory;
        }

        private void Decorator_Delegation_Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            conf.Decorator_MethodDelegation = Decorator_Delegation_Number.SelectedIndex;
        }

        private void Adapter_Delegation_Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            conf.Adapter_MethodDelegation = Adapter_Delegation_Number.SelectedIndex;
        }
    }
}
