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
        /// Sorts jagged integer array in rows' sums ascending order
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SortRowSum(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].Sum() > array[j + 1].Sum())
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged integer array in rows' sums descending order
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SortRowSumDesc(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].Sum() < array[j + 1].Sum())
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged integer array in rows' maximum elements ascending order
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SortRowMaxElement(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].Max() > array[j + 1].Max())
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged integer array in rows' maximum elements descending order
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SortRowMaxElementDesc(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].Max() < array[j + 1].Max())
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged integer array in rows' minimum elements ascending order
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SortRowMinElement(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].Min() > array[j + 1].Min())
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged integer array in rows' minimum elements descending order
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SortRowMinElementDesc(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j].Min() < array[j + 1].Min())
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
}
