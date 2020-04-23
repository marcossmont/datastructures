using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class MyBinaryTreeNode
    {
        private readonly int _value;

        public int Value => _value;
        public MyBinaryTreeNode Left { get; set; }
        public MyBinaryTreeNode Right { get; set; }

        public MyBinaryTreeNode(int value)
        {
            this._value = value;
        }
    }
}
