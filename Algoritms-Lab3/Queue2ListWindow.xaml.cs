using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Algoritms_Lab3;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

public partial class Queue2ListWindow : Window
{
    public Queue2ListWindow()
    {
        InitializeComponent();
    }
    
    private ListQueue listQueue = new ListQueue();
    private void Add_Click(object sender, RoutedEventArgs e)
    {
        object value = InputValue.Text;
            listQueue.Enqueue(value);
            Output.Text += "\n Элемент добавлен.";
            InputValue.Clear(); // Очищаем поле ввода
    }

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        if (!listQueue.IsEmpty())
        {
            Output.Text += $"\n Удалён элемент: {listQueue.Dequeue()}";
        }
        else
        {
            Output.Text += "\n Очередь пуста!";
        }
    }

    private void Peek_Click(object sender, RoutedEventArgs e)
    {
        if (!listQueue.IsEmpty())
        {
            Output.Text += $"\n Первый элемент: {listQueue.Peek()}";
        }
        else
        {
            Output.Text += "\n Очередь пуста!";
        }
    }

    private void Print_Click(object sender, RoutedEventArgs e)
    {
        Output.Text += "\n Элементы очереди: " + listQueue.Print();
    }
    
    public class ListQueue
    {
        private System.Collections.Generic.List<object> _items = new System.Collections.Generic.List<object>();

        public void Enqueue(object item) => _items.Add(item);
        public object Dequeue()
        {
            var item = _items[0];
            _items.RemoveAt(0);
            return item;
        }

        public object Peek() => _items[0];
        public bool IsEmpty() => _items.Count == 0;
        public string Print() => string.Join(", ", _items);
    }

    private void isEmpty_Click(object sender, RoutedEventArgs e)
    {
        bool empty = listQueue.IsEmpty();
        if (empty)
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
                    listQueue.Enqueue(command);
                    Output.AppendText("\nДобавлен: " + command);
                }
                else 
                {
                    switch (commands[i])
                    {
                        case "2"://Pop
                            object pop = listQueue.Dequeue(); // удаляем
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
                            if (listQueue.IsEmpty())
                            {
                                object top = listQueue.Peek(); // глянуть верхний
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
                            if (listQueue.IsEmpty())
                            {
                                Output.AppendText("\n Очередь пуста");

                            }
                            else
                            {
                                Output.AppendText("\n Очередь НЕ пуста");
                            }
                            break;
                        case "5"://Print
                            if (listQueue.IsEmpty())
                            {
                                Output.Text += "\n Элементы очереди: " + string.Join(", ", listQueue);
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