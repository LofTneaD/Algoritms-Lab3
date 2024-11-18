using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
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

    // проверка на пустоту
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
            if (commands[i].Length > 1) //Push
            {
                string command = commands[i].Substring(2);
                queue.Enqueue(command);
                Output.AppendText("\nДобавлен: " + command);
            }
            else
            {
                switch (commands[i])
                {
                    case "2": //Pop
                        if (queue.Count > 0) {
                            object value = queue.Dequeue();
                            Output.AppendText(value.ToString());
                        } else {
                            Output.AppendText("Очередь пуста");
                        }
                        break;

                    case "3": //Top
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

                    case "4": //isEmpty
                        if (queue.Count == 0)
                        {
                            Output.AppendText("\n Очередь пуста");

                        }
                        else
                        {
                            Output.AppendText("\n Очередь НЕ пуста");
                        }

                        break;
                    case "5": //Print
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

    // для результатов 

    private void MeasureButton_Click(object sender, RoutedEventArgs e)
    {
        MeasureInputPanel.Visibility = Visibility.Visible;
        MeasureInputBox.Focus();
    }

    private void ConfirmMeasureButton_Click(object sender, RoutedEventArgs e) /////<<<----
    {
        int.TryParse(MeasureInputBox.Text.Trim(), out int input);

        double[] time = new double[input];
        Stopwatch stopwatch = new Stopwatch();

        MeasureInputBox.Clear();
        MeasureInputPanel.Visibility = Visibility.Collapsed;

        string[][] commands = CommandGenerator.MakeMassives(input);

        for (int i = 0; i < input; i++)
        {
            double totalTime = 0;

            for (int j = 0; j < 5; j++)
            {
                stopwatch.Restart();

                ExecuteCommands(commands[i]);

                stopwatch.Stop();

                totalTime += stopwatch.Elapsed.TotalMilliseconds;
            }

            time[i] = totalTime / 5;
        }

        SaveResultsToFile(time);
    }

    public static void SaveResultsToFile(double[] results)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();


        saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        saveFileDialog.Title = "Save Results to File";
        saveFileDialog.DefaultExt = "txt";
        saveFileDialog.FileName = "results.txt";

        if (saveFileDialog.ShowDialog() == true)
        {
            string filePath = saveFileDialog.FileName;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (double line in results)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}