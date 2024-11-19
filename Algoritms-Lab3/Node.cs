using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Algoritms_Lab3
{
    // Узел связанного списка
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    // Связанный список
    public class LinkedList
    {
        public Node Head;

        public LinkedList()
        {
            Head = null;
        }
        public string GetAllElements()
        {
            if (Head == null)
                return "List is empty.";

            Node current = Head;
            string result = "";

            while (current != null)
            {
                result += current.Data + (current.Next != null ? ", " : "");
                current = current.Next;
            }

            return result;
        }

        public void Append(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }


        // 1. Переворачивает список
        public void Reverse()
        {
            Node prev = null;
            Node current = Head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
        }

        // 2. Переносит последний элемент в начало
        public void MoveLastToFirst()
        {
            if (Head == null || Head.Next == null) return;

            Node secondLast = Head;
            while (secondLast.Next.Next != null)
                secondLast = secondLast.Next;

            Node last = secondLast.Next;
            secondLast.Next = null;
            last.Next = Head;
            Head = last;
        }

        // 3. Количество различных элементов
        public int CountDistinct()
        {
            HashSet<int> uniqueElements = new HashSet<int>();
            Node current = Head;

            while (current != null)
            {
                uniqueElements.Add(current.Data);
                current = current.Next;
            }

            return uniqueElements.Count;
        }

        // 4. Удаляет неуникальные элементы
        public void RemoveNonUnique()
        {
            if (Head == null) return;

            Dictionary<int, int> elementCount = new Dictionary<int, int>();
            Node current = Head;

            // Подсчитываем количество вхождений каждого элемента
            while (current != null)
            {
                if (elementCount.ContainsKey(current.Data))
                    elementCount[current.Data]++;
                else
                    elementCount[current.Data] = 1;

                current = current.Next;
            }

            // Удаляем все элементы, которые встречаются более одного раза
            Node prev = null;
            current = Head;
            while (current != null)
            {
                if (elementCount[current.Data] > 1)
                {
                    if (prev == null) // Удаление головы
                        Head = current.Next;
                    else
                        prev.Next = current.Next;
                }
                else
                    prev = current;

                current = current.Next;
            }
        }

        // 5. Вставляет список после первого вхождения элемента
        public void InsertListAfterFirst(int x, LinkedList listToInsert)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data == x)
                {
                    Node temp = current.Next;
                    current.Next = listToInsert.Head;
                    while (current.Next != null) current = current.Next;
                    current.Next = temp;
                    return;
                }
                current = current.Next;
            }
        }

        // 6. Вставляет элемент в упорядоченный список
        public void InsertInOrder(int x)
        {
            Node newNode = new Node(x);

            if (Head == null || Head.Data >= x)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            Node current = Head;
            while (current.Next != null && current.Next.Data < x)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        // 7. Удаляет все элементы E
        public void RemoveAll(int E)
        {
            Node prev = null;
            Node current = Head;

            while (current != null)
            {
                if (current.Data == E)
                {
                    if (prev == null)
                        Head = current.Next;
                    else
                        prev.Next = current.Next;
                }
                else
                    prev = current;

                current = current.Next;
            }
        }

        // 8. Вставляет элемент перед первым вхождением E
        public void InsertBefore(int E, int F)
        {
            if (Head == null) return;

            if (Head.Data == E)
            {
                Node newNode = new Node(F);
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            Node current = Head;
            while (current.Next != null)
            {
                if (current.Next.Data == E)
                {
                    Node newNode = new Node(F);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
        }

        // 9. Дописывает список в конец
        public void AppendList(LinkedList listToAppend)
        {
            if (Head == null)
            {
                Head = listToAppend.Head;
                return;
            }

            Node current = Head;
            while (current.Next != null)
                current = current.Next;

            current.Next = listToAppend.Head;
        }

        // 10. Разбивает список по первому вхождению числа
        public void Split(int x, out LinkedList firstList, out LinkedList secondList)
        {
            firstList = new LinkedList();
            secondList = new LinkedList();

            Node current = Head;
            while (current != null)
            {
                if (current.Data == x)
                {
                    secondList.Head = current.Next;
                    current.Next = null;
                    break;
                }
                firstList.Append(current.Data); // Добавляем данные в firstList
                current = current.Next;
            }
        }

        // 11. Удваивает список
        public void DoubleList()
        {
            Node current = Head;
            LinkedList copy = new LinkedList();
            while (current != null)
            {
                copy.Append(current.Data); // Добавляем данные в копию
                current = current.Next;
            }
            AppendList(copy); // Дописываем копию в конец основного списка
        }

        // 12. Меняет местами два элемента
        public void Swap(int x, int y)
        {
            Node nodeX = null, nodeY = null;
            Node prevX = null, prevY = null;
            Node current = Head;

            while (current != null)
            {
                if (current.Data == x)
                {
                    nodeX = current;
                    break;
                }
                prevX = current;
                current = current.Next;
            }

            current = Head;
            while (current != null)
            {
                if (current.Data == y)
                {
                    nodeY = current;
                    break;
                }
                prevY = current;
                current = current.Next;
            }

            if (nodeX != null && nodeY != null)
            {
                if (prevX != null) prevX.Next = nodeY;
                else Head = nodeY;

                if (prevY != null) prevY.Next = nodeX;
                else Head = nodeX;

                Node temp = nodeX.Next;
                nodeX.Next = nodeY.Next;
                nodeY.Next = temp;
            }
        }
    }
}
