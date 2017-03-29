using System;
using static Task2.ArraySort;
using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class ArraySortTests
    {
        [Test]
        public static void SortRowSum_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 0 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 } };
            BubbleSort(array, new ArraySortRowSum());

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public static void SortRowSum_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort(null, new ArraySortRowSum()));
        }

        [Test]
        public static void SortRowSumDesc_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 } };
            BubbleSort(array, new ArraySortRowSumDesc());

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public static void SortRowSumDesc_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort(null, new ArraySortRowSumDesc()));
        }

        [Test]
        public void SortRowMaxElement_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 0 }, new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 } };
            BubbleSort(array, new ArraySortRowMaxElement());

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMaxElement_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort(null, new ArraySortRowMaxElement()));
        }

        [Test]
        public void SortRowMaxElementDesc_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 }, new[] { 0 }, };
            BubbleSort(array, new ArraySortRowMaxElementDesc());

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMaxElementDesc_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort(null, new ArraySortRowMaxElement()));
        }
    }

    public class ArraySortRowSum : Icomparer
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

    public class ArraySortRowSumDesc : Icomparer
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

    public class ArraySortRowMaxElement : Icomparer
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

    public class ArraySortRowMaxElementDesc : Icomparer
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
