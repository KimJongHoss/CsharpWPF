using Microsoft.Win32;
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
using System.Windows.Shapes;


namespace DataGridPrac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Data> datas = new List<Data>();
        public MainWindow()
        {
            InitializeComponent();

        }

        public class Data
        {
            public string name { get; set; }
            public string age { get; set; }
            public string explain { get; set; }
        }

        private void fileOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "CSV 파일 (*.csv)|*.csv|모든 파일 (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFile = openFileDialog.FileNames[0];
                try
                {
                    using (StreamReader sr = new StreamReader(selectedFile))
                    {
                        // 첫 줄은 헤더일 가능성이 있으므로 읽어오지 않거나 스킵할 수 있습니다.
                        string headerLine = sr.ReadLine();

                        while (!sr.EndOfStream)
                        {
                            // 한 줄씩 읽어온다.
                            string line = sr.ReadLine();

                            // 쉼표( , )를 기준으로 데이터를 분리한다.
                            string[] columns = line.Split(',');

                            // 데이터 모델에 매핑하여 리스트에 추가한다.
                            if (columns.Length >= 3) // 데이터 열이 충분한지 확인
                            {
                                Data data = new Data
                                {
                                    name = columns[0],
                                    age = columns[1],
                                    explain = columns[2]
                                };

                                datas.Add(data);
                            }
                        }
                        foreach (Data data in datas)
                        {
                            Console.WriteLine(data.name);
                        }
                        dataGrid1.ItemsSource = datas;
                        filePathLabel.Content = openFileDialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("파일을 읽는 중 오류가 발생했습니다: " + ex.Message);
                }
            }
        }

        private void getDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItems.Count == 0)
            {
                MessageBox.Show("항목을 선택 후 버튼을 눌러주세요");
                return;
            }

            string names = string.Empty;

            foreach (Data data in dataGrid1.SelectedItems)
            {
                names += data.name + "\r\n";
            }
            MessageBox.Show($"{names}선택됨");
        }
    }
}