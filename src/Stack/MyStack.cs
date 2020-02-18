using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        public MyStackElement<T> Top { get; private set; }
        public bool IsEmpty => Top == null;
        
        public void Push(T value)
        {
            var current = new MyStackElement<T>(value);
            current.Next = Top;
            Top = current;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new Exception("Stack is empty");
            }

            var current = Top;
            Top = Top.Next;

            return current.Value; 
        }

        public T Pick()
        {
            if (IsEmpty)
            {
                throw new Exception("Stack is empty");
            }

            return Top.Value;
        }   

        public IEnumerator<T> GetEnumerator()
        {
            var current = Top;

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
