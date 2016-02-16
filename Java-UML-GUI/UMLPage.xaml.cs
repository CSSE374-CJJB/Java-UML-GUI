using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            image.MouseWheel += image_MouseWheel;
            image.MouseLeftButtonDown += image_MouseLeftButtonDown;
            image.MouseMove += image_MouseMove;
            image.MouseLeftButtonUp += image_MouseLeftButtonUp;

          //  ((CheckBox)Composite_Header.Items.GetItemAt(0)).Checked += Composite_Header_Selected;

            TransformGroup group = new TransformGroup();
            group.Children.Add(new ScaleTransform());
            group.Children.Add(new TranslateTransform());
            image.RenderTransform = group;
            file = File.ReadAllText(@".\umlOutput.txt");
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

        private void Composite_Header_Selected(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("in selected");
            ItemCollection items = Composite_Header.Items;
            bool selected = Composite_Header.IsSelected;
            for (int i = 0; i < items.Count; i++)
            {
                ((TreeViewItem)items.GetItemAt(i)).IsSelected = selected;
            }
        }
    }
}
