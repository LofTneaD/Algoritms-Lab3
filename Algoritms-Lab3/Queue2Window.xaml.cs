using System.Windows;
using System.Collections.Generic;
using System.Windows;

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

}