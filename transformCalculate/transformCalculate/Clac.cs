using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace transformCalculate
{
    internal class Clac
    {
        private MainWindow form;
        public Clac(MainWindow formInstance)
        {
            form = formInstance;
        }


        public double getResult() // 계산하는 함수
        {
            bool listEmpty = true;
            List<double> numberList = new List<double>();
            List<string> operationList = new List<string>();
            string recordFrom = form.record;

            Console.WriteLine("getResult에 들어간 record : " + recordFrom);

            string[] resultArray = recordFrom.Split('@');

            foreach (string result in resultArray)
            {
                // 숫자와 연산자가 혼합된 경우 처리
                string tempNumber = "";
                bool isNegative = false;

                foreach (char c in result)
                {
                    if (char.IsDigit(c) || c == '.')
                    {
                        tempNumber += c;
                    }
                    else if (c == '~')
                    {
                        // ~을 만난 경우 다음 숫자는 음수로 변환
                        isNegative = true;
                    }
                    else
                    {
                        // tempNumber가 비어있지 않은 경우 숫자로 변환하여 numberList에 추가
                        if (!string.IsNullOrEmpty(tempNumber))
                        {
                            double number = double.Parse(tempNumber);
                            if (isNegative)
                            {
                                number = -number;
                                isNegative = false; // 음수 플래그 초기화
                            }
                            numberList.Add(number);
                            tempNumber = ""; // 초기화
                        }
                        // 연산자를 operationList에 추가
                        operationList.Add(c.ToString());
                    }
                }
                // 남아있는 숫자가 있는 경우 numberList에 추가
                if (!string.IsNullOrEmpty(tempNumber))
                {
                    double number = double.Parse(tempNumber);
                    if (isNegative)
                    {
                        number = -number;
                    }
                    numberList.Add(number);
                }

                Console.WriteLine("isNegative 상태 : " + isNegative);

            }

            // 숫자 리스트 출력
            foreach (double number in numberList)
            {
                Console.WriteLine(number + "\r\n여기는 숫자 리스트 목록입니다.\r\n");
            }
            while (listEmpty)
            {
                // 연산자 리스트 출력
                for (int i = 0; i < operationList.Count; i++)
                {
                    string operation = operationList[i];
                    Console.WriteLine(operation + "\r\n여기는 연산자 리스트 목록입니다.\r\n");

                    double result = 0;

                    if (operation == "*" || operation == "/" || operation == "%")
                    {
                        switch (operation)
                        {
                            case "*":
                                result = numberList[i] * numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            case "/":
                                result = numberList[i] / numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            case "%":
                                result = numberList[i] % numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            default:
                                Console.WriteLine("*/% 전용 연산 로직 연산 끝");
                                break;
                        }
                    }
                }

                for (int i = 0; i < operationList.Count; i++)
                {
                    string operation = operationList[0];
                    double result = 0;
                    switch (operation)
                    {
                        case "+":
                            result = numberList[0] + numberList[1];
                            numberList[0] = result;
                            numberList.RemoveAt(1);
                            operationList.RemoveAt(0);
                            break;
                        case "-":
                            result = numberList[0] - numberList[1];
                            numberList[0] = result;
                            numberList.RemoveAt(1);
                            operationList.RemoveAt(0);
                            break;
                        default:
                            Console.WriteLine("*/% 전용 연산 로직에 문제가 생김");
                            break;
                    }
                }

                if (operationList.Count == 0)
                {
                    listEmpty = false;
                }
            }//end of while문

            double finalResult = numberList[0];

            Console.WriteLine(finalResult + "이게 최종 연산 결과다!");
            recordFrom = "0";
            return finalResult;
        }//end of getResult method

        // 음수의 -를 ~로 대체하는 메서드
        public string ReplaceNegativeSign(double number)
        {
            if (number < 0)
            {
                return "~" + Math.Abs(number);
            }
            return number.ToString();
        }


        public string[] history(string record)//계산할 때마다 result값이 history 배열로 들어가게 하는 함수
        {
            Console.WriteLine("history 메서드에 입장~");
            string[] history = form.historyArray;
            if (history.Length == 5 && IsArrayFullyPopulated(history))
            {

                Console.WriteLine("삭제 전 배열:");
                PrintArray(history);

                // 배열의 첫 번째 요소를 삭제
                history = RemoveFirstElement(history);

                Console.WriteLine("삭제 후 배열:");
                PrintArray(history);
            }

            history = AppendToLastElement(record, history);

            foreach (string item in history)
            {
                Console.WriteLine($"{item}" + "history 배열에 들어간 요소들");
            }
            Console.WriteLine("history 메서드가 지난 후 history라는 array의 길이 : " + history.Length);
            return history;

            string[] RemoveFirstElement(string[] array)//array[0]을 삭제하는 메서드
            {
                if (array.Length == 0)
                {
                    throw new InvalidOperationException("배열이 비어 있습니다.");
                }

                for (int i = 1; i < array.Length; i++)
                {
                    array[i - 1] = array[i];
                }

                // 마지막 인덱스를 null 또는 기본 값으로 설정
                array[array.Length - 1] = null;

                return array;
            }

            void PrintArray(string[] array)//배열의 요소들을 출력하는 메서드
            {
                foreach (string item in array)
                {
                    Console.WriteLine(item + " ");
                }
                Console.WriteLine();
            }

        }

        public string[] AppendToLastElement(string result, string[] history) //배열의 마지막 요소에 문자열 추가하는 메서드
        {
            for (int i = 0; i < history.Length; i++)
            {
                if (string.IsNullOrEmpty(history[i]))
                {
                    history[i] = result;
                    return history;
                }
            }
            return history;
        }

        public string deleteLastElement(string element) // 한글자씩 지우기에 대한 로직
        {


            Console.WriteLine($"{element}" + "한글자 지우기 element와 result");

            if (string.IsNullOrEmpty(element))
            {
                return element;
            }

            // 문자열을 문자 배열로 변환
            char[] charArray = element.ToCharArray();

            // 마지막 요소를 제거한 새로운 문자 배열 생성
            char[] newArray = new char[charArray.Length - 1];
            Array.Copy(charArray, newArray, charArray.Length - 1);

            // 새로운 문자 배열을 문자열로 변환
            string result = new string(newArray);

            // 변환된 문자열의 마지막 요소가 '@'인 경우 '@'도 제거
            if (result.EndsWith("@"))
            {
                result = result.Remove(result.Length - 1);
            }

            return result;
        }

        public void showHistory(string[] historyArray)
        {
            foreach (string item in historyArray)
            {
                Console.WriteLine(item + "history item 목록 ");
            }
        }

        bool IsArrayFullyPopulated(string[] array)//배열에 있는 모든 인덱스가 차있는지 확인하는 메서드
        {
            foreach (var element in array)
            {
                if (element == null)
                {
                    return false;
                }
            }
            return true;
        }

        public string zeroCheck(string input)
        {

            // 입력된 문자열이 null 또는 빈 문자열인 경우 그대로 반환
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            Console.WriteLine(input.Substring(1) + "\r\nsubstring(1)한 결과");

            // 첫 번째 문자가 '0'인 경우
            if (input[0] == '0')
            {
                // 첫 번째 문자를 제외한 나머지 문자열을 반환
                return input.Substring(1);
            }

            // 그 외의 경우에는 입력된 문자열 그대로 반환
            return input;

        }

        public string addMinus(string num)//+/- 로직
        {
            String noZero = zeroCheck(num);
            string result = ModifyLastNumber(noZero);
            Console.WriteLine(result + "~를 붙인 결과");
            return result;
        }

        static string ModifyLastNumber(string input)
        {
            {
                // 연산자들이 포함되어 있는지 확인
                string operators = "+-*/%";
                bool hasOperator = false;
                foreach (char c in operators)
                {
                    if (input.Contains(c))
                    {
                        hasOperator = true;
                        break;
                    }
                }

                // 연산자가 없는 경우
                if (!hasOperator)
                {
                    // 만약 이미 '~'가 있다면 제거, 없다면 '~' 추가
                    if (input.EndsWith("~"))
                    {
                        return input.Substring(1);
                    }
                    else
                    {
                        return "~" + input;
                    }
                }
                else
                {
                    // 연산자가 있는 경우 기존 로직 수행
                    // 정규 표현식을 사용하여 '~'이 붙어 있는 마지막 숫자를 찾기
                    string patternWithTilde = @"~(\d+)(?!.*\d)";
                    // 정규 표현식을 사용하여 '~'이 없는 마지막 숫자를 찾기
                    string patternWithoutTilde = @"(\d+)(?!.*\d)";

                    // 기존에 '~'이 붙어 있는 경우 '~'을 제거
                    if (Regex.IsMatch(input, patternWithTilde))
                    {
                        string result = Regex.Replace(input, patternWithTilde, "$1");
                        return result;
                    }
                    else
                    {
                        // '~'이 없는 경우 '~'을 추가
                        string result = Regex.Replace(input, patternWithoutTilde, "~$1");
                        return result;
                    }
                }
            }
        }


        public string addMinusHistory(string input1)
        {
            string input = zeroCheck(input1);

            // 연산자들이 포함되어 있는지 확인
            string operators = "+-*/%";
            bool hasOperator = false;
            foreach (char c in operators)
            {
                if (input.Contains(c))
                {
                    hasOperator = true;
                    break;
                }
            }

            // 연산자가 없는 경우
            if (!hasOperator)
            {
                // 만약 이미 (-)가 있다면 괄호와 -를 제거, 없다면 괄호와 -를 추가
                if (input.StartsWith("(-") && input.EndsWith(")"))
                {
                    return input.Substring(2, input.Length - 3);
                }
                else
                {
                    return $"(-{input})";
                }
            }
            else
            {
                // 연산자가 있는 경우 기존 로직 수행
                // 정규 표현식을 사용하여 (-숫자) 형태의 마지막 숫자를 찾기
                string patternWithNegative = @"\(-(\d+)\)(?!.*\d)";
                // 정규 표현식을 사용하여 (-숫자)가 아닌 마지막 숫자를 찾기
                string patternWithoutNegative = @"(\d+)(?!.*\d)";

                // 기존에 (-숫자) 형태가 있는 경우 이를 제거
                if (Regex.IsMatch(input, patternWithNegative))
                {
                    string result = Regex.Replace(input, patternWithNegative, "$1");
                    return result;
                }
                else
                {
                    // (-숫자) 형태가 없는 경우 이를 추가
                    string result = Regex.Replace(input, patternWithoutNegative, "(-$1)");
                    return result;
                }
            }
        }

        public List<string> LoadArrayFromFile(string filePath)
        {
            List<string> loadedList = new List<string>();

            if (File.Exists(filePath))
            {
                loadedList = File.ReadAllLines(filePath).ToList();
            }
            else
            {
                // 파일이 없으면 빈 리스트 반환
                loadedList = new List<string>();
            }

            return loadedList;
        }

        public string structTextBox(double a, string op, double y) => a.ToString() + op + y.ToString();
    }
}
