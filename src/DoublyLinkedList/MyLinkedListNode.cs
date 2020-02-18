using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    public class MyLinkedListNode<T>
    {

        public MyLinkedListNode(T item)
        {
            Data = item;
        }

        public T Data { get; set; }
        public MyLinkedListNode<T> Next { get; set; }
        public MyLinkedListNode<T> Previews { get; set; }
    }
}
