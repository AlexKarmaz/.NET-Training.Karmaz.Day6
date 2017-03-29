using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Contains methods for sorting rows of a jagged array
    /// </summary>
    public static class ArraySort
    {
        #region Public Methods
        /// <summary>
        /// Sorts jagged integer array
        /// </summary>
        /// <param name="array">The array to sort</param>
        /// <param name="comparer">The object contains a method to compare two arrays</param>
        /// <returns>The sorted array</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void BubbleSort(int[][] array, Icomparer comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

             for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparer.Compare(array[j],array[j+1]) < 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region Private Methods
        private static void Swap(ref int[] firstArray, ref int[] secondArray)
        {
            int[] buff = firstArray;
            firstArray = secondArray;
            secondArray = buff;
        }
        #endregion
    }

    /// <summary>
    /// Contains methods for comparing arrays
    /// </summary>
    public interface Icomparer
    {
        /// <summary>
        /// Compares two arrays
        /// </summary>
        /// <param name="firstArray">First array</param>
        /// <param name="b">Second array</param>
        int Compare(int[] firstArray, int[] secondArray);
    }
}
