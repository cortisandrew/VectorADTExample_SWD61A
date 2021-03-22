using System;
using System.Collections.Generic;
using System.Text;

namespace VectorConsole
{
    public interface IVectorADT<T>
    {
        /// <summary>
        /// Returns the number of elements in the VectorADT
        /// </summary>
        /// <returns>The number of elements stored</returns>
        int Size();

        bool IsEmpty();

        T ElementAtRank(int rank);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank">The value of the rank must be between 0 and Size() - 1 included</param>
        /// <param name="newElement"></param>
        /// <returns></returns>
        T ReplaceAtRank(int rank, T newElement);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank">The value of the rank must be between 0 and Size() included</param>
        /// <param name="newElement"></param>
        void InsertAtRank(int rank, T newElement);

        T RemoveAtRank(int rank);
    }
}
