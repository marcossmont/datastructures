using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class MyQueue<T> : IEnumerable<T>
    {
        public MyQueueElement<T> Head { get; private set; }
        public MyQueueElement<T> Tail { get; private set; }
        public bool IsEmpty => Head == null;


        public void Enqueue(T value)
        {
            var current = new MyQueueElement<T>(value);

            if (IsEmpty)
            {
                Head = current;
                Tail = current;
            }
            else
            {
                Tail.Next = current;
                Tail = current;
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
