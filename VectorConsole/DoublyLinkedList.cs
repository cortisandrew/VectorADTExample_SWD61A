using System;
using System.Collections.Generic;
using System.Text;

namespace VectorConsole
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head { get; protected set; }
        public DoublyLinkedListNode<T> Tail { get; protected set; }

        public int Size { get; protected set; }

        public void InsertFirst(T element)
        {
            // Step (i) construction
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>()
            {
                Element = element,
                Next = Head,
                Prev = null
            };

            // Step (ii) updates...
            if (Head == null)
            {
                // list was empty,
                Tail = newNode;
            }
            else { 
                // update old Head (only if it exists!)
                Head.Prev = newNode;
            }
            // The new node is the Head!
            Head = newNode;

            Size++;
        }

        public void InsertAfter(DoublyLinkedListNode<T> cursor, T element)
        {
            if (cursor == null)
            {
                throw new ArgumentNullException();
            }

            if (cursor == Tail)
            {
                InsertLast(element);
                return;
            }

            // there is at least one node after the cursor
            DoublyLinkedListNode<T> nextNode = cursor.Next;

            InsertBefore(nextNode, element);
        }

        private void InsertLast(T element)
        {
            throw new NotImplementedException();
        }

        public void InsertBefore(DoublyLinkedListNode<T> cursor, T element)
        {
            // Validate for cursor is null - Exercise

            if (cursor == Head)
            {
                // this is equivalent to InsertFirst
                InsertFirst(element);
                return;
            }

            // otherwise, cursor is NOT the first node in the linked list
            // step (i)
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>()
            {
                Element = element,
                Next = cursor,
                Prev = cursor.Prev
            };

            // Step (ii)
            DoublyLinkedListNode<T> prevNode = cursor.Prev;
            // newNode.Prev, would also have pointed to the correct Previous node!
            prevNode.Next = newNode;

            // equivalent to:
            // (cursor.Prev).Next = newNode;

            // Step (iii)
            cursor.Prev = newNode;

            // Step (iv)
            Size++;
        }


        public T RemoveBefore(DoublyLinkedListNode<T> cursor)
        {
            if (cursor == null || cursor == Head)
            {
                throw new Exception("Write interesting validation!");
            }

            if (cursor.Prev == Head)
            {
                return RemoveFirst();
            }

            // else cursor.Prev != Head, OR equivalent nodeToRemove != Head
            // we can remove the node that is previous to this current node
            // we are guaranteed that we are NOT removing the head
            DoublyLinkedListNode<T> nodeToRemove = cursor.Prev;
            DoublyLinkedListNode<T> nodeBeforeNodeToRemove = nodeToRemove.Prev;

            return RemoveAfter(nodeBeforeNodeToRemove);
        }

        private T RemoveAfter(DoublyLinkedListNode<T> cursor)
        {
            if (cursor == null || cursor == Tail)
            {
                throw new Exception("Write interesting validation!");
            }

            if (cursor.Next == Tail)
            {
                return RemoveLast();
            }

            T output = cursor.Next.Element;

            // step (i)
            DoublyLinkedListNode<T> nodeAfter = cursor.Next.Next;
            nodeAfter.Prev = cursor;

            // step (ii)
            cursor.Next = nodeAfter;

            Size--;
            return output;
        }

        private T RemoveLast()
        {
            // Exercise!
            throw new NotImplementedException();
        }

        public T RemoveFirst()
        {
            if (Head == null)
            {
                // You cannot remove from an empty list!
                throw new InvalidOperationException();
            }

            T output = Head.Element;

            if (Head == Tail)
            {
                // We have a list of only 1 node
                // We are removing the only node!
                Tail = null;
            }

            // Update the head
            Head = Head.Next;

            // Now head is pointing to the new head
            Head.Prev = null;

            Size--;
            return output;
        }
    }
}
