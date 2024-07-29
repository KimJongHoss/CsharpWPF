using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace WpfToolTest3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filePath;
        public MainWindow()
        {
            InitializeComponent();
            InitializeWebViewSource();

            // 사용자의 AppData Roaming 폴더 경로 설정
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopFolder, "favoriteURLLIst");

            // 폴더가 존재하지 않으면 생성
            Directory.CreateDirectory(folderPath);
            // 파일 경로 설정 (예: 사용자이름 폴더 내의 data.txt 파일)
            filePath = Path.Combine(folderPath, "favoriteFiles.fvr");

            // historyArray 초기화 
            List<string> startList = MainWindow.LoadArrayFromFile(filePath);



            foreach (string item in startList)
            {
                favoriteListBox.Items.Add(item);
                Console.WriteLine("프로그램 시작시 startList의 아이템들 : " + item);
            }

            // Closing 이벤트 핸들러 추가
            this.Closing += Window_Closing;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // ListBox 항목 저장
                SaveArrayToFile(filePath, favoriteListBox.Items.Cast<string>().ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일을 저장하는 도중 오류가 발생했습니다: " + ex.Message);
            }
        }

        

        public static void SaveArrayToFile(string path, List<string> data)
        {
            File.WriteAllLines(path, data);
        }

        public static List<string> LoadArrayFromFile(string path)
        {
            List<string> result = new List<string>();
            if (File.Exists(path))
            {
                result.AddRange(File.ReadAllLines(path));
            }
            return result;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("checked");
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("unchecked");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            MessageBox.Show($"Button_Click {button.Content}");
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            lable1.Content = slider.Value;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // SelectedValue가 null이 아닌지 확인
                if (comboBox1.SelectedValue != null)
                {
                    comboBox1.Items.Add("Tomato Juice");
                    ComboBoxItem item = comboBox1.SelectedValue as ComboBoxItem;

                    // item이 null이 아닌지 확인 (올바르게 캐스팅되었는지 확인)
                    if (item != null)
                    {
                        string item_name = item.Content.ToString();

                        // SelectedItem이 null이 아닌지 확인
                        if (comboBox1.SelectedItem != null)
                        {
                            comboBox1.Items.Remove(comboBox1.SelectedItem);
                        }
                        else
                        {
                            // SelectedItem이 null인 경우 처리
                            MessageBox.Show("선택된 항목이 없습니다.");
                        }
                    }
                    else
                    {
                        // item이 null인 경우 처리 (캐스팅 실패)
                        MessageBox.Show("선택된 항목을 처리할 수 없습니다.");
                    }
                }
                else
                {
                    // SelectedValue가 null인 경우 처리
                    MessageBox.Show("선택된 항목이 없습니다.");
                }
               
            }
            catch (Exception ex)
            {
                // 예외가 발생한 경우 처리
                MessageBox.Show("오류가 발생했습니다: " + ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Add("악어");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //webBrowser11.Navigate("https://www.google.com");
            webBrowser11.CoreWebView2.Navigate("https://www.google.com");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //go 버튼 눌렀을 때 이벤트
        {
            webBrowser11.CoreWebView2.Navigate(addresstextBox.Text);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            webBrowser11.CoreWebView2.GoBack();
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            webBrowser11.CoreWebView2.GoForward();
        }

       

        private void InitializeWebViewSource()
        {
            // TextBox의 텍스트를 WebView2의 Source로 설정
            webBrowser11.Source = new Uri(addresstextBox.Text);
        }

        private void favoriteButton_Click(object sender, RoutedEventArgs e)
        {
            if (addFavoriteButton.IsChecked == true)//add일때
            {
                favoriteListBox.Items.Add(addresstextBox.Text);
            }
            if (loadFavoriteBotton.IsChecked == true)//load일때
            {
                webBrowser11.CoreWebView2.Navigate(favoriteListBox.SelectedItem.ToString());
            }
        }
    }
}