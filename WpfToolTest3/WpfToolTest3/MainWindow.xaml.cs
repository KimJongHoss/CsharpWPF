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

namespace WpfToolTest3
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            webBrowser11.CoreWebView2.Navigate(addresstextBox.Text);
        }
    }
}