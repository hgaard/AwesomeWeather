using System;

namespace Domain
{
    public class DataPoint<T>
    {
        public DateTime At { get; private set; }
        public T Value { get; private set; }

        public DataPoint(T value, DateTime at)
        {
            Value = value;
            At = at;
        }
    }
}