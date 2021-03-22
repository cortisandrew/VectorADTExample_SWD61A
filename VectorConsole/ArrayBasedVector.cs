using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorConsole
{
    internal class ArrayBasedVector<T> : IVectorADT<T>
    {
        private int size = 0;

        protected const int INITIAL_SIZE = 4;

        private T[] V = new T[INITIAL_SIZE];
        public int Size()
        {
            return size;
        }
        public bool IsEmpty()
        {
            /*
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            */

            return (size == 0);
        }


        public T ElementAtRank(int rank)
        {
            if (rank < 0 || rank >= Size())
            {
                throw new ArgumentOutOfRangeException(
                    "rank",
                    rank,
                    $"The value of the parameter rank is outside the acceptable bounds.  The value should be between 0 and {Size() - 1} inclusive.");
            }

            return V[rank];
        }
        public void Append(T newElement)
        {
            InsertAtRank(Size(), newElement);
        }
        public void InsertAtRank(int rank, T newElement)
        {
            if (rank < 0 || rank > Size())
            {
                throw new ArgumentOutOfRangeException(
                    "rank",
                    rank,
                    $"The value of the parameter rank is outside the acceptable bounds.  The value should be between 0 and {Size()} inclusive.");
            }

            if (Size() == V.Length)
            {
                // The array is currently full!
                // We need a larger array to store this new information

                T[] newV = new T[V.Length * 2];
                V.CopyTo(newV, 0);  // copies each element one after the other
                V = newV;

                // Exercise:
                // Update this method to copy everything, but leave an empty space at position rank
                // The new element can be inserted without having to shift again.

                // remember to return so as not to insert the same element twice!
            }

            // shift all elements from rank till the end,
            // to make an available space at position rank
            //for (int i = rank; i <= Size() -1; i++)
            for (int i = Size() - 1; i >= rank; i--)
            {
                V[i + 1] = V[i];
            }

            // once this position is empty and available, add the new item
            V[rank] = newElement;

            // increment size
            size++;
        }

        public T RemoveAtRank(int rank)
        {
            T output = V[rank];

            for (int i = rank; i <= Size() - 2; i++)
            {
                V[i] = V[i + 1];
            }

            V[Size() - 1] = default;
            size--;

            return output;
        }

        public T ReplaceAtRank(int rank, T newElement)
        {
            T output = V[rank];

            V[rank] = newElement;

            return output;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("{");
            output.Append(String.Join(",", V.Take(Size())));
            output.Append("}");

            return output.ToString();
        }
    }
}
