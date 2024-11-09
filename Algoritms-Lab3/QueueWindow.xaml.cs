using System.Windows;

namespace Algoritms_Lab3;

public partial class QueueWindow : Window
{
    public QueueWindow()
    {
        InitializeComponent();
        _items = new List<object>();
    }
    
    private List<object> _items; // Хранение элементов очереди
    
    // Вставка элемента
    public void Enqueue(object item)
    {
        _items.Add(item); // Добавление в конец списка
    }

    // Удаление элемента
    public object Dequeue()
    {
        if (IsEmpty())
        {
            throw new System.InvalidOperationException("Очередь пуста!");
        }

        object value = _items[0]; // Получаем первый элемент
        _items.RemoveAt(0);    // Удаляем его
        return value;
    }

    // Проверка на пустоту
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    // Получение первого элемента
    public object Peek()
    {
        if (IsEmpty())
        {
            throw new System.InvalidOperationException("Очередь пуста!");
        }

        return _items[0];
    }

    // Печать элементов очереди
    public string Print()
    {
        return string.Join(", ", _items); // Возвращаем строку со всеми элементами
    }
    
}