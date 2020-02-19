using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void MyQueue_Enqueue()
        {
            MyQueue<int> queue = new MyQueue<int>();

            queue.Enqueue(3, Priority.Low);
            queue.Enqueue(4, Priority.Low);
            queue.Enqueue(2, Priority.Medium);
            queue.Enqueue(1, Priority.High);

            Assert.AreEqual(queue.Head.Value, 1);
            Assert.AreEqual(queue.Head.Next.Value, 2);
            Assert.AreEqual(queue.Head.Next.Next.Value, 3);
            Assert.AreEqual(queue.Head.Next.Next.Next.Value, 4);
        }

        [TestMethod]
        public void MyQueue_Dequeue()
        {
            MyQueue<int> queue = new MyQueue<int>();

            queue.Enqueue(3, Priority.Low);
            queue.Enqueue(4, Priority.Low);
            queue.Enqueue(2, Priority.Medium);
            queue.Enqueue(1, Priority.High);

            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
            Assert.AreEqual(queue.Dequeue(), 4);
            Assert.ThrowsException<Exception>(() => queue.Dequeue(), "Queue is empty");
        }

        [TestMethod]
        public void MyQueue_Pick()
        {
            MyQueue<int> queue = new MyQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(queue.Pick(), 1);
            Assert.AreEqual(queue.Pick(), 1);
        }

        [TestMethod]
        public void MyQueue_Enumerate()
        {
            MyQueue<int> queue = new MyQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var target = 1;
            var enumerator = queue.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(enumerator.Current, target);
                target++;
            }
        }
    }
}
