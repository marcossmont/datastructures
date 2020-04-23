using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public interface IInOrder
    {
        void Navigate(MyBinaryTreeNode node, List<int> nodesList);
    }
}
