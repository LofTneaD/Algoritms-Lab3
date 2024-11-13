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
using static System.Net.Mime.MediaTypeNames;

namespace Algoritms_Lab3
{
    /// <summary>
    /// Логика взаимодействия для ExampleQueueWindow.xaml
    /// </summary>
    public partial class ExampleQueueWindow : Window
    {
        public ExampleQueueWindow()
        {
            InitializeComponent();
        }

        private Queue<string> line = new Queue<string>(new string[] { "Иван", "Владимир", "Екатерина" });

        private void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            NewOrderInputPanel.Visibility = Visibility.Visible;
            NewOrderInputBox.Focus();
        }
        private void ConfirmNewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string input = NewOrderInputBox.Text.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                line.Enqueue(input);
                ResultTextBox.AppendText("Новый заказ на имя : " + input + "\n");
            }

            NewOrderInputBox.Clear();
            NewOrderInputPanel.Visibility = Visibility.Collapsed;
        }


        private void DeliveredButton_Click(object sender, RoutedEventArgs e)
        {
            if (line.Count != 0)
            {
                if (line.Peek()[line.Peek().Length - 1] == 'а') 
                {
                    ResultTextBox.AppendText("Посылка доставлена : " + line.Peek().Substring(0, line.Peek().Length - 1) + 'е' + "\n");
                    line.Dequeue();
                }
                else
                {
                    ResultTextBox.AppendText("Посылка доставлена : " + line.Peek() + 'у' + "\n");
                    line.Dequeue();
                }                
            }
            else
                ResultTextBox.AppendText("Заказов нет" + "\n");
        }

        private void PrintLineButton_Click(object sender, RoutedEventArgs e)
        {
            if (line.Count != 0)
            {
                ResultTextBox.AppendText("Текущие заказы на имена: " + "\n");
                foreach (string action in line)
                {
                    ResultTextBox.AppendText(action + "\n");
                }
            }
            else
                ResultTextBox.AppendText("Заказов нет" + "\n");
        }
    }    
}
