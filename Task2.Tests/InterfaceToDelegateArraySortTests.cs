using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Task2.InterfaceToDelegateArraySort;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task2.Tests
{
    [TestFixture]
    class InterfaceToDelegateArraySortTests
    {
        [Test]
        public static void SortRowSumInterfaceToDelegate_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 0 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 } };
            BubbleSort(array, new ArraySortRowSumInterfaceToDelegate());

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public static void SortRowSumInterfaceToDelegate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort(null, new ArraySortRowSumInterfaceToDelegate()));
        }

        [Test]
        public static void SortRowSumDescInterfaceToDelegate_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 } };
            BubbleSort(array, new ArraySortRowSumDescInterfaceToDelegate());

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public static void SortRowSumDescInterfaceToDelegate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort(null, new ArraySortRowSumDescInterfaceToDelegate()));
        }

        [Test]
        public void SortRowMaxElementInterfaceToDelegate_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 0 }, new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 } };
            BubbleSort(array, new ArraySortRowMaxElementInterfaceToDelegate());

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMaxElementInterfaceToDelegate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort(null, new ArraySortRowMaxElementInterfaceToDelegate()));
        }

        [Test]
        public void SortRowMaxElementDescInterfaceToDelegate_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 }, new[] { 0 }, };
            BubbleSort(array, new ArraySortRowMaxElementDescInterfaceToDelegate());

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMaxElementDescInterfaceToDelegate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort(null, new ArraySortRowMaxElementInterfaceToDelegate()));
        }
    }

    public class ArraySortRowSumInterfaceToDelegate : IComparer<int[]>
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Sum() > array2.Sum()) return -1;
            else if (array1.Sum() == array2.Sum()) return 0;
            else return 1;

        }
    }

    public class ArraySortRowSumDescInterfaceToDelegate : IComparer<int[]>
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Sum() < array2.Sum()) return -1;
            else if (array1.Sum() == array2.Sum()) return 0;
            else return 1;
        }
    }

    public class ArraySortRowMaxElementInterfaceToDelegate : IComparer<int[]>
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Max() > array2.Max()) return -1;
            else if (array1.Max() == array2.Max()) return 0;
            else return 1;
        }
    }

    public class ArraySortRowMaxElementDescInterfaceToDelegate : IComparer<int[]>
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Max() < array2.Max()) return -1;
            else if (array1.Max() == array2.Max()) return 0;
            else return 1;
        }
    }
}
