using System;
using System.Collections.Generic;
using System.Text;

namespace VectorConsole
{
    /// <summary>
    /// This is going to be very slow!
    /// </summary>
    public class QueueUsingArrayBasedVector<T>
    {
        ArrayBasedVector<T> vector = new ArrayBasedVector<T>();

        public void Enqueue(T element)
        {
            vector.Append(element);
        }

        public T Dequeue()
        {
            return vector.RemoveAtRank(0);
        }
    }
}
