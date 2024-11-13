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
    /// Логика взаимодействия для ExampleListWindow.xaml
    /// </summary>
    public partial class ExampleListWindow : Window
    {
        public ExampleListWindow()
        {
            InitializeComponent();
        }

        List<string> tasks = new List<string>(new string[] {"Сходить в магазин", "Проверить почту", "Отправить проект на проверку"});

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddInputPanel.Visibility = Visibility.Visible;
            AddInputBox.Focus();
        }
        private void ConfirmAddButton_Click(object sender, RoutedEventArgs e)
        {
            string input = AddInputBox.Text.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                tasks.Add(input);
                ResultTextBox.AppendText("Добавлено: " + input + "\n");
            }

            AddInputBox.Clear();
            AddInputPanel.Visibility = Visibility.Collapsed;
        }


        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveInputPanel.Visibility = Visibility.Visible;
            RemoveInputBox.Focus();
        }

        private void ConfirmRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string input = RemoveInputBox.Text.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                tasks.Remove(input);
                ResultTextBox.AppendText("Вычеркнуто: " + input + "\n");
            }

            RemoveInputBox.Clear();
            RemoveInputPanel.Visibility = Visibility.Collapsed;
        }


        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.AppendText("Обновленный список дел: " + "\n");
            foreach (string task in tasks)
            {
                ResultTextBox.AppendText(task + "\n");
            }
        }
    }
}
