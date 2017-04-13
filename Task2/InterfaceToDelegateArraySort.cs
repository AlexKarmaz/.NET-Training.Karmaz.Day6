using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class InterfaceToDelegateArraySort
    {
        public static void BubbleSort(int[][] array, IComparer<int[]> comparer)
        {
            BubbleSortDegateToInterface(array, comparer.Compare);
        }

        private static void BubbleSortDegateToInterface(int[][] array, Func<int[], int[], int> compare)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (compare == null)
                throw new ArgumentNullException(nameof(compare));

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (compare(array[j], array[j + 1]) < 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

        }

        private static void Swap(ref int[] firstArray, ref int[] secondArray)
        {
            int[] buff = firstArray;
            firstArray = secondArray;
            secondArray = buff;
        }
    }
}

