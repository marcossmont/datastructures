using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void MyStack_Push()
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(stack.Top.Value, 3);
            Assert.AreEqual(stack.Top.Next.Value, 2);
            Assert.AreEqual(stack.Top.Next.Next.Value, 1);
        }

        [TestMethod]
        public void MyStack_Pop()
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(stack.Pop(), 3);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
            Assert.ThrowsException<Exception>(() => stack.Pop());
        }

        [TestMethod]
        public void MyStack_Pick()
        {
            MyStack<int> stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(stack.Pick(), 3);
            Assert.AreEqual(stack.Pick(), 3);

            stack.Pop();
            stack.Pop();
            stack.Pop();
            
            Assert.ThrowsException<Exception>(() => stack.Pick());
        }

        [TestMethod]
        public void MyStack_Enumerate()
        {
            MyStack<int> stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int target = 3;
            var enumerator = stack.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(enumerator.Current, target);
                target--;
            }
        }
    }
}
