using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace VectorConsole
{
    public class QueueUsingLinkedLists<T>
    {
        private SinglyLinkedList<T> list = new SinglyLinkedList<T>();

        public void Enqueue(T element)
        {
            list.InsertLast(element);
        }

        public T Dequeue()
        {
            return list.RemoveFirst();
        }


    }
}
