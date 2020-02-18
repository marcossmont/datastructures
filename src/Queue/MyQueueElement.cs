namespace Queue
{
    public class MyQueueElement<T>
    {
        public MyQueueElement(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public MyQueueElement<T> Next { get; set; }
    }
}