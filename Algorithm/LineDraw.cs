using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class LineDraw
    {
        /// <summary>
        /// Рисование линии алгоритмом Брезентхема
        /// </summary>
        /// <param name="point0">Начальная точка наклонной</param>
        /// <param name="point1">Конечная точка наклонной</param>
        /// <param name="bitmap">Bitmap</param>
        /// <param name="color">Цвет линии</param>
        public static void DrawLineBresenham(Point point0, Point point1, Bitmap bitmap, Color color)
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
                    bitmap.SetPixel(x, y, color);
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
                    bitmap.SetPixel(x, y, color);
                    error += k;

                    if (error > 0)
                    {
                        y += direction;
                        error--;
                    }
                }
            }
        }
    }
}
