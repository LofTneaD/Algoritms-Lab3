using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algoritms_Lab3
{
    /// <summary>
    /// Логика взаимодействия для StackWindow.xaml
    /// </summary>
    public partial class StackWindow : Window
    {
        public StackWindow()
        {
            InitializeComponent();
        }

        private void PushButton_Click(object sender, RoutedEventArgs e)
        {
            PushInputPanel.Visibility = Visibility.Visible;
            PushInputBox.Focus();
        }
        private void ConfirmPushButton_Click(object sender, RoutedEventArgs e)
        {
            string input = PushInputBox.Text.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                Stack.Push(input);
                ResultTextBox.AppendText("Добавлен: " + input + "\n");
            }

            PushInputBox.Clear();
            PushInputPanel.Visibility = Visibility.Collapsed;
        }

        private void PopButton_Click(object sender, RoutedEventArgs e)
        {
            object pop = Stack.Pop();
            if (pop == null)
            {
                ResultTextBox.AppendText("Стек пуст" + "\n");
            }
            else 
            {
                ResultTextBox.AppendText("Вынесено: " + pop + "\n");
            }            
        }

        private void TopButton_Click(object sender, RoutedEventArgs e)
        {
            object top = Stack.Top();
            if (top == null)
            {
                ResultTextBox.AppendText("Стек пуст" + "\n");
            }
            else
            {
                ResultTextBox.AppendText("Верхний элемент: " + top + "\n");
            }
        }

        private void isEmptyButton_Click(object sender, RoutedEventArgs e)
        {
            bool empty = Stack.IsEmpty();
            if (empty)
            {
                ResultTextBox.AppendText("Стек пуст" + "\n");
            }
            else
            {
                ResultTextBox.AppendText("Стек не пуст" + "\n");
            }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            List<object> stack = Stack.Print();            
            for (int i = stack.Count - 1; i >= 0; i--) 
            {
                ResultTextBox.AppendText(stack[i] + "\n");
            }
        }

        private void MeasureButton_Click(object sender, RoutedEventArgs e)
        {
            MeasureInputPanel.Visibility = Visibility.Visible;
            MeasureInputBox.Focus();
        }
        private void ConfirmMeasureButton_Click(object sender, RoutedEventArgs e) /////<<<----
        {
            int.TryParse(MeasureInputBox.Text.Trim(), out int input);

            double[] time = new double[input];
            Stopwatch stopwatch = new Stopwatch();

            MeasureInputBox.Clear();
            MeasureInputPanel.Visibility = Visibility.Collapsed;

            string[][] commands = CommandGenerator.MakeMassives(input);

            for (int i = 0; i < input; i++)
            {
                double totalTime = 0;

                for (int j = 0; j < 5; j++)
                {
                    stopwatch.Restart();

                    ExecuteCommands(commands[i]);

                    stopwatch.Stop();

                    totalTime += stopwatch.Elapsed.TotalMilliseconds;
                }
                time[i] = totalTime / 5;
            }
            SaveResultsToFile(time);
        }
        public static void SaveResultsToFile(double[] results)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();


            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Results to File";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "results.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (double line in results)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

            private void MeasureFileButton_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

                stopwatch.Start();
                string[] commands = File.ReadAllText(openFileDialog.FileName).Split(' ');
                ExecuteCommands(commands);
            }
            stopwatch.Stop();
            ResultTextBox.AppendText("Execution time: " + stopwatch.Elapsed.TotalMilliseconds + " ms\n");
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string[] commands = File.ReadAllText(openFileDialog.FileName).Split(' ');
                ExecuteCommands(commands);
            }
        }

        private void InfixToPostfixButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string[] commands = File.ReadAllText(openFileDialog.FileName).Split(' ');
                ResultTextBox.AppendText("Постфиксная запись " + ConvertToPostfix(File.ReadAllText(openFileDialog.FileName)) + "\n");
            }            
        }

        void ExecuteCommands(string[] commands)
        {
            ResultTextBox.Clear();

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i].Length > 1)//Push
                {
                    string command = commands[i].Substring(2);
                    Stack.Push(command);
                    ResultTextBox.AppendText("Добавлен: " + command + "\n");
                }
                else 
                {
                    switch (commands[i])
                    {
                        case "2"://Pop
                            object pop = Stack.Pop();
                            if (pop == null)
                            {
                                ResultTextBox.AppendText("Стек пуст" + "\n");
                            }
                            else
                            {
                                ResultTextBox.AppendText("Вынесено: " + pop + "\n");
                            }
                            break;

                        case "3"://Top
                            object top = Stack.Top();
                            if (top == null)
                                ResultTextBox.AppendText("Стек пуст" + "\n");
                            else
                                ResultTextBox.AppendText("Верхний элемент: " + top + "\n");
                            break;

                        case "4"://isEmpty
                            bool empty = Stack.IsEmpty();
                            if (empty)
                                ResultTextBox.AppendText("Стек пуст" + "\n");
                            else
                                ResultTextBox.AppendText("Стек не пуст" + "\n");
                            break;

                        case "5"://Print
                            Stack.Print();
                            List<object> stack = Stack.Print();
                            for (int j = stack.Count - 1; j >= 0; j--)
                            {
                                ResultTextBox.AppendText(stack[j] + "\n");
                            }
                            break;

                        default:
                            ResultTextBox.AppendText($"Неизвестная команда: {commands[i]}\n");
                            break;
                    }
                }                
            }
        }

        private void CalculationButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string[] tokens = File.ReadAllText(openFileDialog.FileName).Split(' ');
                Calculation(tokens);
            }
        }

        void Calculation(string[] tokens)
        {            
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number)) // Число
                {
                    Stack.Push(number);
                }
                else // Оператор
                {
                    switch (token)
                    {
                        case "+":
                            Stack.Push((int)Stack.Pop() + (int)Stack.Pop());
                            break;
                        case "-":
                            {
                                int b = (int)Stack.Pop();
                                int a = (int)Stack.Pop();
                                Stack.Push(a - b);
                            }
                            break;
                        case "*":
                            Stack.Push((int)Stack.Pop() * (int)Stack.Pop());
                            break;
                        case "/":
                            {
                                int b = (int)Stack.Pop();
                                int a = (int)Stack.Pop();
                                Stack.Push(a / b);
                            }
                            break;
                        case "^":
                            {
                                int b = (int)Stack.Pop();
                                int a = (int)Stack.Pop();
                                Stack.Push(Math.Pow(a, b));
                            }
                            break;
                        case "ln":
                            Stack.Push(Math.Log((int)Stack.Pop()));
                            break;
                        case "cos":
                            Stack.Push(Math.Cos((int)Stack.Pop()));
                            break;
                        case "sin":
                            Stack.Push(Math.Sin((int)Stack.Pop()));
                            break;
                        case "sqrt":
                            Stack.Push(Math.Sqrt((int)Stack.Pop()));
                            break;
                        default:
                            ResultTextBox.AppendText("Неизвестная операция: " + token + "\n");
                            break;
                    }
                }
            }
        }


        static int GetPrecedence(char op)
        {
            return op == '+' || op == '-' ? 1 : op == '*' || op == '/' ? 2 : 0;
        }
        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
        public static string ConvertToPostfix(string infix)
        {
            List<string> output = new List<string>();

            for (int i = 0; i < infix.Length; i++)
            {
                char token = infix[i];

                // Если токен — цифра, добавляем его в выходной список
                if (char.IsDigit(token))
                {
                    string number = token.ToString();
                    while (i + 1 < infix.Length && char.IsDigit(infix[i + 1]))
                    {
                        number += infix[++i];
                    }
                    output.Add(number);
                }
                // Если токен — оператор
                else if (IsOperator(token))
                {
                    while (!Stack.IsEmpty() && IsOperator((char)Stack.Top()) &&
                           GetPrecedence((char)Stack.Top()) >= GetPrecedence(token))
                    {
                        output.Add(Stack.Pop().ToString());
                    }
                    Stack.Push(token);
                }
                // Если токен — открывающая скобка
                else if (token == '(')
                {
                    Stack.Push(token);
                }
                // Если токен — закрывающая скобка
                else if (token == ')')
                {
                    while (!Stack.IsEmpty() && (char)Stack.Top() != '(')
                    {
                        output.Add(Stack.Pop().ToString());
                    }
                    Stack.Pop(); // Удаляем '(' из стека
                }
            }

            // Переносим все оставшиеся операторы из стека в выходной список
            while (!Stack.IsEmpty())
            {
                output.Add(Stack.Pop().ToString());
            }

            return string.Join(" ", output);
        }

        
    }
}
