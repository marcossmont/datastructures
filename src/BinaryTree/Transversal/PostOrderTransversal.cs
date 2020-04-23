using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Transversal
{
    public class PostOrderTransversal : IInOrder
    {
        public void Navigate(MyBinaryTreeNode node, List<int> nodesList)
        {
            if (node == null)
            {
                return;
            }

            Navigate(node.Left, nodesList);
            Navigate(node.Right, nodesList);
            nodesList.Add(node.Value);
        }
    }
}
