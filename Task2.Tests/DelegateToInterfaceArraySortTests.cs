using NUnit.Framework;
using System;
using static Task2.DelegateToInterfaceArraySort;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task2.Tests
{
    [TestFixture]
    class DelegateToInterfaceArraySortTests
    {
        [Test]
        public static void SortRowSumInterfaceToDelegate_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 0 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 } };
            BubbleSortDelegateToInterface(array, ArraySortRowSum);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public static void SortRowSumInterfaceToDelegate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortDelegateToInterface(null, ArraySortRowSum));
        }

        [Test]
        public static void SortRowSumDescInterfaceToDelegate_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 } };
            BubbleSortDelegateToInterface(array, ArraySortRowSumDesc);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public static void SortRowSumDescInterfaceToDelegate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortDelegateToInterface(null, ArraySortRowSumDesc));
        }

        [Test]
        public void SortRowMaxElementInterfaceToDelegate_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 0 }, new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 } };
            BubbleSortDelegateToInterface(array, ArraySortRowMaxElement);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMaxElementInterfaceToDelegate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortDelegateToInterface(null, ArraySortRowMaxElement));
        }

        [Test]
        public void SortRowMaxElementDescInterfaceToDelegate_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 }, new[] { 0 }, };
            BubbleSortDelegateToInterface(array, ArraySortRowMaxElementDesc);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMaxElementDescInterfaceToDelegate_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortDelegateToInterface(null, ArraySortRowMaxElementDesc));
        }

        public static int ArraySortRowSum(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Sum() > array2.Sum()) return -1;
            else if (array1.Sum() == array2.Sum()) return 0;
            else return 1;

        }

        public static int ArraySortRowSumDesc(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Sum() < array2.Sum()) return -1;
            else if (array1.Sum() == array2.Sum()) return 0;
            else return 1;
        }

        public static int ArraySortRowMaxElement(int[] array1, int[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException(nameof(array1));
            if (array2 == null)
                throw new ArgumentNullException(nameof(array2));

            if (array1.Max() > array2.Max()) return -1;
            else if (array1.Max() == array2.Max()) return 0;
            else return 1;
        }

        public static int ArraySortRowMaxElementDesc(int[] array1, int[] array2)
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
