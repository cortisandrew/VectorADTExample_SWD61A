using System;
using System.Collections.Generic;
using System.Text;

namespace VectorConsole
{
    public class DoublyLinkedListNode<T>
    {
        public T Element { get; set; }

        public DoublyLinkedListNode<T> Prev { get; internal set; }

        public DoublyLinkedListNode<T> Next { get; internal set; }

        public override string ToString()
        {
            return $"( {Element.ToString()} )";
        }

    }
}
