using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Fill
    {
        private static IEnumerable<Edge> mainFigure;
        private static Bitmap mainBitmap;

        /// <summary>
        /// Метод заливки фигуру с затравкой
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        /// <param name="mainColor">Основной цвет которым будет закрашена фигура</param>
        /// <param name="startPoint">Координаты точки которая находится в фигуре</param>
        /// <param name="figure">Список рёбер фигуры</param>
        public static void FillWithSeed(Bitmap bitmap, Color mainColor, Point startPoint, IEnumerable<Edge> figure)
        {
            mainFigure = figure;
            mainBitmap = bitmap;

            Color borderColor = Color.FromArgb(mainColor.A - 1, mainColor);

            CreateFigure(borderColor, figure);

            Stack<Point> stack = new Stack<Point>();
            stack.Push(startPoint);

            while (stack.Count != 0)
            {
                Point point = stack.Pop();

                int xMin = point.X;

                while (bitmap.GetPixel(xMin - 1, point.Y).ToArgb() != borderColor.ToArgb())
                {
                    xMin--;
                }

                int xMax = point.X;

                while (bitmap.GetPixel(xMax + 1, point.Y).ToArgb() != borderColor.ToArgb())
                {
                    xMax++;
                }

                for (int x = xMin; x <= xMax; x++)
                {
                    bitmap.SetPixel(x, point.Y, mainColor);
                }

                bool flag = true;

                for (int x = xMin; x <= xMax; x++)
                {
                    if (bitmap.GetPixel(x, point.Y - 1).ToArgb() != borderColor.ToArgb() && bitmap.GetPixel(x, point.Y - 1).ToArgb() == 0)
                    {
                        if (flag)
                        {
                            stack.Push(new Point(x, point.Y - 1));
                            flag = false;
                        }

                    }
                    else
                    {
                        flag = true;
                    }
                }

                flag = true;

                for (int x = xMin; x <= xMax; x++)
                {
                    if (bitmap.GetPixel(x, point.Y + 1).ToArgb() != borderColor.ToArgb() && bitmap.GetPixel(x, point.Y + 1).ToArgb() == 0)
                    {
                        if (flag)
                        {
                            stack.Push(new Point(x, point.Y + 1));
                            flag = false;
                        }

                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
        }

        /// <summary>
        /// Заливка фигуры методом список активных рёбер
        /// </summary>
        /// <param name="edges">Список ребер фигуры</param>
        /// <param name="bitmap">Bitmap</param>
        /// <param name="color">Цвет</param>
        public static void FillSAR(IEnumerable<Edge> edges, Bitmap bitmap, Color color)
        {
            List<Edge> activeEdges = new List<Edge>();
            List<Edge> solidLines = new List<Edge>();
            List<Edge> edgesList = new List<Edge>();

            foreach (var edge in edges)
            {
                edgesList.Add(new Edge(edge.StartingPoint, edge.EndPoint));
            }

            var maxEdgeY = edgesList.OrderBy(edge => edge.EndPoint.Y).Last();
            var minEdgeY = edgesList.OrderBy(edge => edge.StartingPoint.Y).First();

            solidLines.AddRange(edgesList.Where(edge => edge.StartingPoint.Y == edge.EndPoint.Y));

            foreach (var item in solidLines)
            {
                for (int x = item.StartingPoint.X; x <= item.EndPoint.X; x++)
                {
                    if(x < bitmap.Width && item.StartingPoint.Y < bitmap.Height && x >= 0 && item.StartingPoint.Y >= 0)
                    {
                        bitmap.SetPixel(x, item.StartingPoint.Y, color);
                    }
                }

                edgesList.Remove(item);
            }

            for (int y = minEdgeY.StartingPoint.Y; y <= maxEdgeY.EndPoint.Y; y++)
            {
                activeEdges.AddRange(edgesList.Where(edge => edge.StartingPoint.Y == y));

                activeEdges.RemoveAll(edge => edge.EndPoint.Y == y);

                List<Point> currentPoints = new List<Point>();

                foreach (var item in activeEdges)
                {
                    int x = LineBresenham(item.StartingPoint, item.EndPoint, y);

                    currentPoints.Add(new Point(x, y));
                }

                currentPoints = currentPoints.OrderBy(point => point.X).ToList();

                for (int i = 0; i < currentPoints.Count / 2; i++)
                {
                    for (int x = currentPoints[i + i].X; x <= currentPoints[i + 1 + i].X; x++)
                    {
                        if (x < bitmap.Width && y < bitmap.Height && x >= 0 && y >= 0)
                        {
                            bitmap.SetPixel(x, y, color);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Рисуем ребра фигуры для метода заливки с затравкой
        /// </summary>
        /// <param name="borderColor">Цвет рёбер</param>
        /// <param name="mainFigure">Список рёбер фигуры</param>
        private static void CreateFigure(Color borderColor, IEnumerable<Edge> mainFigure)
        {
            foreach (var item in mainFigure)
            {
                LineDraw.DrawLineBresenham(item.StartingPoint, item.EndPoint, mainBitmap, borderColor);
            }
        }

        /// <summary>
        /// Нахождение точек пересечения наклонной с горизонтальной прямой
        /// </summary>
        /// <param name="point0">Начальная точка наклонной</param>
        /// <param name="point1">Конечная точка наклонной</param>
        /// <param name="checkY">Координата для горизонтальной прямой</param>
        /// <returns>Координата X пересечения</returns>
        private static int LineBresenham(Point point0, Point point1, int checkY)
        {

            var deltaX = point1.X - point0.X;
            var deltaY = point1.Y - point0.Y;

            var absDeltaX = Math.Abs(deltaX);
            var absDeltaY = Math.Abs(deltaY);

            if (absDeltaY > absDeltaX)
            {
                double k = (double)absDeltaX / absDeltaY;
                double error = -0.5;

                int x = point0.X;

                int directionDeltaY = deltaY > 0 ? 1 : -1;

                int direction = deltaX != 0 ? (deltaX > 0 ? 1 : -1) : 0;

                for (int y = point0.Y; deltaY > 0 ? y <= point1.Y : y >= point1.Y; y += directionDeltaY)
                {
                    if (y == checkY)
                    {
                        return x;
                    }
                    error += k;

                    if (error > 0)
                    {
                        x += direction;
                        error--;
                    }


                }
            }
            else
            {
                double k = (double)absDeltaY / absDeltaX;
                double error = -0.5;

                int y = point0.Y;

                int directionDeltaX = deltaX > 0 ? 1 : -1;

                int direction = deltaY != 0 ? (deltaY > 0 ? 1 : -1) : 0;

                for (int x = point0.X; deltaX > 0 ? x <= point1.X : x >= point1.X; x += directionDeltaX)
                {
                    if (y == checkY)
                    {
                        return x;
                    }
                    error += k;

                    if (error > 0)
                    {
                        y += direction;
                        error--;
                    }
                }
            }
            return 0;
        }
    }
}
