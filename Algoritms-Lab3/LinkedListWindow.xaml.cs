using System.Windows;

namespace Algoritms_Lab3;

public partial class LinkedListWindow : Window
{
    public LinkedListWindow()
    {
        InitializeComponent();
    }
    
    // класс связного списка
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        public Node<T>? Head { get; private set; }

        // Добавление элемента в конец списка
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // Печать элементов списка
        public void Print()
        {
            Node<T>? current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
           
        // Переворот списка
        public void Reverse()
        {
            Node<T>? prev = null;
            Node<T>? current = Head;
            while (current != null)
            {
                Node<T>? next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
        }

        // Задание 2 - Написать функцию, которая переносит в начало (в конец) непустого списка L его последний (первый) элемент. 
        public void MoveLastToFirst()
        {
            if (Head == null || Head.Next == null) return;

            Node<T>? prev = null;
            Node<T>? current = Head;

            // Найти последний элемент
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }

            prev.Next = null; // Отделить последний элемент
            current.Next = Head; // Переместить его в начало
            Head = current;
        }

        public void MoveFirstToLast()
        {
            if (Head == null || Head.Next == null) return;

            Node<T>? first = Head;
            Head = Head.Next; // Переместить указатель на второй элемент

            // Найти последний элемент
            Node<T>? current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = first;
            first.Next = null; // Отделить первый элемент
            
        }
        
        // задание 3 - Количество различных элементов
        public int CountDistinct()
        {
            HashSet<T> uniqueElements = new HashSet<T>();
            Node<T>? current = Head;

            while (current != null)
            {
                uniqueElements.Add(current.Data);
                current = current.Next;
            }
            return uniqueElements.Count;
        }

        // задание 4 - Написать функцию, которая удаляет из списка L неуникальные элементы.
        public void RemoveNonUnique()
        {
            Dictionary<T, int> counts = new Dictionary<T, int>();
            Node<T>? current = Head;

            // Подсчет частот
            while (current != null)
            {
                if (counts.ContainsKey(current.Data))
                    counts[current.Data]++;
                else
                    counts[current.Data] = 1;

                current = current.Next;
            }

            // Удаление неуникальных
            Node<T>? dummy = new Node<T>(default(T)!);
            dummy.Next = Head;
            current = dummy;

            while (current.Next != null)
            {
                if (counts[current.Next.Data] > 1)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            Head = dummy.Next;
        }

        // задание 5 - Написать функцию вставки списка самого в себя вслед за первым вхождением числа х.
        public void InsertAfterFirstOccurrence(T x, LinkedList<T> other)
        {
            Node<T>? current = Head;

            while (current != null)
            {
                if (current.Data!.Equals(x))
                {
                    Node<T>? temp = current.Next;
                    current.Next = other.Head;

                    // Найти конец вставляемого списка
                    Node<T>? otherEnd = other.Head;
                    while (otherEnd!.Next != null)
                    {
                        otherEnd = otherEnd.Next;
                    }
                    otherEnd.Next = temp;
                    break;
                }
                current = current.Next;
            }
        }
        
        // задание 6 - Написать функцию, которая вставляет в непустой список L, элементы которого упорядочены по не убыванию, новый элемент Е так, чтобы сохранилась упорядоченность.
        
        public void InsertSorted(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (Head == null || Comparer<T>.Default.Compare(Head.Data, value) >= 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            Node<T>? current = Head;
            while (current.Next != null && Comparer<T>.Default.Compare(current.Next.Data, value) < 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        // задание 7 - Удаление всех элементов E, если такие есть
        public void RemoveAll(T value)
        {
            Node<T>? dummy = new Node<T>(default(T)!);
            dummy.Next = Head;
            Node<T>? current = dummy;

            while (current.Next != null)
            {
                if (current.Next.Data!.Equals(value))
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            Head = dummy.Next;
        }

        // задание 8 - Написать функцию, которая вставляет в список L новый элемент F перед первым вхождением элемента Е, если Е входит в L.
        public void InsertBeforeFirstOccurrence(T newValue, T existingValue)
        {
            Node<T> newNode = new Node<T>(newValue);

            if (Head == null) return;

            if (Head.Data!.Equals(existingValue))
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            Node<T>? current = Head;
            while (current.Next != null && !current.Next.Data!.Equals(existingValue))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        // задание 9 - Функция дописывает к списку L список E
        public void Append(LinkedList<T> other)
        {
            if (Head == null)
            {
                Head = other.Head;
                return;
            }

            Node<T>? current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = other.Head;
        }

        // задание 10 - Функция разбивает список целых чисел на два списка по первому вхождению заданного числа. Если этого числа в списке нет, второй список будет пустым, а первый не изменится.
        public LinkedList<T> SplitByFirstOccurrence(T value)
        {
            LinkedList<T> secondList = new LinkedList<T>();

            Node<T>? current = Head;
            Node<T>? dummy = new Node<T>(default(T)!);
            Node<T>? secondHead = dummy;

            while (current != null && !current.Data!.Equals(value))
            {
                current = current.Next;
            }

            if (current != null && current.Next != null)
            {
                secondHead.Next = current.Next;
                current.Next = null; // Обрезаем первый список
            }

            secondList.Head = dummy.Next;
            return secondList;
        }

        // задание 11 - Функция удваивает список, т.е. приписывает в конец списка себя самого.
        public void Duplicate()
        {
            if (Head == null) return;

            // Найти конец списка
            Node<T>? current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            // Копируем элементы из исходного списка
            Node<T>? source = Head;
            while (source != null)
            {
                Node<T> newNode = new Node<T>(source.Data); // Создаем новый узел
                current.Next = newNode; // Присоединяем его к концу списка
                current = current.Next; // Переходим к новому последнему узлу
                source = source.Next; // Двигаемся по исходному списку
            }
        }

        
        // задание 12 - Функция меняет местами два элемента списка, заданные пользователем
        public void Swap(int index1, int index2)
        {
            if (index1 == index2) return; // Если индексы совпадают, ничего менять не нужно

            Node<T>? prev1 = null, prev2 = null;
            Node<T>? node1 = Head, node2 = Head;

            // Найти первый элемент и его предыдущий узел
            for (int i = 0; i < index1 && node1 != null; i++)
            {
                prev1 = node1;
                node1 = node1.Next;
            }

            // Найти второй элемент и его предыдущий узел
            for (int i = 0; i < index2 && node2 != null; i++)
            {
                prev2 = node2;
                node2 = node2.Next;
            }

            if (node1 == null || node2 == null) throw new ArgumentOutOfRangeException("Индекс вне диапазона!");

            // Меняем ссылки на узлы
            if (prev1 != null)
            {
                prev1.Next = node2;
            }
            else
            {
                Head = node2;
            }

            if (prev2 != null)
            {
                prev2.Next = node1;
            }
            else
            {
                Head = node1;
            }

            // Меняем "Next" между узлами
            Node<T>? temp = node1.Next;
            node1.Next = node2.Next;
            node2.Next = temp;
        }
    }
}