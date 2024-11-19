using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Algoritms_Lab3
{
    /// <summary>
    /// Логика взаимодействия для NodeWindow.xaml
    /// </summary>
    public partial class NodeWindow : Window
    {
        LinkedList list = new LinkedList();
        public NodeWindow()
        {
            InitializeComponent();
        }

        // Обработчик для кнопки "Показать список"
        private void ShowListButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = list.GetAllElements();
        }

        // Обработчик для кнопки "Добавить элемент"
        private void AddElementButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputTextBox.Text, out int value))
            {
                list.Append(value);
                OutputTextBox.Text = $"Added element: {value}";
                InputTextBox.Clear(); // Очищаем текстовое поле после добавления
            }
            else
            {
                OutputTextBox.Text = "Invalid input. Please enter an integer.";
            }
        }

        // 1. Переворачивает список
        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            list.Reverse();
            OutputTextBox.Text = "List Reversed!";
        }

        // 2. Переносит последний элемент в начало
        private void MoveLastToFirstButton_Click(object sender, RoutedEventArgs e)
        {
            list.MoveLastToFirst();
            OutputTextBox.Text = "Last Moved to First!";
        }

        // 3. Количество различных элементов
        private void CountDistinctButton_Click(object sender, RoutedEventArgs e)
        {
            int count = list.CountDistinct();
            OutputTextBox.Text = $"Distinct Elements: {count}";
        }

        // 4. Удаляет неуникальные элементы
        private void RemoveNonUniqueButton_Click(object sender, RoutedEventArgs e)
        {
            list.RemoveNonUnique();
            OutputTextBox.Text = "Non-unique elements removed!";
        }

        // 5. Вставляет список после первого вхождения элемента
        private void InsertListAfterFirstButton_Click(object sender, RoutedEventArgs e)
        {
            int x = 5; // Пример
            LinkedList listToInsert = new LinkedList();
            listToInsert.Append(10); // Пример вставки элементов в новый список
            list.InsertListAfterFirst(x, listToInsert);
            OutputTextBox.Text = $"List inserted after first occurrence of {x}.";
        }

        // 6. Вставляет элемент в упорядоченный список
        private void InsertInOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int newElement = 6; // Пример
            list.InsertInOrder(newElement);
            OutputTextBox.Text = $"Element {newElement} inserted in order.";
        }

        // 7. Удаляет все элементы E
        private void RemoveAllButton_Click(object sender, RoutedEventArgs e)
        {
            int E = 5; // Пример
            list.RemoveAll(E);
            OutputTextBox.Text = $"All elements {E} removed.";
        }

        // 8. Вставляет элемент перед первым вхождением E
        private void InsertBeforeButton_Click(object sender, RoutedEventArgs e)
        {
            int E = 5; // Пример
            int F = 10; // Пример
            list.InsertBefore(E, F);
            OutputTextBox.Text = $"Element {F} inserted before first occurrence of {E}.";
        }

        // 9. Дописывает список в конец
        private void AppendListButton_Click(object sender, RoutedEventArgs e)
        {
            LinkedList listToAppend = new LinkedList();
            listToAppend.Append(20); // Пример добавления в новый список
            list.AppendList(listToAppend);
            OutputTextBox.Text = "List appended!";
        }

        // 10. Разбивает список по первому вхождению числа
        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            int x = 5; // Пример
            LinkedList firstList, secondList;
            list.Split(x, out firstList, out secondList);
            OutputTextBox.Text = $"List split at first occurrence of {x}.";
        }

        // 11. Удваивает список
        private void DoubleListButton_Click(object sender, RoutedEventArgs e)
        {
            list.DoubleList();
            OutputTextBox.Text = "List doubled!";
        }

        // 12. Меняет местами два элемента
        private void SwapButton_Click(object sender, RoutedEventArgs e)
        {
            int x = 5; // Пример
            int y = 10; // Пример
            list.Swap(x, y);
            OutputTextBox.Text = $"Elements {x} and {y} swapped.";
        }
    }
}
