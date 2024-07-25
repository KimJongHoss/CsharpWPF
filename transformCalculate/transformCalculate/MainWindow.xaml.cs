using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace transformCalculate
{
    public partial class MainWindow : Window
    {
        bool solveCheck = false;
        public string record = "0";
        public string historyRecord = "0";
        public string[] historyArray = new string[5];
        private List<string> historyList;
        private Clac calculator;
        private string filePath;
        private int result;

        struct historyStruct
        {
            public double x;
            public string operate;
            public double y;
        }

        public MainWindow()
        {
            InitializeComponent();
            textInput.Text = record;
            calculator = new Clac(this);

            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopFolder, "jongho");
            Directory.CreateDirectory(folderPath);
            filePath = Path.Combine(folderPath, "history.txt");

            List<string> startList = calculator.LoadArrayFromFile(filePath);
            foreach (string item in startList)
            {
                pastHistory.Items.Add(item);
                Console.WriteLine("프로그램 시작시 startList의 아이템들 : " + item);
            }

            historyList = new List<string>();

           
           

            historyArray = new string[5];
           

            Console.WriteLine("프로그램이 시작되자마자 historyArray의 길이 : " + historyArray.Length);

            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private bool newButton;
        private char myOperator;

        // 알파벳 문자와 숫자, 백스페이스, 특수 연산자만 허용
            private void textResult_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                // 숫자와 백스페이스, 특수 연산자만 허용
                if (!char.IsControl(e.Text, 0) && !char.IsDigit(e.Text, 0) &&
                    (e.Text != "+" && e.Text != "-" && e.Text != "*" && e.Text != "/" && e.Text != "%"))
                {
                    e.Handled = true; // 처리된 이벤트로 표시
                }
            }


        private void textResult_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsControl((char)e.Key) && !char.IsDigit((char)e.Key))
            {
                e.Handled = true;
            }
        }

        private char checkLastChar(string record)
        {
            char lastChar = '0';
            if (record.Length > 0)
            {
                lastChar = record[record.Length - 1];
                Console.WriteLine(lastChar);
            }
            return lastChar;
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!solveCheck)
            {
                Button btn = sender as Button;

                if (textInput.Text == "0" || newButton)
                {
                    textInput.Text = btn.Content.ToString();
                    newButton = false;
                }
                else
                {
                    textInput.Text += btn.Content.ToString();
                }
                record += btn.Content.ToString();
                historyRecord += btn.Content.ToString();
                Console.WriteLine("btn 숫자 버튼 클릭 이벤트 : " + btn.Content);
                Console.WriteLine("숫자 버튼 클릭 이후 record 값 : " + record);
            }

            FormatNumber();

            btnPlus.IsEnabled = true;
            btnMinus.IsEnabled = true;
            btnMultiply.IsEnabled = true;
            btnDivide.IsEnabled = true;
            btnMod.IsEnabled = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (textInput.Text.Length > 0)
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                if (textInput.Text.Length == 0)
                {
                    textInput.Text = "0";
                    solveCheck = false;
                }
            }

            if (record.Length > 0)
            {
                record = calculator.deleteLastElement(record);
                Console.WriteLine(record + "record 한글자 지운 결과\r\n");
                historyRecord = calculator.deleteLastElement(historyRecord);
                Console.WriteLine("historyRecord 한글자 지운 결과\r\n");
                Console.WriteLine($"{historyRecord}");
            }

            btnPlus.IsEnabled = record.Length > 0;
            btnMinus.IsEnabled = record.Length > 0;
            btnMultiply.IsEnabled = record.Length > 0;
            btnDivide.IsEnabled = record.Length > 0;
            btnMod.IsEnabled = record.Length > 0;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textInput.Text = "0";
            textResult.Text = "";
            textProcess.Text = "";
            record = "0";
            historyRecord = "0";
            solveCheck = false;
            btnPlus.IsEnabled = true;
            btnMinus.IsEnabled = true;
            btnMultiply.IsEnabled = true;
            btnDivide.IsEnabled = true;
            btnMod.IsEnabled = true;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "+";
                StringBuilder sb = new StringBuilder(record);
                sb.Length -= 2;
                record += "@+";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "+";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "+";
                record += "@+";
                historyRecord += "+";
            }

            newButton = true;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "-";
                StringBuilder sb = new StringBuilder(record);
                sb.Length -= 2;
                record += "@-";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "-";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "-";
                record += "@-";
                historyRecord += "-";
            }

            newButton = true;
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "*";
                StringBuilder sb = new StringBuilder(record);
                sb.Length -= 2;
                record += "@*";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "*";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "*";
                record += "@*";
                historyRecord += "*";
            }

            newButton = true;
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "/";
                StringBuilder sb = new StringBuilder(record);
                sb.Length -= 2;
                record += "@/";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "/";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "/";
                record += "@/";
                historyRecord += "/";
            }

            newButton = true;
        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "%";
                StringBuilder sb = new StringBuilder(record);
                sb.Length -= 2;
                record += "@%";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "%";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "%";
                record += "@%";
                historyRecord += "%";
            }

            newButton = true;
        }

      

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            // TODO: 계산 기능 구현
            solveCheck = true;
        }

        private void btnLoadHistory_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Load history");
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                pastHistory.Items.Add(line);
            }
       
        }

      

        private void OnProcessExit(object sender, EventArgs e)
        {
            foreach (string item in historyList)
            {
                Console.WriteLine("historyList에 있는 값들: " + item);
            }

            if (File.Exists(filePath))
            {
                // 파일이 이미 존재하면 기존 파일에 추가
                File.AppendAllLines(filePath, historyList);
            }
            else
            {
                // 파일이 없으면 새로 생성하여 기록
                File.WriteAllLines(filePath, historyList);
            }

            Console.WriteLine("프로그램이 종료됩니다. historyList가 파일에 저장되었습니다.");
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            // 버튼 클릭 시 실행될 코드
            if (!textInput.Text.Contains("."))
            {
                textInput.Text += ".";
            }
        }

        private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            // 버튼 클릭 시 실행될 코드
            if (textInput.Text.Length > 0)
            {
                // 현재 입력된 숫자의 부호를 변경합니다.
                if (textInput.Text.StartsWith("-"))
                {
                    textInput.Text = textInput.Text.Substring(1);
                }
                else
                {
                    textInput.Text = "-" + textInput.Text;
                }
            }
        }

        private string FormatNumber(double number)
        {
            // 소수점이 없는 경우 정수 형태로 반환, 소수점이 있는 경우 소수점까지 포함하여 반환
            if (number == Math.Floor(number))
            {
                return string.Format("{0:N0}", number); // 소수점이 없는 경우
            }
            else
            {
                return string.Format("{0:N}", number); // 소수점이 있는 경우
            }
        }

        private bool IsDivideByZero(string record)
        {
            // 수식을 연산자 기준으로 분리하여 분할
            string[] parts = record.Split('@');

            // 분할된 각 부분에 대해 검사
            foreach (string part in parts)
            {
                // 나눗셈 연산이 포함되어 있는 경우
                if (part.Contains("/"))
                {
                    // 연산자를 기준으로 분리하여 오른쪽 피연산자가 0인지 확인
                    string[] operands = part.Split('/');
                    if (operands.Length == 2 && operands[1] == "0")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string GetCalculationProcess(string record)
        {
            StringBuilder sb = new StringBuilder();
            bool lastWasOperator = true; // 직전에 처리한 문자가 연산자였는지 여부
            StringBuilder numberBuffer = new StringBuilder(); // 숫자를 임시로 저장하는 버퍼

            for (int i = 0; i < record.Length; i++)
            {
                char c = record[i];
                if (char.IsDigit(c))
                {
                    numberBuffer.Append(c); // 숫자를 버퍼에 추가
                    lastWasOperator = false; // 숫자 추가했으므로 연산자 플래그를 false로 설정
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%')
                {
                    if (numberBuffer.Length > 0)
                    {
                        // 숫자가 버퍼에 있다면, 포맷하고 결과 문자열에 추가
                     
                        numberBuffer.Clear(); // 버퍼 초기화
                    }
                    // 연산자가 연속으로 오는 경우를 방지
                    if (!lastWasOperator)
                    {
                        sb.Append($" {c} "); // 연산자 추가하고 연산자 양 옆에 공백 추가
                    }
                    lastWasOperator = true; // 연산자 추가했으므로 연산자 플래그를 true로 설정
                }
                else
                {
                    // 알 수 없는 문자 처리 (필요시)
                    // throw new ArgumentException($"Unexpected character: {c}");
                }
            }

            // 루프가 끝난 후에도 숫자가 버퍼에 남아있다면, 포맷하고 결과 문자열에 추가
            if (numberBuffer.Length > 0)
            {
               
            }

            return sb.ToString().Trim(); // 문자열의 앞뒤 공백 제거 후 반환
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("btnEqual_Click 눌렀을 때 history 배열의 크기" + historyArray.Length);
            // 0으로 나누기를 체크하는 부분 추가
            if (IsDivideByZero(record))
            {
                MessageBox.Show("0으로 나눌 수 없습니다", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            double finalResult = calculator.getResult();
            Console.WriteLine("계산 직후 finalResult 값 : " + finalResult);

            //string stringResult = FormatNumber(finalResult);
            // 정수 부분만 추출하여 문자열로 변환
            string stringResult = ((int)finalResult).ToString();


            // 결과를 textResult에 표시하고 포맷팅
            textResult.Text = FormatNumber(finalResult);
            //this.result = Convert.ToInt32(textResult.Text.Substring(0, textResult.Text.IndexOf('.')));
            //textResult.Text = stringResult;
            this.result = Convert.ToInt32(stringResult);


            // 계산 과정 문자열 준비
            string calculationProcess = GetCalculationProcess(historyRecord);

            // textProcess에 계산 과정 표시
            textProcess.Text = calculationProcess + " = " + textResult.Text;

            Console.WriteLine("finalResult 음수 확인 직전" + finalResult);
            // 계산 완료 후 계산 기록 초기화
            if (finalResult < 0) // 결과값이 음수일 경우
            {
                record = calculator.ReplaceNegativeSign(finalResult);
                Console.WriteLine("음수 추가 후 record : " + record);
            }
            else
            {
                record = finalResult.ToString();
            }

            historyRecord = calculator.zeroCheck(historyRecord) + " = " + textResult.Text;
            historyList.Add(historyRecord);
            Console.WriteLine("=버튼을 눌렀을 때 연산 후 historyRecord에 들어간 값 : " + historyRecord);
            historyArray = calculator.history(historyRecord);
            Console.WriteLine("=버튼을 눌렀을 때 연산 후 historyArray에 들어간 값" + historyArray[0]);
            historyRecord = finalResult.ToString();

            // solveCheck 설정
            solveCheck = true;
        }

       

        private void FormatNumber()
        {
            if (textInput.Text.Length > 12)
            {
                textInput.Text = textInput.Text.Substring(0, 12);
            }
        }
    }
}
