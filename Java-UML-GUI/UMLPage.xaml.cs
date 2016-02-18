using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Java_UML_GUI
{
    /// <summary>
    /// Interaction logic for UMLPage.xaml
    /// </summary>
    public partial class UMLPage : Page
    {
        string file;

        public UMLPage()
        {
            InitializeComponent();

            updateImage();

            image.MouseWheel += image_MouseWheel;
            image.MouseLeftButtonDown += image_MouseLeftButtonDown;
            image.MouseMove += image_MouseMove;
            image.MouseLeftButtonUp += image_MouseLeftButtonUp;

            TransformGroup group = new TransformGroup();
            group.Children.Add(new ScaleTransform());
            group.Children.Add(new TranslateTransform());
            image.RenderTransform = group;


            file = File.ReadAllText(MainWindow.INSTANCE.config.OutputDirectory + @"\umlOutput.txt");
            PopulateCheckBoxes();
        }

        // http://stackoverflow.com/questions/741956/pan-zoom-image

        private void image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var st = (ScaleTransform)((TransformGroup)image.RenderTransform)
                .Children.First(tr => tr is ScaleTransform);
            double zoom = e.Delta > 0 ? .2 : -.2;
            st.ScaleX += zoom;
            st.ScaleY += zoom;
        }

        Point start;
        Point origin;
        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image.CaptureMouse();
            var tt = (TranslateTransform)((TransformGroup)image.RenderTransform)
                .Children.First(tr => tr is TranslateTransform);
            start = e.GetPosition(border);
            origin = new Point(tt.X, tt.Y);
        }

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (image.IsMouseCaptured)
            {
                var tt = (TranslateTransform)((TransformGroup)image.RenderTransform)
                    .Children.First(tr => tr is TranslateTransform);
                Vector v = start - e.GetPosition(border);
                tt.X = origin.X - v.X;
                tt.Y = origin.Y - v.Y;
            }
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            image.ReleaseMouseCapture();
        }

        private void PopulateCheckBoxes()
        {

            string[] seperator = new string[] { "\\l\\<\\<decorator\\>\\>" };
            string[] array = file.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            DecoratorBoxes(array);

            seperator = new string[] { "\\l\\<\\<singleton\\>\\>" };
            string[] singletonArray = file.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            SingletonBoxes(singletonArray);

            seperator = new string[] { "\\l\\<\\<Composite\\>\\>" };
            string[] compositeArray = file.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            CompositeBoxes(compositeArray);
            seperator = new string[] { "\\l\\<\\<Component\\>\\>" };
            compositeArray = file.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            CompositeBoxes(compositeArray);

            seperator = new string[] { "\\l\\<\\<adapter\\>\\>" };
            string[] adapterArray = file.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            AdapterBoxes(adapterArray);
            seperator = new string[] { "\\l\\<\\<adaptee\\>\\>" };
            adapterArray = file.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            AdapterBoxes(adapterArray);
            seperator = new string[] { "\\l\\<\\<target\\>\\>" };
            adapterArray = file.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            AdapterBoxes(adapterArray);

        }

        internal void ExportImage()
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();

            Microsoft.Win32.SaveFileDialog fileD = new Microsoft.Win32.SaveFileDialog();
            fileD.AddExtension = true;
            fileD.DefaultExt = ".jpg";
            if (fileD.ShowDialog() == true)
            {
                encoder.Frames.Add(BitmapFrame.Create((BitmapImage)image.Source));

                using (var filestream = new FileStream(fileD.FileName, FileMode.Create))
                    encoder.Save(filestream);
            }

        }

        private void DecoratorBoxes(string[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                string[] nameArray = array[i].Split("{".ToCharArray());
                if (nameArray[nameArray.Length - 1].Contains("\\<\\<interface\\>\\>\\l"))
                {
                    string[] seperator = new string[] { "\\<\\<interface\\>\\>\\l" };
                    nameArray = nameArray[nameArray.Length - 1].Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                    Decorator_Header.Items.Add(nameArray[nameArray.Length - 1]);
                } else
                {
                    Decorator_Header.Items.Add(nameArray[nameArray.Length - 1]);
                }
                
            }
        }

        private void SingletonBoxes(string[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                string[] nameArray = array[i].Split("{".ToCharArray());
                if (nameArray[nameArray.Length - 1].Contains("\\<\\<interface\\>\\>\\l"))
                {
                    string[] seperator = new string[] { "\\<\\<interface\\>\\>\\l" };
                    nameArray = nameArray[nameArray.Length - 1].Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                    Singleton_Header.Items.Add(nameArray[nameArray.Length - 1]);
                }
                else
                {
                    Singleton_Header.Items.Add(nameArray[nameArray.Length - 1]);
                }

            }
        }

        private void CompositeBoxes(string[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                string[] nameArray = array[i].Split("{".ToCharArray());
                if (nameArray[nameArray.Length - 1].Contains("\\<\\<interface\\>\\>\\l"))
                {
                    string[] seperator = new string[] { "\\<\\<interface\\>\\>\\l" };
                    nameArray = nameArray[nameArray.Length - 1].Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                    Composite_Header.Items.Add(nameArray[nameArray.Length - 1]);
                }
                else
                {
                    Composite_Header.Items.Add(nameArray[nameArray.Length - 1]);
                }

            }
        }

        private void AdapterBoxes(string[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                string[] nameArray = array[i].Split("{".ToCharArray());
                if (nameArray[nameArray.Length - 1].Contains("\\<\\<interface\\>\\>\\l"))
                {
                    string[] seperator = new string[] { "\\<\\<interface\\>\\>\\l" };
                    nameArray = nameArray[nameArray.Length - 1].Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                    Adapter_Header.Items.Add(nameArray[nameArray.Length - 1]);
                }
                else
                {
                    Adapter_Header.Items.Add(nameArray[nameArray.Length - 1]);
                }

            }
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)e.OriginalSource;

            String clazz = ((TextBlock)((StackPanel)chk.Parent).Children[1]).Text;
            MainWindow.INSTANCE.config.exclusion.Remove(clazz);
            MainWindow.INSTANCE.config.SaveToFile(MainWindow.INSTANCE.configLocation);

            resetImage();
        }

        private void resetImage()
        {
            BitmapImage loading = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\Resources\loading.gif"));
            image.Source = loading;

            MainWindow.runGeneration();

            updateImage();
        }

        private void Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)e.OriginalSource;

            String clazz = ((TextBlock)((StackPanel)chk.Parent).Children[1]).Text;
            MainWindow.INSTANCE.config.exclusion.Add(clazz);
            MainWindow.INSTANCE.config.SaveToFile(MainWindow.INSTANCE.configLocation);

            resetImage();
        }

        private void updateImage()
        {
            using (var fs = new FileStream(MainWindow.INSTANCE.config.OutputDirectory + @"\umlOutput.txt.png", System.IO.FileMode.Open))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = fs;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                image.Source = bitmapImage;
            }

        }
    }
}
