using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class PreOrderTransversal : IInOrder
    {
        public void Navigate(MyBinaryTreeNode node, List<int> nodesList)
        {
            if (node == null)
            {
                return;
            }

            nodesList.Add(node.Value);
            Navigate(node.Left, nodesList);
            Navigate(node.Right, nodesList);
        }
    }
}
