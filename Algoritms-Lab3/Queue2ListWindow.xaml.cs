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
}