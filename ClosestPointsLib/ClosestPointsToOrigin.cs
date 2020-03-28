using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestPointsLib
{
    public class ClosestPointsToOrigin
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

            // Using sort is clean & pretty code, but O(n log n) so performance could be better for large number of Points
            // return points.OrderBy(point => Point.GetDistance(point)).Take(k).ToArray(); // sort points by distance, take first k Points

            // go through the Points only once keeping the k closest = O(n log k)
            var closestPoints = new SortedList<double, Point>(k, new DistanceComparer());
            foreach (int[] p in points)
            {
                Point point = new Point(p);

                // add the first k points
                if (closestPoints.Count < k)
                {
                    closestPoints.Add(point.Distance, point);
                    continue;
                }

                // if point's distance is closer than the worst of closestPoints than replace the worst with point
                if (point.Distance < closestPoints.Keys.Max())
                {
                    closestPoints.RemoveAt(k - 1);
                    closestPoints.Add(point.Distance, point);
                }
            }

            // return array of closest points (type int[])
            var closestPointsArray = new int[k][];
            int i = 0;
            foreach (Point point in closestPoints.Values)
            {
                closestPointsArray[i++] = point.Coords;
            }
            return closestPointsArray;
        }


        // Point class
        public class Point
        {
            // Private Fields
            private int[] coords = new int[2];
            private double? distance = null;


            // Public Properties
            public int X { get { return coords[0]; } set { coords[0] = value; } }
            public int Y { get { return coords[1]; } set { coords[1] = value; } }

            public int[] Coords { get { return (int[])coords.Clone(); } }

            public double Distance
            {
                get
                {
                    // Using a nullable so we only calculate this once for each Point object
                    if (!distance.HasValue)
                    {
                        distance = GetDistance(coords);
                    }
                    return distance.Value;
                }
            }


            // Constructor
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point(int[] coords)
            {
                X = coords[0];
                Y = coords[1];
            }


            // Public Static Methods
            public static double GetDistance(int[] coords)
            {
                // TODO: handle multiple dimensions.  Assume 2 dimensions for now for simplicity.
                //int dimensions = coords.Length;

                // Pythagorean's Theorem: A^2 + B^2 = C^2
                return Math.Sqrt(Math.Pow(coords[0], 2) + Math.Pow(coords[1], 2));
            }
        }


        // To allow SortedList to store multiple Points with the same distance, we need a Comparer that never returns 0 (equal)
        private class DistanceComparer : IComparer<double>
        {
            public int Compare(double d1, double d2)
            {
                if (d1 < d2)
                    return -1;
                else
                    return 1;
            }
        }
    }
}
