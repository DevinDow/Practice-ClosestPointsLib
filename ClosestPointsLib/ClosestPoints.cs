using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestPointsLib
{
    public class ClosestPoints
    {
        /// <summary>
        /// Find k points closest to the origin (0,0)
        /// </summary>
        /// <param name="points">array of tuples of all points</param>
        /// <param name="k">number of closest points to find</param>
        /// <returns>array of tuples of closest points</returns>
        public static int[][] FindClosestPoints(int[][] points, int k)
        {
            // Throw if K is greater than points count
            if (k > points.Length)
            {
                throw new Exception("k is bigger than points count.");
            }

            // Throw if K is less than 1
            if (k < 1)
            {
                throw new Exception("k is less than 1.");
            }

            // sort points by distance
            IEnumerable<int[]> sortedPoints = points.OrderBy(point => Point.GetDistance(point));

            // return first k closest points
            return sortedPoints.Take(k).ToArray();
        }


        // Point class
        public class Point
        {
            // Public Static Methods
            public static double GetDistance(int[] coords)
            {
                // TODO: handle multiple dimensions.  Assume 2 dimensions for now for simplicity.
                //int dimensions = coords.Length;

                // Pythagorean's Theorem: A^2 + B^2 = C^2
                return Math.Sqrt(Math.Pow(coords[0], 2) + Math.Pow(coords[1], 2));
            }
        }
    }
}
