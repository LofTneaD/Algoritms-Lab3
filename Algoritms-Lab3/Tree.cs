using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms_Lab3
{
    public class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(string name)
        {
            Name = name;
            Children = new List<TreeNode>();
        }
        public static void TraverseTree(TreeNode node, Action<TreeNode> action)
        {
            if (node == null) return;

            action(node); // Выполнить действие над текущим узлом

            foreach (var child in node.Children)
            {
                TraverseTree(child, action); // Рекурсивный вызов для дочерних узлов
            }
        }
        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }
    }

}
