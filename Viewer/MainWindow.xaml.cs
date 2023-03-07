using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Example
{
    //Defines the customer object
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMember { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public Customer(string firstName, string lastName, int age, bool isMember)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsMember = isMember;
        }

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Customer> custdata = new ObservableCollection<Customer>();

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
            DataPanel.ItemsSource = custdata;
            custdata.Add(new Customer("Alice", "Chan", 10, true));
            custdata.Add(new Customer("Alice", "Tan", 20, true));
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            custdata.Clear();
            foreach (Customer customer in DataPanel.ItemsSource)
            {
                customer.Age = customer.Age + 1;
            }
            custdata.Add(new Customer("Alice", "Tan", 20, true));
        }
    }
}
