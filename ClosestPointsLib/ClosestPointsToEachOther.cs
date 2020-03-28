using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ClosestPointsLib
{
    public class ClosestPointsToEachOther
    {
        /// <summary>
        /// Find k closest pairs of points to eachother
        /// </summary>
        /// <param name="points">list of Points to consider</param>
        /// <param name="k">number of pairs to find</param>
        /// <returns>k Edges of the pairs of Points that are closest together</returns>
        public static Edge[] FindClosestPoints(Points points, int k)
        {
            Grid grid = new Grid(points);
            return grid.FindClosestPairs(k);
        }


        public class Points : List<Point>
        {
            public RectangleF Bounds { get; }
        }


        public class Point
        {
            public float x, y;
        }


        public class Edge
        {
            Point p1, p2;

            public float Distance { get { return GetDistance(p1, p2); } }

            public static float GetDistance(Point p1, Point p2) { return (float)Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2)); }
        }


        class Grid
        {
            int rowsCols; // number of Rows & Columns
            float colWidth, rowHeight;
            Points[,] cells; // grid of cells hold Points that are within it
            SortedList<float, Edge> closestPairs = new SortedList<float, Edge>(); // collecting closestPairs as we find them, with biggest falling off when more than k found

            public Grid(Points points)
            {
                rowsCols = (int)Math.Ceiling(Math.Sqrt(points.Count)); // choose number of Rows and Columns so that about 1 Point per square
                cells = new Points[rowsCols, rowsCols];
                RectangleF bounds = points.Bounds;
                colWidth = bounds.Width / rowsCols;
                rowHeight = bounds.Height / rowsCols;
            }

            public Edge[] FindClosestPairs(int k)
            {
                // throw if k is impossible for Points count

                // loop points, putting them in cells

                // loop cells
                for (int x = 0; x < rowsCols; x++)
                {
                    for (int y = 0; y < rowsCols; y++)
                    {
                        // test Points to Points within cell
                        for (int i = 0; i < cells[x, y].Count; i++)
                        {
                            for (int j = i; j < cells[x, y].Count; j++)
                            {

                            }
                        }

                        // test Points to Points in cells below (y+1), upper-right (x+1,y-1), right(x+1), lower-right(x+1,y+1)
                        // don't need to test other adjacent cells because that has already been done
                    }
                }


                var result = new Edge[k];
                closestPairs.Values.CopyTo(result, 0);
                return result;
            }
        }
    }
}
