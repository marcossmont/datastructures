using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class MyLinkedList<T> : ICollection<T>
    {
        public int Count { get; private set; }

        public MyLinkedListNode<T> Head { get; private set; }
        
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (Head == null)
            {
                Head = new MyLinkedListNode<T>(item);
            }
            else
            {
                var current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new MyLinkedListNode<T>(item);
            }            

            Count++;
        }

        public void AddFirst(T item)
        {
            var current = new MyLinkedListNode<T>(item);
            current.Next = Head;

            Head = current;

            Count++;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            while (current != null)
            {
                array[arrayIndex] = current.Data;
                arrayIndex++;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            MyLinkedListNode<T> previews = null;
            var current = Head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previews == null)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        previews.Next = current.Next;
                    }

                    current = null;

                    Count--;
                    return true;
                }

                previews = current;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
