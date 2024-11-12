using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Algoritms_Lab3;

public partial class Queue2Window : Window
{
    private Queue<object> queue = new Queue<object>();
    
    public Queue2Window()
    {
        InitializeComponent();
        
    }
    // Добавление элемента
    private void Add_Click(object sender, RoutedEventArgs e)
    {
        object value = InputValue.Text;
        queue.Enqueue(value); // Добавляем в очередь
        Output.Text += $"\n Элемент {value} добавлен в очередь."; // Обновляем текст
        InputValue.Clear(); // Очищаем поле ввода

    }

// Удаление элемента
    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        if (queue.Count > 0)
        {
            object removedItem = queue.Dequeue(); // Удаляем первый элемент
            Output.Text += $"\n Удалён элемент: {removedItem}.";
        }
        else
        {
            Output.Text += "\n Очередь пуста!";
        }
    }

// Просмотр первого элемента
    private void Peek_Click(object sender, RoutedEventArgs e)
    {
        if (queue.Count > 0)
        {
            object firstItem = queue.Peek(); // Получаем первый элемент
            Output.Text += $"\n Первый элемент в очереди: {firstItem.ToString()}.";
        }
        else
        {
            Output.Text += "\n Очередь пуста!";
        }
    }

// Печать всех элементов очереди
    private void Print_Click(object sender, RoutedEventArgs e)
    {
        if (queue.Count > 0)
        {
            Output.Text += "\n Элементы очереди: " + string.Join(", ", queue);
        }
        else
        {
            Output.Text += "\n Очередь пуста!";
        }
    }

    private void isEmpty_Click(object sender, RoutedEventArgs e)
    {
        if (queue.Count == 0)
        {
            Output.AppendText("\n Очередь пуста");
        }
        else
        {
            Output.AppendText("\n Очередь НЕ пуста");
        }
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

        void ExecuteCommands(string[] commands)
        {
            Output.Clear();

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i].Length > 1)//Push
                {
                    string command = commands[i].Substring(2);
                    Stack.Push(command);
                    Output.AppendText("Добавлен: " + command + "\n");
                }
                else 
                {
                    switch (commands[i])
                    {
                        case "2"://Pop
                            object pop = Stack.Pop();
                            if (pop == null)
                            {
                                Output.AppendText("Очередь пуста" + "\n");
                            }
                            else
                            {
                                Output.AppendText("Вынесено: " + pop + "\n");
                            }
                            break;

                        case "3"://Top
                            object top = Stack.Top();
                            if (top == null)
                                Output.AppendText("Очередь пуста" + "\n");
                            else
                                Output.AppendText("Верхний элемент: " + top + "\n");
                            break;

                        case "4"://isEmpty
                            bool empty = Stack.IsEmpty();
                            if (empty)
                                Output.AppendText("Очередь пуста" + "\n");
                            else
                                Output.AppendText("Очередь НЕ пуста" + "\n");
                            break;

                        case "5"://Print
                            Stack.Print();
                            List<object> stack = Stack.Print();
                            for (int j = stack.Count - 1; j >= 0; j--)
                            {
                                Output.AppendText(stack[j] + "\n");
                            }
                            break;

                        default:
                            Output.AppendText($"Неизвестная команда: {commands[i]}\n");
                            break;
                    }
                }                
            }
        }
}