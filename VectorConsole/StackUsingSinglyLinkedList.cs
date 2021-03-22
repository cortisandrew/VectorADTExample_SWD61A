using System;
using System.Collections.Generic;
using System.Text;

namespace VectorConsole
{
    public class StackUsingSinglyLinkedList<T>
    {
        SinglyLinkedList<T> linkedList = new SinglyLinkedList<T>();

        public void Push(T element)
        {
            linkedList.InsertFirst(element);
        }

        public T Pop()
        {
            try
            {
                return linkedList.RemoveFirst();
            } catch (InvalidOperationException ex)
            {
                InvalidOperationException ex2 = new InvalidOperationException("You cannot pop an element from an empty stack", ex);
                // log this information somewhere

                Console.Error.WriteLine("Some info...");

                throw ex2;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            SinglyLinkedListNode<T> cursor = linkedList.Head;

            sb.AppendLine("Top of Stack:");
            while (cursor != null)
            {
                sb.AppendLine(cursor.Element.ToString());
                cursor = cursor.Next;
            }
            sb.AppendLine("Bottom of Stack");

            return sb.ToString();

        }
    }
}
