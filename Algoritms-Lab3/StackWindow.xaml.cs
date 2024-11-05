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
    /// Логика взаимодействия для StackWindow.xaml
    /// </summary>
    public partial class StackWindow : Window
    {
        public StackWindow()
        {
            InitializeComponent();
        }

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
                Stack.Push(input);
                UpdateStackDisplay();
                ResultTextBox.AppendText("Добавлен: " + input + "\n");
            }

            // Очистить поле ввода и скрыть панель
            PushInputBox.Clear();
            PushInputPanel.Visibility = Visibility.Collapsed;
        }

        private void PopButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TopButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void isEmptyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MeasureButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InfixToPostfixButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateStackDisplay()
        {
            
        }
    }
}
