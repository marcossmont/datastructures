using System;
using System.Collections.Generic;
using System.Text;

namespace Hashtalbe
{
    public class MyHashtableNode<TKey, TValue>
    {
        public MyHashtableNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; }
        public TValue Value { get; set; }
    }
}
