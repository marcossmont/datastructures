using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Hashtalbe
{
    public class MyHashTableArray<TKey, TValue> : IEnumerable<MyHashtableNode<TKey, TValue>>
    {
        private LinkedList<MyHashtableNode<TKey, TValue>>[] _array;
        private readonly int _capacity;

        public int Capacity => _capacity;

        public MyHashTableArray(int capacity)
        {
            _array = new LinkedList<MyHashtableNode<TKey, TValue>>[capacity];

            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = new LinkedList<MyHashtableNode<TKey, TValue>>();
            }

            _capacity = capacity;
        }

        public void Add(TKey key, TValue value)
        {
            var index = GetIndex(key);

            var currentIndexValue = _array[index];

            foreach (var node in currentIndexValue)
            {
                if (node.Key.Equals(key))
                {
                    throw new Exception($"The hashtable already has a node with key  {key}.");
                }
            }

            currentIndexValue.AddFirst(new MyHashtableNode<TKey, TValue>(key, value));
        }

        public MyHashtableNode<TKey, TValue> GetByKey(TKey key)
        {
            var index = GetIndex(key);

            var arrayNode = _array[index];

            var currentNode = arrayNode.First;
            while (currentNode != null)
            {
                if (currentNode.Value.Key.Equals(key))
                {
                    return currentNode.Value;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        public void Update(TKey key, TValue value)
        {
            var index = GetIndex(key);

            var currentArrayNode = _array[index];
            if (currentArrayNode.Count == 0)
                throw new Exception($"Unable to find node with the key {key} to be updated.");

            foreach (var node in currentArrayNode)
            {
                if (node.Key.Equals(key))
                {
                    node.Value = value;
                    return;
                }
            }

            throw new Exception($"Unable to find node with the key {key} to be updated.");
        }

        public void Remove(TKey key)
        {
            var index = GetIndex(key);

            var currentIndexValue = _array[index];
            if (currentIndexValue == null)
                throw new Exception($"Unable to find node with the key {key} to be removed.");

            var currentNode = currentIndexValue.First;
            while (currentNode != null)
            {
                if (currentNode.Value.Key.Equals(key))
                {
                    currentIndexValue.Remove(currentNode);
                    return;
                }

                currentNode = currentNode.Next;
            }

            throw new Exception($"Unable to find node with the key {key} to be updated.");
        }


        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }

        public IEnumerator<MyHashtableNode<TKey, TValue>> GetEnumerator()
        {
            foreach (var arrayNode in _array)
            {                
                foreach (var node in arrayNode)
                {
                    yield return node;
                }   
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
