using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Algoritms_Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            StackWindow stackWindow = new StackWindow();
            stackWindow.Show();
        }

        private void Button2List_Click(object sender, RoutedEventArgs e)
        {
            Queue2ListWindow queueListWindow = new Queue2ListWindow();
            queueListWindow.Show();
        }
        
        private void Button2Queue_Click(object sender, RoutedEventArgs e)
        {
            Queue2Window queueWindow = new Queue2Window();
            queueWindow.Show();
        }
        private void Button3_1_Click(object sender, RoutedEventArgs e)
        {
            ExampleListWindow exampleListWindow = new ExampleListWindow();
            exampleListWindow.Show();
        }

        private void Button3_2_Click(object sender, RoutedEventArgs e)
        {
            ExampleStackWindow exampleStackWindow = new ExampleStackWindow();
            exampleStackWindow.Show();
        }

        private void Button3_3_Click(object sender, RoutedEventArgs e)
        {
            ExampleQueueWindow exampleQueueWindow = new ExampleQueueWindow();
            exampleQueueWindow.Show();
        }

        private void Button3_4_Click(object sender, RoutedEventArgs e)
        {
            ExampleTreeWindow exampleTreeWindow = new ExampleTreeWindow();
            exampleTreeWindow.Show();
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            NodeWindow nodeWindow = new NodeWindow();
            nodeWindow.Show();
        }
    }
}