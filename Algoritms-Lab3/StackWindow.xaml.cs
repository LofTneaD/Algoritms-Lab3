using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        }

        private void ExecuteCommands(string[] commands)
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
    }
}
