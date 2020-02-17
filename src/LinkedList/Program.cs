using System;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new MyLinkedList<int>();

            linkedList.Add(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);
            linkedList.Add(4);
            linkedList.Add(5);

            linkedList.Remove(2);
            linkedList.Remove(5);
            linkedList.Remove(1);


            var item = linkedList.GetEnumerator();

            while (item.MoveNext())
            {
                Console.WriteLine(item.Current);
            }

            Console.ReadKey();
        }
    }

    
}
