using System;
using System.Collections.Generic;
using System.Text;

namespace VectorConsole
{
    public class SinglyLinkedListNode<T>
    {
        public T Element { get; set; }
        public SinglyLinkedListNode<T> Next { get; internal set; }

        public override string ToString()
        {
            return $"( {Element.ToString()} )";
        }
    }
}
