using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStackElement<T>
    {
        public MyStackElement(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public MyStackElement<T> Next { get; set; }
    }
}
