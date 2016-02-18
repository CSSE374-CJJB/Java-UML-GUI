using System;
using System.Diagnostics;
using System.Windows;

namespace Java_UML_GUI
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();
            this.Loaded += runLoad;
            progressBar.Value = 10;
        }

        public void runLoad(object sender, RoutedEventArgs e)
        {
            Process uml = MainWindow.GetJavaUmlGenProcess();

            uml.OutputDataReceived += Uml_OutputDataReceived;

            uml.Start();
            uml.BeginOutputReadLine();

            uml.Exited += Uml_Exited;

        }

        private void Uml_Exited(object sender, EventArgs e)
        {
            Process dot = MainWindow.GetDotProcess();
            statusLabel.Dispatcher.InvokeAsync(delegate ()
            {
                statusLabel.Content = "Generating PNG Image";
                progressBar.Value = 95;
            });
            dot.Start();

            dot.Exited += Dot_Exited;
        }

        private void Dot_Exited(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(delegate ()
            {
                this.Close();
            });
        }

        private void Uml_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            statusLabel.Dispatcher.InvokeAsync(delegate ()
            {
                this.statusLabel.Content = e.Data;
                this.progressBar.Value += 80 / MainWindow.INSTANCE.config.Phases.Length;
            });
        }
    }
}
