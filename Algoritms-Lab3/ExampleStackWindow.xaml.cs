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
    /// Логика взаимодействия для ExampleStackWindow.xaml
    /// </summary>
    public partial class ExampleStackWindow : Window
    {
        public ExampleStackWindow()
        {
            InitializeComponent();
        }

        private Stack<string> actions = new Stack<string>(new string[] {"Вставлен текст", "Пробел", "Стереть абзац"});

        private void PushButton_Click(object sender, RoutedEventArgs e)
        {
            PushInputPanel.Visibility = Visibility.Visible;
            PushInputBox.Focus();
        }
        private void ConfirmPushButton_Click(object sender, RoutedEventArgs e)
        {
            string input = PushInputBox.Text.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                actions.Push(input);
                ResultTextBox.AppendText("Совершено: " + input + "\n");
            }

            PushInputBox.Clear();
            PushInputPanel.Visibility = Visibility.Collapsed;
        }


        private void PopButton_Click(object sender, RoutedEventArgs e)
        {
            if (actions.Count != 0) 
            {
                ResultTextBox.AppendText("Отменено: " + actions.Peek() + "\n");
                actions.Pop();
            }
            else
                ResultTextBox.AppendText("Действий не совершалось" + "\n");
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (actions.Count != 0)
            {
                ResultTextBox.AppendText("Были совершены: " + "\n");
                foreach (string action in actions)
                {
                    ResultTextBox.AppendText(action + "\n");
                }
            }
            else
                ResultTextBox.AppendText("Действий не совершалось" + "\n");
        }
    }
}
