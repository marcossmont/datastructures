using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Hashtalbe
{
    public class MyHashTable<TKey, TValue> : IEnumerable<MyHashtableNode<TKey, TValue>>
    {
        private const decimal _fillFactor = 0.75M;

        MyHashTableArray<TKey, TValue> _array;
        private int _maxItems;
        private int _count;
        
        public MyHashTable() : this(100)
        {

        }
        
        public MyHashTable(int capacity)
        {
            if (capacity < 1)
            {
                throw new Exception("Hash table capacity shall be bigger than 0.");
            }

            _count = 0;
            _array = new MyHashTableArray<TKey, TValue>(capacity);
            _maxItems = (int)(capacity * _fillFactor) + 1;
        }

        public MyHashtableNode<TKey, TValue> GetByKey(TKey key)
        {
            return _array.GetByKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            if (_count >= _maxItems)
            {
                ResizeArray();
            }

            _array.Add(key, value);
            _count++;
        }

        private void ResizeArray()
        {
            var largerArray = new MyHashTableArray<TKey, TValue>(_array.Capacity * 2);

            foreach (var node in _array)
            {
                largerArray.Add(node.Key, node.Value);
            }

            _array = largerArray;

            _maxItems = (int)(_array.Capacity * _fillFactor) + 1;
        }

        public void Update(TKey key, TValue value)
        {
            _array.Update(key, value);
        }

        public void Remove(TKey key)
        {
            _array.Remove(key);
            _count--;
        }

        public IEnumerator<MyHashtableNode<TKey, TValue>> GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
