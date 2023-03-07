using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {//Defines the customer object
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool IsMember { get; set; }
            public int Age { get; set; }
            public Customer(string firstName, string lastName, int age, bool isMember)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                IsMember = isMember;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Uri uri = new Uri(Viewer.Properties.Settings.Default.AssetsPath + "\\bliss.jpg");
            BitmapImage bitmapSource = new BitmapImage(uri);
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(
                    bitmapSource,
                    new Rect(0, 0, bitmapSource.PixelWidth, bitmapSource.PixelHeight)
                    );
                drawingContext.DrawRectangle(
                    null,
                    new Pen(Brushes.Red, 20),
                    new Rect(200, 200, 400, 400)
                    );
            }

            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(
                bitmapSource.PixelWidth,
                bitmapSource.PixelHeight,
                96,
                96,
                PixelFormats.Pbgra32
                );
            renderTargetBitmap.Render(drawingVisual);
            ImageScreen.Source = renderTargetBitmap;

            //Set the DataGrid's DataContext to be a filled DataTable
            ObservableCollection<Customer> custdata = new ObservableCollection<Customer>();
            DataPanel.ItemsSource = custdata;
            custdata.Add(new Customer("Alice", "Chan", 10, true));
            custdata.Add(new Customer("Alice", "Tan", 20, true));
        }
    }
}
