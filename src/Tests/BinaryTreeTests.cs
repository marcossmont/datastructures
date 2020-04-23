using BinaryTree;
using BinaryTree.Transversal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8
            tree = new MyBinaryTree();
            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);
        }

        [TestMethod]
        public void BinaryTree_InOrderTransversal()
        {
            var nodes = tree.Transversal(new InOrderTransversal()).ToList();
            Assert.AreEqual(nodes[0], 1);
            Assert.AreEqual(nodes[1], 2);
            Assert.AreEqual(nodes[2], 3);
            Assert.AreEqual(nodes[3], 4);
            Assert.AreEqual(nodes[4], 5);
            Assert.AreEqual(nodes[5], 6);
            Assert.AreEqual(nodes[6], 7);
            Assert.AreEqual(nodes[7], 8);
        }

        [TestMethod]
        public void BinaryTree_PreOrderTransversal()
        {
            var nodes = tree.Transversal(new PreOrderTransversal()).ToList();
            Assert.AreEqual(nodes[0], 4);
            Assert.AreEqual(nodes[1], 2);
            Assert.AreEqual(nodes[2], 1);
            Assert.AreEqual(nodes[3], 3);
            Assert.AreEqual(nodes[4], 5);
            Assert.AreEqual(nodes[5], 7);
            Assert.AreEqual(nodes[6], 6);
            Assert.AreEqual(nodes[7], 8);
        }
        

        [TestMethod]
        public void BinaryTree_PostOrderTransversal()
        {
            var nodes = tree.Transversal(new PostOrderTransversal()).ToList();
            Assert.AreEqual(nodes[0], 1);
            Assert.AreEqual(nodes[1], 3);
            Assert.AreEqual(nodes[2], 2);
            Assert.AreEqual(nodes[3], 6);
            Assert.AreEqual(nodes[4], 8);
            Assert.AreEqual(nodes[5], 7);
            Assert.AreEqual(nodes[6], 5);
            Assert.AreEqual(nodes[7], 4);
        }
    }
}
