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
            conf.SaveToFile("./config");
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            conf = JsonConfig.LoadFromFile("./config");
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

        private void Adapter_Delegation_Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            conf.Adapter_MethodDelegation = Convert.ToInt32(Adapter_Delegation_Number.Text);
        }

        private void Decorator_Delegation_Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            conf.Decorator_MethodDelegation = Convert.ToInt32(Decorator_Delegation_Number.Text);
        }

        private void Singleton_Check_Checked(object sender, RoutedEventArgs e)
        {
            conf.Singleton_RequireGetInstance = (bool)Singleton_Check.IsChecked;

        }

    }
}
