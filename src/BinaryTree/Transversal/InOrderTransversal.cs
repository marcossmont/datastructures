using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Transversal
{
    public class InOrderTransversal : ITransversal
    {
        public void Navigate(MyBinaryTreeNode node, List<int> nodesList)
        {
            if (node == null)
            {
                return;
            }

            Navigate(node.Left, nodesList);
            nodesList.Add(node.Value);
            Navigate(node.Right, nodesList);
        }
    }
}
