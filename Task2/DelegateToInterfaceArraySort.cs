using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class DelegateToInterfaceArraySort
    {
        private static void BubbleSort(int[][] array, IComparer<int[]> comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) < 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        public static void BubbleSortDelegateToInterface(int[][] array, Func<int[], int[], int> compare)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (compare == null)
                throw new ArgumentNullException(nameof(compare));

            BubbleSort(array, new ArraySortAdapter<int[]>(compare));

        }

        private static void Swap(ref int[] firstArray, ref int[] secondArray)
        {
            int[] buff = firstArray;
            firstArray = secondArray;
            secondArray = buff;
        }
    }

    public  class ArraySortAdapter<T> : IComparer<T>
    {
        private Func<T, T, int> func;

        public ArraySortAdapter(Func<T, T, int> comparator)
        {
            func = comparator;
        }
        
        public int Compare(T x, T y)
        {
            if (x != null && y != null)
                return func(x, y);
            if (x == null && y == null)
                return 0;
            if (x == null)
                return 1;
            return -1;
        }
    }
}