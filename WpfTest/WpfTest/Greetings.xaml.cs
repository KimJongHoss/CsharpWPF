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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest
{
    /// <summary>
    /// Greettings.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Greettings : Window
    {

        bool image_btn_hamburger = true;
        Uri uriHamburgerImage;
        Uri uriOnlyHamburgerImage;
        public Greettings()
        {
            InitializeComponent();

            this.uriHamburgerImage = new Uri(@"pack://application:,,,/resources/hamburger.jfif", UriKind.Absolute);
            this.uriOnlyHamburgerImage = new Uri(@"pack://application:,,,/resources/onlyHamburger.jfif", UriKind.Absolute);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (HelloButton.IsChecked == true)
            {
                MessageBox.Show("Hello.");
            }
            else if (GoodbyeButton.IsChecked == true)
            {
                MessageBox.Show("Goodbye.");
            }
        }

        private void onlyHamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.image_btn_hamburger)
            {
                onlyHamburgerButton.Background = new ImageBrush(new BitmapImage(this.uriHamburgerImage));
                ImageBox.Source = new BitmapImage(this.uriOnlyHamburgerImage);
                this.image_btn_hamburger = false;
            }
            else 
            {
                onlyHamburgerButton.Background = new ImageBrush(new BitmapImage(this.uriOnlyHamburgerImage));
                ImageBox.Source = new BitmapImage(this.uriHamburgerImage);
                this.image_btn_hamburger = true;
            }
        }
    }
}
