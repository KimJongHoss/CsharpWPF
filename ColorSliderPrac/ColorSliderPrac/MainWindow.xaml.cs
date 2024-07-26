using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorSliderPrac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte r = 0;
        private byte g = 0;
        private byte b = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void redSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            r = (byte)slider.Value;
            redLabel.Content = r;
            UpdateBackgroundColor();
        }

        private void GreenSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            g = (byte)slider.Value;
            GreenLabel.Content = g;
            UpdateBackgroundColor();
        }

        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            b = (byte)slider.Value;
            BlueLabel.Content = b;
            UpdateBackgroundColor();
        }

        private void UpdateBackgroundColor()
        {
            if (originalButton.IsChecked == true)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
            else if (GrayToneButton.IsChecked == true)
            {
                int ave = (r + g + b)/3;

                MainGrid.Background = new SolidColorBrush(Color.FromRgb((byte)ave, (byte)ave, (byte)ave));
            }
            else if (InvertButton.IsChecked == true)
            {
                byte max = 225;
                int br = max - r;
                int bg = max - g;
                int bb = max - b;

                MainGrid.Background = new SolidColorBrush(Color.FromRgb((byte)br, (byte)bg, (byte)bb));
            }

        }

        private void originalButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateBackgroundColor();
        }

        private void GrayToneButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateBackgroundColor();
        }

        private void InvertButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateBackgroundColor();
        }
    
    }
}