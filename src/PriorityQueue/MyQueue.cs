using System;
using System.Collections;
using System.Collections.Generic;

namespace PriorityQueue
{
    public class MyQueue<T> : IEnumerable<T>
    {
        public MyQueueElement<T> Head { get; private set; }
        public bool IsEmpty => Head == null;


        public void Enqueue(T value, Priority priority = Priority.Medium)
        {
            var toAdd = new MyQueueElement<T>(value, priority);

            if (IsEmpty)
            {
                Head = toAdd;
                return;
            }

            var current = Head;
            MyQueueElement<T> previews = null;
            while (current != null && ((int)current.Priority <= (int)toAdd.Priority))
            {
                previews = current;
                current = current.Next;
            }

            toAdd.Next = current;
            if (previews == null)
            {
                Head = toAdd;
            }
            else
            {
                previews.Next = toAdd;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new Exception("Queue is empty");
            }

            var toDequeue = Head;
            Head = toDequeue.Next;

            return toDequeue.Value;
        }

        public T Pick()
        {
            if (IsEmpty)
            {
                throw new Exception("Queue is empty");
            }

            return Head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
