using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class MyBinaryTree
    {
        private MyBinaryTreeNode head;

        public MyBinaryTree()
        {

        }

        //public void Add(int value)
        //{
        //    if (head == null)
        //    {
        //        head = new MyBinaryTreeNode(value);
        //    }
        //    else
        //    {
        //        var current = head;

        //        while (current != null)
        //        {
        //            if (value < current.Value)
        //            {
        //                if (current.Left == null)
        //                {
        //                    current.Left = new MyBinaryTreeNode(value);
        //                    break;
        //                }
        //                else
        //                {
        //                    current = current.Left;
        //                }
        //            }
        //            else
        //            {
        //                if (current.Right == null)
        //                {
        //                    current.Right = new MyBinaryTreeNode(value);
        //                    break;
        //                }
        //                else
        //                {
        //                    current = current.Right;
        //                }
        //            }
        //        }
        //    }
        //}

        public void Add(int value)
        {
            if (head == null)
            {
                head = new MyBinaryTreeNode(value);
            }
            else
            {
                AddTo(head, value);
            }
        }

        private void AddTo(MyBinaryTreeNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                {
                    node.Left = new MyBinaryTreeNode(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new MyBinaryTreeNode(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        private (MyBinaryTreeNode Node, MyBinaryTreeNode Parent) FindWithParent(int value)
        {
            var current = head;
            MyBinaryTreeNode parent = null;

            while (current != null)
            {
                if (value == current.Value)
                {
                    break;
                }

                parent = current;

                if (value < current.Value)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return (current, parent);
        }

        public IEnumerable<int> Transversal(IInOrder inOrder)
        {
            if (head == null)
            {
                return null;
            }

            List<int> nodesList = new List<int>();
            inOrder.Navigate(head, nodesList);
            return nodesList;
        }        
    }
}
