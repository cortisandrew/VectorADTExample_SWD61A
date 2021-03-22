using System;
using System.Collections.Generic;
using System.Text;

namespace VectorConsole
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> Head { get; internal protected set; }

        public SinglyLinkedListNode<T> Tail { get; internal protected set; }

        public int Size { get; protected internal set; }

        //public SinglyLinkedListNode<T> Tail { get; internal protected set; }

        public void InsertFirst(T element)
        {
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>() { Element = element };
            newNode.Next = Head;

            if (Head == null) // or same thing, Size == 0
            {
                // we are adding the first element to the linked list
                // the list is currently empty, but the new element will be BOTH the first(head) and the last(tail) element!
                Tail = newNode;
            }

            Head = newNode;
            Size++;
        }

        public T RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("The linked list is currently empty.  You can't remove from an empty linked list!");
            }

            T output = Head.Element;

            Head = Head.Next;

            Size--;

            if (Head == null)
            {
                // we have removed the last element from the list!
                Tail = null;
            }

            return output;
        }

        public void InsertLast(T element)
        {
            // Situation (i) - list is empty
            if (Head == null)
            {
                // this is equivalent to InsertFirst
                InsertFirst(element);
                return;
            }

            // we now know that the list is not empty!
            // Situation 2
            InsertAfter(Tail, element);
        }

        public T RemoveLast()
        {
            // Validation - list is empty!
            // Exercise!

            // Situation (i) - only 1 element in list
            if (Size == 1)
            {
                return RemoveFirst();
            }

            // Situation (ii) - more than 1 element in list
            T output = Tail.Element;

            // We also want to remove the last element from the list!
            SinglyLinkedListNode<T> previousNode = Previous(Tail); // Magic happens here!
            previousNode.Next = null;

            Tail = null; 

            Size--;
            return output;
        }

        private SinglyLinkedListNode<T> Previous(SinglyLinkedListNode<T> currentNode)
        {
            if (currentNode == null)
            {
                throw new ArgumentNullException();
            }

            if (currentNode == Head)
            {
                throw new InvalidOperationException(); // or return a null value - your design! Decide how you wish to handle this situation
            }

            SinglyLinkedListNode<T> cursor = Head;

            // We still have a node after this cursor... so this cursor is possible the previous we want!
            while (cursor.Next != null)
            {
                // is this the currect result?
                if (cursor.Next == currentNode)
                {
                    // found the correct result!
                    return cursor;
                }

                cursor = cursor.Next;
            }

            // this means that the current Node is not within the linked list!
            throw new InvalidOperationException();
        }

        public void InsertAfter(SinglyLinkedListNode<T> cursor, T element)
        {
            // Validation
            if (cursor == null)
            {
                // You cannot insert after a null/nothing
                throw new ArgumentNullException("cursor", "You cannot add after a null!");
            }

            // Step (i) - Create new info
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>()
            {
                Element = element,
                Next = cursor.Next
            };

            // Step (ii) - Update info (can destroy old links)
            cursor.Next = newNode;

            // Step (iii)
            if (cursor == Tail)
            {
                // the new node is now the new tail... since we have added after the last node
                Tail = newNode;
            }

            // Step (iv)
            Size++;
        }

        public T RemoveAfter(SinglyLinkedListNode<T> cursor, T element)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Head -> ");

            // Starting from the first node
            SinglyLinkedListNode<T> cursor = Head;

            // Keep looping until we exit the linked list
            while (cursor != null)
            {
                // do some work...
                sb.Append(cursor.ToString());
                sb.Append(" -> ");

                // move a single step forward
                cursor = cursor.Next;
            } // Eventually we arrive at the end of the list, the Next will be null and we can exit

            sb.Append("NULL");

            // Exercise: Print also the Head and Tail and Size of the list, to check these values
            return sb.ToString();
        }
    }
}
