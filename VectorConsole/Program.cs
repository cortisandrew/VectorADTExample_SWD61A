using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace VectorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Main(new string[] { });


            //Timing();

            //LinkedList<string> myList = new LinkedList<string>();

            //TestLinkedList();

            //TestStack();

            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();

            doublyLinkedList.InsertFirst("D");
            DoublyLinkedListNode<string> cursor = doublyLinkedList.Head;

            doublyLinkedList.InsertBefore(cursor, "A");
            doublyLinkedList.InsertBefore(cursor, "B");
            doublyLinkedList.InsertBefore(cursor, "C1");
            doublyLinkedList.InsertBefore(cursor, "C2");

            doublyLinkedList.InsertAfter(cursor, "E");

        }

        private static void TestStack()
        {
            StackUsingSinglyLinkedList<string> stack = new StackUsingSinglyLinkedList<string>();
            Console.WriteLine(stack);

            stack.Push("A");
            Console.WriteLine(stack);

            stack.Push("B");
            Console.WriteLine(stack);

            stack.Push("C");
            Console.WriteLine(stack);

            Console.WriteLine($"Popped element: {stack.Pop()}");
            Console.WriteLine(stack);

            stack.Push("D");
            Console.WriteLine(stack);

            Console.WriteLine($"Popped element: {stack.Pop()}");
            Console.WriteLine(stack);

            Console.WriteLine($"Popped element: {stack.Pop()}");
            Console.WriteLine(stack);

            Console.WriteLine($"Popped element: {stack.Pop()}");
            Console.WriteLine(stack);

            try
            {
                Console.WriteLine($"Popped element: {stack.Pop()}");
            }
            catch
            {
                Console.WriteLine("Exception caught!");
            }
        }

        private static void TestLinkedList()
        {
            SinglyLinkedList<string> linkedList = new SinglyLinkedList<string>();

            Console.WriteLine("Building the linked list...");
            Console.WriteLine(linkedList);

            linkedList.InsertFirst("D");

            Console.WriteLine(linkedList);

            linkedList.InsertFirst("C");

            Console.WriteLine(linkedList);

            linkedList.InsertFirst("B");

            Console.WriteLine(linkedList);

            linkedList.InsertFirst("A");

            Console.WriteLine(linkedList);

            Console.WriteLine();
            Console.WriteLine("Removing an element:");
            Console.WriteLine($"Removed the value {linkedList.RemoveFirst()}");
            Console.WriteLine(linkedList);

            Console.WriteLine();
            Console.WriteLine("Removing an element:");
            Console.WriteLine($"Removed the value {linkedList.RemoveFirst()}");
            Console.WriteLine(linkedList);

            Console.WriteLine();
            Console.WriteLine("Removing an element:");
            Console.WriteLine($"Removed the value {linkedList.RemoveFirst()}");
            Console.WriteLine(linkedList);

            Console.WriteLine();
            Console.WriteLine("Removing an element:");
            Console.WriteLine($"Removed the value {linkedList.RemoveFirst()}");
            Console.WriteLine(linkedList);

            Console.WriteLine();
            Console.WriteLine("Removing an element:");

            try
            {
                Console.WriteLine($"Removed the value {linkedList.RemoveFirst()}");
                Console.WriteLine(linkedList);
            }
            catch (InvalidOperationException e)
            {
                // Make sure to handle this exception properly!
                Console.WriteLine(e.Message);
            }
        }

        private static void Timing()
        {
            // FirstTest();
            int numberOfOperations = 100000;

            // Execute once to allow for compilation
            TimeMethodAppend(100); // C# may use JIT compilation here which slows us down considerably!
            TimeMethodInsertAtRankZero(100);

            // The actual timing happens here - we avoided JIT compilation issues (because they would be handled above)
            Console.WriteLine($"For {numberOfOperations} operations, the time taken is:");
            Console.WriteLine($"{TimeMethodAppend(numberOfOperations)} ticks for Append");
            Console.WriteLine($"{TimeMethodInsertAtRankZero(numberOfOperations)} ticks for InsertAtRankZero");
        }

        private static double TimeMethodAppend(int problemSize, int repetitions = 5)
        {
            Stopwatch sw = new Stopwatch();
            List<long> results = new List<long>(repetitions);

            for (int r = 0; r < repetitions; r++)
            {
                sw.Reset();
                ArrayBasedVector<int> arrayBasedVector = new ArrayBasedVector<int>();

                for (int i = 0; i < problemSize; i++)
                {
                    sw.Start();
                    arrayBasedVector.Append(1);
                    sw.Stop();
                }

                results.Add(sw.ElapsedTicks);
            }

            return results.Average();
        }

        private static double TimeMethodInsertAtRankZero(int numberOfOperations, int repetitions = 5)
        {
            Stopwatch sw = new Stopwatch();
            List<long> results = new List<long>(repetitions);

            for (int r = 0; r < repetitions; r++)
            {
                sw.Reset();
                ArrayBasedVector<int> arrayBasedVector = new ArrayBasedVector<int>();

                for (int i = 0; i < numberOfOperations; i++)
                {
                    sw.Start();
                    arrayBasedVector.InsertAtRank(0, 1);
                    sw.Stop();
                }

                results.Add(sw.ElapsedTicks);
            }

            return results.Average();
        }

        private static void FirstTest()
        {
            ArrayBasedVector<int> arrayBasedVector = new ArrayBasedVector<int>();

            arrayBasedVector.InsertAtRank(0, 7);
            arrayBasedVector.InsertAtRank(1, 3);
            arrayBasedVector.InsertAtRank(2, 2);
            arrayBasedVector.InsertAtRank(3, 9);
            arrayBasedVector.InsertAtRank(4, 8);

            Console.WriteLine(arrayBasedVector);

            arrayBasedVector.InsertAtRank(2, 5);

            Console.WriteLine(arrayBasedVector);

            arrayBasedVector.RemoveAtRank(2);

            arrayBasedVector.ReplaceAtRank(4, 0);
            Console.WriteLine(arrayBasedVector);

            List<int> list = new List<int>();
            list.Add(3);
        }
    }
}
