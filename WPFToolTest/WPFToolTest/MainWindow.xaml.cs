using Microsoft.Win32;
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
using System.IO;

namespace WPFToolTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "JPEG files (*.jpeg)|*.jpeg|PNG files (*.png)|*.png|JFIF files (*.jfif)|*.jfif|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                // 첫 번째 이미지 파일만 표시
                string selectedFile = openFileDialog.FileNames[0];
                BitmapImage bitmap = new BitmapImage(new Uri(selectedFile));
                imgViewer.Source = bitmap;
                btnOpenFile.Width = bitmap.Width;
                btnOpenFile.Height = bitmap.Height;

            }
        }



    }
}