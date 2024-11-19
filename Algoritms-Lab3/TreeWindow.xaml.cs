using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Логика взаимодействия для TreeWindow.xaml
    /// </summary>
    public partial class TreeWindow : Window
    {
        private TreeNode RootNode;
        public TreeWindow()
        {
            InitializeComponent();
            InitializeTree();
            BindTreeToTreeView();
        }

        // Инициализация дерева
        private void InitializeTree()
        {
            RootNode = new TreeNode("Root");
            var child1 = new TreeNode("Child 1");
            var child2 = new TreeNode("Child 2");
            child1.Children.Add(new TreeNode("Child 1.1"));
            child1.Children.Add(new TreeNode("Child 1.2"));
            child2.Children.Add(new TreeNode("Child 2.1"));
            RootNode.Children.Add(child1);
            RootNode.Children.Add(child2);
        }

        // Привязка данных к TreeView
        private void BindTreeToTreeView()
        {
            TreeViewControl.Items.Clear();
            TreeViewControl.Items.Add(CreateTreeViewItem(RootNode));
        }

        // Рекурсивное создание элементов TreeViewItem
        private TreeViewItem CreateTreeViewItem(TreeNode node)
        {
            var treeViewItem = new TreeViewItem { Header = node.Name };
            foreach (var child in node.Children)
            {
                treeViewItem.Items.Add(CreateTreeViewItem(child));
            }
            return treeViewItem;
        }

        // Обработчик кнопки для обхода дерева
        private void OnTraverseTreeClick(object sender, RoutedEventArgs e)
        {
            TraverseTree(RootNode, node => MessageBox.Show($"Visited: {node.Name}"));
        }

        // Метод обхода дерева
        private void TraverseTree(TreeNode node, Action<TreeNode> action)
        {
            if (node == null) return;

            action(node);

            foreach (var child in node.Children)
            {
                TraverseTree(child, action);
            }
        }
        // Метод для добавления узла
        private void OnAddNodeClick(object sender, RoutedEventArgs e)
        {
            // Проверяем, введено ли имя узла
            string nodeName = NodeNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(nodeName))
            {
                MessageBox.Show("Введите имя узла!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем, выбран ли узел в TreeView
            if (TreeViewControl.SelectedItem is TreeViewItem selectedItem)
            {
                // Получаем соответствующий объект TreeNode
                TreeNode parentNode = FindTreeNode(RootNode, selectedItem.Header.ToString());
                if (parentNode != null)
                {
                    // Добавляем новый узел
                    var newNode = new TreeNode(nodeName);
                    parentNode.AddChild(newNode);

                    // Обновляем TreeView
                    selectedItem.Items.Add(CreateTreeViewItem(newNode));
                    selectedItem.IsExpanded = true; // Открываем родительский узел
                }
            }
            else
            {
                MessageBox.Show("Выберите родительский узел!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Очищаем текстовое поле
            NodeNameTextBox.Clear();
        }

        // Метод для поиска TreeNode по имени
        private TreeNode FindTreeNode(TreeNode currentNode, string name)
        {
            if (currentNode.Name == name) return currentNode;

            foreach (var child in currentNode.Children)
            {
                var foundNode = FindTreeNode(child, name);
                if (foundNode != null) return foundNode;
            }

            return null;
        }
        // Метод для удаления узла
        private void OnDeleteNodeClick(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбран ли узел в TreeView
            if (TreeViewControl.SelectedItem is TreeViewItem selectedItem)
            {
                // Получаем имя узла
                string nodeName = selectedItem.Header.ToString();

                // Удаляем узел из модели данных
                bool removed = RemoveNode(RootNode, nodeName);
                if (removed)
                {
                    // Удаляем узел из TreeView
                    if (selectedItem.Parent is TreeViewItem parentItem)
                    {
                        parentItem.Items.Remove(selectedItem);
                    }
                    else
                    {
                        TreeViewControl.Items.Remove(selectedItem); // Для корневого узла
                    }

                    MessageBox.Show($"Узел '{nodeName}' успешно удалён!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось найти узел в модели данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите узел для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Метод для удаления узла из модели данных
        private bool RemoveNode(TreeNode currentNode, string nodeName)
        {
            // Проверяем дочерние узлы
            for (int i = 0; i < currentNode.Children.Count; i++)
            {
                if (currentNode.Children[i].Name == nodeName)
                {
                    currentNode.Children.RemoveAt(i);
                    return true;
                }

                // Рекурсивно проверяем дочерние узлы
                if (RemoveNode(currentNode.Children[i], nodeName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
