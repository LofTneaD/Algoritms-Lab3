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
            Queue2Window queueListWindow = new Queue2Window();
            queueListWindow.Show();
        }
        
        private void Button2Queue_Click(object sender, RoutedEventArgs e)
        {
            Queue2ListWindow queueWindow = new Queue2ListWindow();
            queueWindow.Show();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}