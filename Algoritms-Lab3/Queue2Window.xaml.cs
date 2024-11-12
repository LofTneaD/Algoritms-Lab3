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
                    queue.Enqueue(command);
                    Output.AppendText("\nДобавлен: " + command);
                }
                else 
                {
                    switch (commands[i])
                    {
                        case "2"://Pop
                            object pop = queue.Dequeue(); // удаляем
                            if (pop == null)
                            {
                                Output.AppendText("\nОчередь пуста");
                            }
                            else
                            {
                                Output.AppendText("\nВынесено: " + pop);
                            }
                            break;

                        case "3"://Top
                            if (queue.Count != 0)
                            {
                                object top = queue.Peek(); // глянуть верхний
                                if (top == null)
                                    Output.AppendText("\nОчередь пуста");
                                else
                                    Output.AppendText("\nВерхний элемент: " + top);
                            }
                            else
                            {
                                Output.AppendText("\nОчередь пуста");
                            }
                            break;

                        case "4"://isEmpty
                            if (queue.Count == 0)
                            {
                                Output.AppendText("\n Очередь пуста");

                            }
                            else
                            {
                                Output.AppendText("\n Очередь НЕ пуста");
                            }
                            break;
                        case "5"://Print
                            if (queue.Count > 0)
                            {
                                Output.Text += "\n Элементы очереди: " + string.Join(", ", queue);
                            }
                            else
                            {
                                Output.Text += "\n Очередь пуста";
                            }
                            break;
                        default:
                            Output.AppendText($"\nНеизвестная команда: {commands[i]}");
                            break;
                    }
                }                
            }
        }
}