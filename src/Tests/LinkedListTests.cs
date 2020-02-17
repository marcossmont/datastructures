using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void MyLinkedList_AddFirst()
        {
            MyLinkedList<int> items = new MyLinkedList<int>();
            items.AddFirst(1);
            items.AddFirst(2);
            items.AddFirst(3);

            Assert.AreEqual(items.Head.Data, 3);
            Assert.AreEqual(items.Head.Next.Data, 2);
            Assert.AreEqual(items.Head.Next.Next.Data, 1);
            Assert.AreEqual(items.Count, 3);
        }

        [TestMethod]
        public void MyLinkedList_AddLast()
        {
            MyLinkedList<int> items = new MyLinkedList<int>();
            items.Add(1);
            items.Add(2);
            items.Add(3);

            Assert.AreEqual(items.Head.Data, 1);
            Assert.AreEqual(items.Head.Next.Data, 2);
            Assert.AreEqual(items.Head.Next.Next.Data, 3);
            Assert.AreEqual(items.Count, 3);
        }

        [TestMethod]
        public void MyLinkedList_RemoveAtBegining()
        {
            MyLinkedList<int> items = new MyLinkedList<int>();
            items.Add(1);
            items.Add(2);
            items.Add(3);
            items.Remove(1);

            Assert.AreEqual(items.Head.Data, 2);
            Assert.AreEqual(items.Head.Next.Data, 3);
            Assert.AreEqual(items.Count, 2);
        }

        [TestMethod]
        public void MyLinkedList_RemoveAtTheMiddle()
        {
            MyLinkedList<int> items = new MyLinkedList<int>();
            items.Add(1);
            items.Add(2);
            items.Add(3);
            items.Remove(2);

            Assert.AreEqual(items.Head.Data, 1);
            Assert.AreEqual(items.Head.Next.Data, 3);
            Assert.AreEqual(items.Count, 2);
        }

        [TestMethod]
        public void MyLinkedList_RemoveAtTheEnd()
        {
            MyLinkedList<int> items = new MyLinkedList<int>();
            items.Add(1);
            items.Add(2);
            items.Add(3);
            items.Remove(3);

            Assert.AreEqual(items.Head.Data, 1);
            Assert.AreEqual(items.Head.Next.Data, 2);
            Assert.AreEqual(items.Count, 2);
        }

        [TestMethod]
        public void MyLinkedList_CopyTo()
        {
            MyLinkedList<int> items = new MyLinkedList<int>();
            items.Add(1);
            items.Add(2);
            items.Add(3);

            var array = new int[3];
            items.CopyTo(array, 0);

            Assert.AreEqual(array[0], 1);
            Assert.AreEqual(array[1], 2);
            Assert.AreEqual(array[2], 3);
            Assert.AreEqual(array.Length, 3);
        }
    }
}
