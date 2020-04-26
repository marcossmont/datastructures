using BinaryTree.NodeDeletion;
using BinaryTree.Transversal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class MyBinaryTree
    {
        private MyBinaryTreeNode head;
        public MyBinaryTreeNode Head => head;

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

        public bool Contains(int value)
        {
            return FindWithParent(value).Node != null;
        }

        public bool Delete(int value)
        {
            var foundNodeAndParent = FindWithParent(value);

            if (foundNodeAndParent.Node == null)
            {
                return false;
            }

            var node = foundNodeAndParent.Node;
            var parent = foundNodeAndParent.Parent;

            var nodeDeletionStrategy = new NodeDeletionStrategyFactory(node).GetImplementation();

            if (parent == null)
            {
                head = nodeDeletionStrategy.Delete();
            }
            else
            {
                if (node.Value < parent.Value)
                {
                    parent.Left = nodeDeletionStrategy.Delete();
                }
                else
                {
                    parent.Right = nodeDeletionStrategy.Delete();
                }
            }

            return true;
        }

        //public bool Delete(int value)
        //{
        //    var foundNodeAndParent = FindWithParent(value);

        //    if (foundNodeAndParent.Node == null)
        //    {
        //        return false;
        //    }

        //    var node = foundNodeAndParent.Node;
        //    var parent = foundNodeAndParent.Parent;

        //    if (node.Right == null)
        //    {
        //        if (parent == null)
        //        {
        //            head = node.Left;
        //        }
        //        else
        //        {
        //            if (node.Value < parent.Value)
        //            {
        //                parent.Left = node.Left;
        //            }
        //            else
        //            {
        //                parent.Right = node.Left;
        //            }
        //        }
        //    }
        //    else if (node.Right.Left == null)
        //    {
        //        node.Right.Left = node.Left;

        //        if (parent == null)
        //        {
        //            head = node.Right;
        //        }
        //        else
        //        {
        //            if (node.Value < parent.Value)
        //            {
        //                parent.Left = node.Right;
        //            }
        //            else
        //            {
        //                parent.Right = node.Right;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var leftmostParent = node.Right;
        //        var leftmostNode = node.Right.Left;

        //        while (leftmostNode.Left != null)
        //        {
        //            leftmostParent = leftmostNode;
        //            leftmostNode = leftmostNode.Left;
        //        }

        //        leftmostParent.Left = leftmostNode.Right;

        //        leftmostNode.Left = node.Left;
        //        leftmostNode.Right = node.Right;

        //        if (parent == null)
        //        {
        //            head = leftmostNode;
        //        }
        //        else if (node.Value < parent.Value)
        //        {
        //            parent.Left = leftmostNode;
        //        }
        //        else
        //        {
        //            parent.Right = leftmostNode;
        //        }
        //    }

        //    return true;
        //}
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

        public IEnumerable<int> Transversal(ITransversal inOrder)
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
