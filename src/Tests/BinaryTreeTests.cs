using BinaryTree;
using BinaryTree.Transversal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
        private MyBinaryTree tree;

        [TestInitialize]
        public void SetUp()
        {
            //     10
            //    /  \
            //   5    15
            //  / \     \
            // 3   7    20
            //         /  \
            //        17  25
            //           /  \
            //          23   27  
            tree = new MyBinaryTree();
            tree.Add(10);
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(15);
            tree.Add(20);
            tree.Add(17);
            tree.Add(25);
            tree.Add(23);
            tree.Add(27);
        }

        [TestMethod]
        public void BinaryTree_Delete_HeadWithTwoChildrensAndRightWithoutLeftChild()
        {
            tree.Delete(10);
            Assert.AreEqual(tree.Head.Value, 15);
            Assert.AreEqual(tree.Head.Right.Value, 20);
            Assert.AreEqual(tree.Head.Left.Value, 5);
            
            Console.WriteLine(tree.Transversal(new InOrderTransversal()));
        }
        
        [TestMethod]
        public void BinaryTree_Delete_LeafNodeOnLeft()
        {
            tree.Delete(3);
            Assert.AreEqual(tree.Head.Value, 10);
            Assert.AreEqual(tree.Head.Left.Value, 5);
            Assert.IsNull(tree.Head.Left.Left);

            Console.WriteLine(tree.Transversal(new InOrderTransversal()));
        }

        [TestMethod]
        public void BinaryTree_Delete_LeafNodeOnRight()
        {
            tree.Delete(27);
            Assert.AreEqual(tree.Head.Value, 10);
            Assert.AreEqual(tree.Head.Right.Value, 15);
            Assert.AreEqual(tree.Head.Right.Right.Value, 20);
            Assert.AreEqual(tree.Head.Right.Right.Right.Value, 25);
            Assert.IsNull(tree.Head.Right.Right.Right.Right);

            Console.WriteLine(tree.Transversal(new InOrderTransversal()));
        }


        [TestMethod]
        public void BinaryTree_Delete_NodeWithChildrensWithRightNodeWithLeftNode()
        {
            tree.Delete(20);
            Assert.AreEqual(tree.Head.Value, 10);
            Assert.AreEqual(tree.Head.Right.Value, 15);
            Assert.AreEqual(tree.Head.Right.Right.Value, 23);
            Assert.AreEqual(tree.Head.Right.Right.Left.Value, 17);
            Assert.AreEqual(tree.Head.Right.Right.Right.Value, 25);

            Console.WriteLine(tree.Transversal(new InOrderTransversal()));
        }


        [TestMethod]
        public void BinaryTree_Contains()
        {
            Assert.IsTrue(tree.Contains(3));
            Assert.IsTrue(tree.Contains(5));
            Assert.IsTrue(tree.Contains(25));
            Assert.IsFalse(tree.Contains(9));
            Assert.IsFalse(tree.Contains(11));
        }

        [TestMethod]
        public void BinaryTree_InOrderTransversal()
        {
            var nodes = tree.Transversal(new InOrderTransversal()).ToList();
            Assert.AreEqual(nodes[0], 3);
            Assert.AreEqual(nodes[1], 5);
            Assert.AreEqual(nodes[2], 7);
            Assert.AreEqual(nodes[3], 10);
            Assert.AreEqual(nodes[4], 15);
            Assert.AreEqual(nodes[5], 17);
            Assert.AreEqual(nodes[6], 20);
            Assert.AreEqual(nodes[7], 23);
            Assert.AreEqual(nodes[8], 25);
            Assert.AreEqual(nodes[9], 27);
        }

        [TestMethod]
        public void BinaryTree_PreOrderTransversal()
        {
            var nodes = tree.Transversal(new PreOrderTransversal()).ToList();
            Assert.AreEqual(nodes[0], 10);
            Assert.AreEqual(nodes[1], 5);
            Assert.AreEqual(nodes[2], 3);
            Assert.AreEqual(nodes[3], 7);
            Assert.AreEqual(nodes[4], 15);
            Assert.AreEqual(nodes[5], 20);
            Assert.AreEqual(nodes[6], 17);
            Assert.AreEqual(nodes[7], 25);
            Assert.AreEqual(nodes[8], 23);
            Assert.AreEqual(nodes[9], 27);
        }
        

        [TestMethod]
        public void BinaryTree_PostOrderTransversal()
        {
            var nodes = tree.Transversal(new PostOrderTransversal()).ToList();
            Assert.AreEqual(nodes[0], 3);
            Assert.AreEqual(nodes[1], 7);
            Assert.AreEqual(nodes[2], 5);
            Assert.AreEqual(nodes[3], 17);
            Assert.AreEqual(nodes[4], 23);
            Assert.AreEqual(nodes[5], 27);
            Assert.AreEqual(nodes[6], 25);
            Assert.AreEqual(nodes[7], 20);
            Assert.AreEqual(nodes[8], 15);
            Assert.AreEqual(nodes[9], 10);
        }
    }
}
