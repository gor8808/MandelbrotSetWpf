using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
using Color = System.Drawing.Color;

namespace MandelbrotSetWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bitmap image;
        private double _YMax = 1.2;
        private double _YMin = -1.2;
        private double _XMax = 1.2;
        private double _XMin = -2.2;
        public List<Color> ColorsForDrawing = new List<Color>();
        const int maxMandelbrotValue = 2;
        public int Deep = 70;
        public MainWindow()
        {
            ColorsForDrawing.Add(Color.Black);
            ColorsForDrawing.Add(Color.Red);
            ColorsForDrawing.Add(Color.Green);
            ColorsForDrawing.Add(Color.PaleGoldenrod);
            ColorsForDrawing.Add(Color.AntiqueWhite);
            ColorsForDrawing.Add(Color.Yellow);
            ColorsForDrawing.Add(Color.White);
            ColorsForDrawing.Add(Color.Purple);
            ColorsForDrawing.Add(Color.YellowGreen);
            ColorsForDrawing.Add(Color.Blue);
            ColorsForDrawing.Add(Color.HotPink);
            InitializeComponent();
        }

        private void RunTest()
        {

        }

        private void RunProgram()
        {
            //var timer1 = System.Diagnostics.Stopwatch.StartNew();
            int imgWidth = 500;
            int imgHeight = 500;
            image = new Bitmap(imgWidth, imgHeight);
            double xChangeValue = (_XMax - _XMin) / (imgWidth);
            double yChangeValue = (_YMax - _YMin) / (imgHeight);
            double x = _XMin;

            for (int X = 0; X < imgWidth; X++)
            {
                double y = _YMin;
                for (int Y = 0; Y < imgHeight; Y++)
                {
                    int n = 1;
                    CNumber C = new CNumber(x, y);
                    ZFunction Z = new ZFunction(0);
                    while ((n < Deep) && (Z.Length < maxMandelbrotValue))
                    {
                        Z = Z * Z + C;
                        n++;
                    }
                    image.SetPixel(X, Y, ColorsForDrawing[n % ColorsForDrawing.Count]);
                    y += yChangeValue;
                }
                x += xChangeValue;

                if (X % 10 == 0)
                {
                    //pictureBox1.Source = BitmapToImageSource(image);
                    //pictureBox1.UpdateLayout();
                }
            }
            pictureBox1.Source = BitmapToImageSource(image);

            //timer1.Stop();
            //Timer.Text = $"{(double)timer1.ElapsedMilliseconds / 1000} sec";
            //ShowImage.Source = BitmapToImageSource(image);
        }
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RunProgram();

        }
    }
}
