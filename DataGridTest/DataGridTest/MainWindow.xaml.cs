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

namespace DataGridTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Data> datas = new List<Data>();
            datas.Add(new Data { name = "이지원", id = "210651", major = "컴퓨터공학", grade = 1, etc = "" });
            datas.Add(new Data { name = "김현호", id = "210846", major = "컴퓨터공학", grade = 1, etc = "" });
            datas.Add(new Data { name = "강희진", id = "210781", major = "컴퓨터공학", grade = 1, etc = "" });
            datas.Add(new Data { name = "박서준", id = "210945", major = "컴퓨터공학", grade = 1, etc = "" });
            datas.Add(new Data { name = "강나연", id = "210347", major = "컴퓨터공학", grade = 1, etc = "" });
            StudentList.ItemsSource = datas;
        }

        public class Data
        {
            public string name { get; set; }
            public string id { get; set; }
            public string major { get; set; }
            public int grade { get; set; }  
            public string etc { get; set; }

        }

        private void StudentList_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Data dataRow = (Data)StudentList.DataContext; //if문에서 다 가져와서 안해도됨
            //if (StudentList.SelectedItem is Data data)
            //{
            //    string name = data.name;
            //    MessageBox.Show(name);
            //}
            //else
            //{
            //    MessageBox.Show("학생을 먼저 선택해주세요!");
            //}

            string names = string.Empty;

            foreach (Data data in StudentList.SelectedItems)
            {
                names += data.name + "\r\n";
            }
            MessageBox.Show($"{names}선택됨.");
        }
    }
}