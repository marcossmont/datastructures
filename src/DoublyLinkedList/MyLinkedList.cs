using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    public class MyLinkedList<T> : ICollection<T>
    {
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public MyLinkedListNode<T> Head { get; private set; }
        public MyLinkedListNode<T> Tail { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            var node = new MyLinkedListNode<T>(item);
            
            if (IsEmpty)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previews = Tail;
            }

            Tail = node;
            
            Count++;
        }

        public void AddFirst(T item)
        {
            var node = new MyLinkedListNode<T>(item);
            
            if (IsEmpty)
            {
                Tail = node;
            }
            else
            {
                Head.Previews = node;
                node.Next = Head;
            }

            Head = node;

            Count++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
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
            var current = Head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current.Previews == null)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        current.Previews.Next = current.Next;
                    }

                    if (current.Next == null)
                    {
                        Tail = current.Previews;
                    }
                    else
                    {
                        current.Next.Previews = current.Previews;
                    }

                    Count--;
                    return true;
                }

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
