using System.Collections.Generic;
using System.Drawing;

namespace ComputerGraphics
{
    public static class Shapes
    {
        public static IEnumerable<Edge> FourArrows()
        {
            Point point0 = new Point(85, 0);

            Point point1 = new Point(55, 30);
            Point point2 = new Point(115, 30);

            Point point3 = new Point(75, 30);
            Point point4 = new Point(95, 30);

            Point point5 = new Point(75, 80);
            Point point6 = new Point(95, 80);

            Point point7 = new Point(25, 80);
            Point point8 = new Point(145, 80);

            Point point9 = new Point(25, 60);
            Point point10 = new Point(145, 60);

            Point point11 = new Point(0, 90);
            Point point12 = new Point(180, 90);

            Point point13 = new Point(25, 120);
            Point point14 = new Point(145, 120);

            Point point15 = new Point(25, 100);
            Point point16 = new Point(145, 100);

            Point point17 = new Point(75, 100);
            Point point18 = new Point(95, 100);

            Point point19 = new Point(75, 150);
            Point point20 = new Point(95, 150);

            Point point21 = new Point(55, 150);
            Point point22 = new Point(115, 150);

            Point point23 = new Point(85, 180);

            return new List<Edge>
                    {
                    new Edge(point0, point1),
                new Edge(point0, point2),

                new Edge(point1, point3),
                new Edge(point2, point4),

                new Edge(point3, point5),
                new Edge(point4, point6),

                new Edge(point5, point7),
                new Edge(point6, point8),

                new Edge(point7, point9),
                new Edge(point8, point10),

                new Edge(point9, point11),
                new Edge(point10, point12),

                new Edge(point11, point13),
                new Edge(point12, point14),

                new Edge(point13, point15),
                new Edge(point14, point16),

                new Edge(point15, point17),
                new Edge(point16, point18),

                new Edge(point17, point19),
                new Edge(point18, point20),

                new Edge(point19, point21),
                new Edge(point20, point22),

                new Edge(point21, point23),
                new Edge(point22, point23),
            };
        }

        public static IEnumerable<Edge> CustomPolygon()
        {
            Point point0 = new Point(0, 40);

            Point point1 = new Point(20, 20);
            Point point2 = new Point(40, 40);

            Point point3 = new Point(100, 0);
            Point point4 = new Point(120, 100);

            Point point5 = new Point(90, 150);

            return new List<Edge>
            {
                new Edge(point0, point1),
                new Edge(point1, point2),
                new Edge(point2, point3),
                new Edge(point3, point4),
                new Edge(point4, point5),
                new Edge(point5, point0),
            };
        }

        public static IEnumerable<Edge> Rectangle()
        {
            Point point0 = new Point(20, 20);

            Point point1 = new Point(100, 20);
            Point point2 = new Point(100, 70);

            Point point3 = new Point(20, 70);

            return new List<Edge>
            {
                new Edge(point0, point1),
                new Edge(point1, point2),
                new Edge(point2, point3),
                new Edge(point3, point0),
            };
        }




        public static IEnumerable<Edge> Parallelogram()
        {
            Point point0 = new Point(40, 10);

            Point point1 = new Point(130, 10);
            Point point2 = new Point(100, 80);

            Point point3 = new Point(10, 80);

            return new List<Edge>
            {
                new Edge(point0, point1),
                new Edge(point1, point2),
                new Edge(point2, point3),
                new Edge(point3, point0),
            };
        }


        public static IEnumerable<Edge> InvertedTrapezoid()
        {
            Point point0 = new Point(10, 10);

            Point point1 = new Point(100, 10);
            Point point2 = new Point(80, 50);

            Point point3 = new Point(30, 50);

            return new List<Edge>
            {
                new Edge(point0, point1),
                new Edge(point1, point2),
                new Edge(point2, point3),
                new Edge(point3, point0),
            };
        }


        public static IEnumerable<Edge> Triangle()
        {
            Point point0 = new Point(10, 90);

            Point point1 = new Point(55, 10);
            Point point2 = new Point(100, 90);

            return new List<Edge>
            {
                new Edge(point0, point1),
                new Edge(point1, point2),
                new Edge(point2, point0)
            };
        }

        public static IEnumerable<Edge> ThreeArrows()
        {
            Point point0 = new Point(85, 0);

            Point point1 = new Point(55, 30);
            Point point2 = new Point(115, 30);

            Point point3 = new Point(75, 30);
            Point point4 = new Point(95, 30);

            Point point5 = new Point(75, 80);
            Point point6 = new Point(95, 80);

            Point point7 = new Point(25, 80);
            Point point8 = new Point(145, 80);

            Point point9 = new Point(25, 60);
            Point point10 = new Point(145, 60);

            Point point11 = new Point(0, 90);
            Point point12 = new Point(180, 90);

            Point point13 = new Point(25, 120);
            Point point14 = new Point(145, 120);

            Point point15 = new Point(25, 100);
            Point point16 = new Point(145, 100);

            return new List<Edge>
            {
                new Edge(point0, point1),
                new Edge(point0, point2),

                new Edge(point1, point3),
                new Edge(point2, point4),

                new Edge(point3, point5),
                new Edge(point4, point6),

                new Edge(point5, point7),
                new Edge(point6, point8),

                new Edge(point7, point9),
                new Edge(point8, point10),

                new Edge(point9, point11),
                new Edge(point10, point12),

                new Edge(point11, point13),
                new Edge(point12, point14),

                new Edge(point13, point15),
                new Edge(point14, point16),

                new Edge(point15, point16)
            };
        }


        public static IEnumerable<Edge> Hexagon()
        {
            Point point0 = new Point(10, 100);

            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 50);
            Point point3 = new Point(140, 100);

            Point point4 = new Point(100, 150);
            Point point5 = new Point(50, 150);

            return new List<Edge>
            {
                new Edge(point0, point1),
                new Edge(point1, point2),
                new Edge(point2, point3),
                new Edge(point3, point4),
                new Edge(point4, point5),
                new Edge(point5, point0)
            };
        }
    }
}
