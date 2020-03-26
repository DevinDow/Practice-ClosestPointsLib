using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClosestPointsLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClosestPointsLib.Tests
{
    [TestClass()]
    public class ClosestPointsTests
    {
        private void compareArrays(int[][] expected, int[][] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length, "arrays are not the same length");
            for (int i = 0; i < expected.Length; i++)
            {
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Assert.AreEqual(expected[i][j], actual[i][j], string.Format("coord %d of point %d are not the same", j, i));
                }
            }

        }


        [TestMethod()]
        public void FindClosestPointTest()
        {
            var points = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 3 } };
            int k = 1;
            var expected = new int[][] { new int[] { 1, 1 } };
            var actual = ClosestPoints.FindClosestPoints(points, k);
            compareArrays(expected, actual);
        }

        [TestMethod()]
        public void FindClosestPointsTest()
        {
            var points = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 3 } };
            int k = 2;
            var expected = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 } };
            var actual = ClosestPoints.FindClosestPoints(points, k);
            compareArrays(expected, actual);
        }

        [TestMethod()]
        public void FindClosestPointsReversedTest()
        {
            var points = new int[][] { new int[] { 3, 3 }, new int[] { 2, 2 }, new int[] { 1, 1 } };
            int k = 2;
            var expected = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 } };
            var actual = ClosestPoints.FindClosestPoints(points, k);
            compareArrays(expected, actual);
        }

        [TestMethod()]
        public void FindClosestPointsVariedTest()
        {
            var points = new int[][] { new int[] { 2, 3 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 1, 1 } };
            int k = 2;
            var expected = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            var actual = ClosestPoints.FindClosestPoints(points, k);
            compareArrays(expected, actual);
        }
    }
}
