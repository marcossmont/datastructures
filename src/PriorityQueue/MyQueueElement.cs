namespace PriorityQueue
{
    public class MyQueueElement<T>
    {
        public MyQueueElement(T value, int priority = 1)
        {
            Value = value;
            Priority = priority;
        }

        public T Value { get; set; }
        public int Priority { get; set; }
        public MyQueueElement<T> Next { get; set; }
    }
}