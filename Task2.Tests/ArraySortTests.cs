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
            SortRowSum(array);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public static void SortRowSum_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SortRowSum(null));
        }

        [Test]
        public static void SortRowSumDesc_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 } };
            SortRowSumDesc(array);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public static void SortRowSumDesc_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SortRowSumDesc(null));
        }

        [Test]
        public void SortRowMaxElement_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 0 }, new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 } };
            SortRowMaxElement(array);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMaxElement_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SortRowMaxElement(null));
        }

        [Test]
        public void SortRowMaxElementDesc_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 }, new[] { 0 }, };
            SortRowMaxElementDesc(array);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMaxElementDesc_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SortRowMaxElementDesc(null));
        }

        [Test]
        public void SortRowMinElement_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            SortRowMinElement(array);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMinElement_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SortRowMinElement(null));
        }

        [Test]
        public void SortRowMinElementDesc_PositiveTest()
        {
            int[][] array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, new[] { 4, 3, 8, 5, 7 } };
            int[][] testArray = { new[] { 4, 3, 8, 5, 7 }, new[] { 0 }, new[] { 4, 2, -1, 9, -8, 10 }};
            SortRowMinElementDesc(array);

            IStructuralEquatable arrays = array;

            Assert.AreEqual(arrays.Equals(testArray, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortRowMinElementDesc_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SortRowMinElementDesc(null));
        }
    }
}
