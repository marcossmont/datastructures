namespace PriorityQueue
{
    public class MyQueueElement<T>
    {
        public MyQueueElement(T value, Priority priority = Priority.Medium)
        {
            Value = value;
            Priority = priority;
        }

        public T Value { get; set; }
        public Priority Priority { get; set; }
        public MyQueueElement<T> Next { get; set; }
    }
}