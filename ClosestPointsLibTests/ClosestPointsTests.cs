using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClosestPointsLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClosestPointsLib.Tests
{
    [TestClass()]
    public class ClosestPointsTests
    {
        private void compareArrays(int[][] expected, int[][] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length, "expected & actual should have the same number of points");


            // Results can be in any order.  Sorting them then comparing them would work.
            var expectedSorted = expected.OrderBy(point => point[0]).ThenBy(point => point[1]);
            var actualSorted = actual.OrderBy(point => point[0]).ThenBy(point => point[1]);
            
            for (int i = 0; i < expectedSorted.Count(); i++)
            {
                var expectedPoint = expectedSorted.ElementAt(i);
                var actualPoint = actualSorted.ElementAt(i);
                Assert.IsTrue(arePointsEqual(expectedPoint, actualPoint), "expected & actual points are not equal");
            }
        }

        private bool arePointsEqual(int[] p1, int[] p2)
        {
            Assert.AreEqual(p1.Length, p2.Length, "expected & actual points have different number of dimensions");
            for (int i = 0; i < p1.Length; i++)
            {
                if (p1[i] != p2[i])
                    return false;
            }
            return true;
        }


        [TestMethod()]
        public void DistanceTest()
        {
            Assert.AreEqual(0, ClosestPointsToOrigin.Point.GetDistance(new int[] { 0, 0 }));
            Assert.AreEqual(1, ClosestPointsToOrigin.Point.GetDistance(new int[] { 1, 0 }));
            Assert.AreEqual(1, ClosestPointsToOrigin.Point.GetDistance(new int[] { 0, 1 }));
            Assert.AreEqual(1, ClosestPointsToOrigin.Point.GetDistance(new int[] { -1, 0 }));
            Assert.AreEqual(1, ClosestPointsToOrigin.Point.GetDistance(new int[] { 0, -1 }));
        }

        [TestMethod()]
        public void FindClosestPointTest()
        {
            var points = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 3 } };
            int k = 1;
            var expected = new int[][] { new int[] { 1, 1 } };
            var actual = ClosestPointsToOrigin.FindClosestPoints(points, k);
            compareArrays(expected, actual);
        }

        [TestMethod()]
        public void FindClosestPointsTest()
        {
            var points = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 3 } };
            int k = 2;
            var expected = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 } };
            var actual = ClosestPointsToOrigin.FindClosestPoints(points, k);
            compareArrays(expected, actual);
        }

        [TestMethod()]
        public void FindClosestPointsReversedTest()
        {
            var points = new int[][] { new int[] { 3, 3 }, new int[] { 2, 2 }, new int[] { 1, 1 } };
            int k = 2;
            var expected = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 } };
            var actual = ClosestPointsToOrigin.FindClosestPoints(points, k);
            compareArrays(expected, actual);
        }

        [TestMethod()]
        public void FindClosestPointsVariedTest()
        {
            var points = new int[][] { new int[] { 2, 3 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 1, 1 } };
            int k = 2;
            var expected = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            var actual = ClosestPointsToOrigin.FindClosestPoints(points, k);
            compareArrays(expected, actual);
        }
    }
}
