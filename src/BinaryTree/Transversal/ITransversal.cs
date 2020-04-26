using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Transversal
{
    public interface ITransversal
    {
        void Navigate(MyBinaryTreeNode node, List<int> nodesList);
    }
}
