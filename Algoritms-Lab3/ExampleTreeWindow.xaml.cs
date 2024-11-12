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
    /// Логика взаимодействия для ExampleTreeWindow.xaml
    /// </summary>
    public partial class ExampleTreeWindow : Window
    {
        private CategoryTree categories;
        public ExampleTreeWindow()
        {
            InitializeComponent();
            categories = new CategoryTree("Магазин");
        }

        // Добавление подкатегории
        private void AddSubcategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string parentName = ParentTextBox.Text; // Имя родительской категории
            string subcategoryName = SubcategoryTextBox.Text; // Имя подкатегории

            if (!string.IsNullOrEmpty(parentName) && !string.IsNullOrEmpty(subcategoryName))
            {
                categories.AddSubcategory(parentName, subcategoryName);
                MessageBox.Show($"Подкатегория '{subcategoryName}' добавлена в '{parentName}'.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, укажите имя родительской категории и подкатегории.");
            }
        }

        // Удаление подкатегории
        private void RemoveSubcategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string subcategoryName = SubcategoryTextBox.Text; // Имя подкатегории для удаления

            if (!string.IsNullOrEmpty(subcategoryName))
            {
                bool removed = categories.RemoveSubcategory(subcategoryName);
                if (removed)
                {
                    MessageBox.Show($"Подкатегория '{subcategoryName}' удалена.");
                }
                else
                {
                    MessageBox.Show("Подкатегория не найдена.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, укажите имя подкатегории для удаления.");
            }
        }

        // Печать всех категорий
        private void PrintCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            string categoriesStructure = categories.Print();
            CategoriesTextBlock.Text = categoriesStructure;
        }
    }



    public class CategoryNode
    {
        public string Name { get; set; }
        public List<CategoryNode> Subcategories { get; set; }

        public CategoryNode(string name)
        {
            Name = name;
            Subcategories = new List<CategoryNode>();
        }

        public void AddSubcategory(CategoryNode subcategory)
        {
            Subcategories.Add(subcategory);
        }
    }

    public class CategoryTree
    {
        private CategoryNode root;

        public CategoryTree(string rootName)
        {
            root = new CategoryNode(rootName);
        }

        // Добавление подкатегории
        public void AddSubcategory(string parentName, string subcategoryName)
        {
            CategoryNode parentNode = FindCategory(root, parentName);
            if (parentNode != null)
            {
                parentNode.AddSubcategory(new CategoryNode(subcategoryName));
                Console.WriteLine($"Подкатегория {subcategoryName} добавлена в {parentName}.");
            }
        }

        // Рекурсивный поиск категории
        private CategoryNode FindCategory(CategoryNode node, string name)
        {
            if (node.Name == name) return node;
            foreach (var subcategory in node.Subcategories)
            {
                CategoryNode found = FindCategory(subcategory, name);
                if (found != null) return found;
            }
            return null;
        }

        // Удаление подкатегории
        public bool RemoveSubcategory(string subcategoryName)
        {
            return RemoveSubcategoryRecursive(root, subcategoryName);
        }

        private bool RemoveSubcategoryRecursive(CategoryNode parentNode, string subcategoryName)
        {
            var subcategoryToRemove = parentNode.Subcategories
                .FirstOrDefault(sub => sub.Name == subcategoryName);

            if (subcategoryToRemove != null)
            {
                parentNode.Subcategories.Remove(subcategoryToRemove);
                return true;
            }

            foreach (var subcategory in parentNode.Subcategories)
            {
                if (RemoveSubcategoryRecursive(subcategory, subcategoryName))
                {
                    return true;
                }
            }
            return false;
        }

        // Печать всех категорий
        public void PrintCategories(CategoryNode node, StringBuilder output, string indent = "")
        {
            output.AppendLine(indent + node.Name);
            foreach (var subcategory in node.Subcategories)
            {
                PrintCategories(subcategory, output, indent + "  ");
            }
        }

        // Печать дерева
        public string Print()
        {
            StringBuilder output = new StringBuilder();
            PrintCategories(root, output);
            return output.ToString();
        }
    }

}
