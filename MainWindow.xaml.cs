﻿using System;
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

namespace Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Uri uri = new Uri("C:\\Users\\admin\\Desktop\\astra\\bliss.jpg");
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
        }
    }
}
