using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;

        static Point coordinatesRadius = new Point(50, 50);

        static int radius = 50;

        static int length = 105;
        static int width = 15;

        static Point lineCoordinates1 = new Point(radius, coordinatesRadius.Y + radius);
        static Point lineCoordinates2 = new Point(radius, coordinatesRadius.Y - width + radius);

        static Point lineCoordinates3 = new Point(length, coordinatesRadius.Y - width + radius);
        static Point lineCoordinates4 = new Point(length, coordinatesRadius.Y + radius);

        public Form1()
        {
            InitializeComponent();

            DrawCircle(coordinatesRadius.X, coordinatesRadius.Y, radius, Color.Red);

            DrawLineBresenham(lineCoordinates1, lineCoordinates2);
            DrawLineBresenham(lineCoordinates2, lineCoordinates3);
            DrawLineBresenham(lineCoordinates3, lineCoordinates4);
            DrawLineBresenham(lineCoordinates4, lineCoordinates1);


            pictureBox1.Size = new Size(bitmap.Width + 10, bitmap.Height + 10);

            pictureBox1.Image = bitmap;
        }

        public void DrawCircle(int xCenter, int yCenter, int radius, Color color)
        {
            bitmap = new Bitmap(1000, 1000);

            int x = 0;
            int y = radius;
            int Dd = 2 * (1 - radius);
            int error;

            while (x < y)
            {
                DrawPointCircle(xCenter, yCenter, x, y, color);

                error = 2 * (Dd + y) - 1;//di, для Dg - Dd

                if (Dd < 0 && error <= 0)//Выбирается Dg
                {
                    x++;
                    Dd += 2 * x + 1;
                    continue;
                }

                error = 2 * (Dd - x) - 1;//si, для Dd - Dv

                if (Dd > 0 && error > 0)//Выбирается Dv
                {
                    y--;
                    Dd += 1 - 2 * y;
                    continue;
                }

                //Dd
                x++;

                y--;
                Dd += 2 * (x - y) + 2;
            }

            if (x == y)
            {
                DrawPointCircle(xCenter, yCenter, x, y, color);
            }
        }

        public void DrawPointCircle(int xCenter, int yCenter, int x, int y, Color color)
        {
            Point testPoint = new Point();

            testPoint.X = xCenter + x;
            testPoint.Y = yCenter + y;

            if (!IsInRectangle(testPoint))
                bitmap.SetPixel(testPoint.X, testPoint.Y, color);

            testPoint.X = xCenter + y;
            testPoint.Y = yCenter + x;

            if (!IsInRectangle(testPoint))
                bitmap.SetPixel(testPoint.X, testPoint.Y, color);

            testPoint.X = xCenter + y;
            testPoint.Y = yCenter - x;

            if (!IsInRectangle(testPoint))
                bitmap.SetPixel(testPoint.X, testPoint.Y, color);

            testPoint.X = xCenter + x;
            testPoint.Y = yCenter - y;

            if (!IsInRectangle(testPoint))
                bitmap.SetPixel(testPoint.X, testPoint.Y, color);

            testPoint.X = xCenter - x;
            testPoint.Y = yCenter - y;

            if (!IsInRectangle(testPoint))
                bitmap.SetPixel(testPoint.X, testPoint.Y, color);

            testPoint.X = xCenter - y;
            testPoint.Y = yCenter - x;

            if (!IsInRectangle(testPoint))
                bitmap.SetPixel(testPoint.X, testPoint.Y, color);

            testPoint.X = xCenter - y;
            testPoint.Y = yCenter + x;

            if (!IsInRectangle(testPoint))
                bitmap.SetPixel(testPoint.X, testPoint.Y, color);

            testPoint.X = xCenter - x;
            testPoint.Y = yCenter + y;

            if (!IsInRectangle(testPoint))
                bitmap.SetPixel(testPoint.X, testPoint.Y, color);
        }

        private void DrawLineBresenham(Point point0, Point point1)
        {

            var deltaX = point1.X - point0.X;
            var deltaY = point1.Y - point0.Y;

            var absDeltaX = Math.Abs(deltaX);
            var absDeltaY = Math.Abs(deltaY);

            Point testPoint = new Point();

            if (absDeltaY > absDeltaX)
            {
                double k = (double)absDeltaX / absDeltaY;
                double error = -0.5;

                int x = point0.X;

                int directionDeltaY = deltaY > 0 ? 1 : -1;

                int direction = deltaX != 0 ? (deltaX > 0 ? 1 : -1) : 0;

                for (int y = point0.Y; deltaY > 0 ? y <= point1.Y : y >= point1.Y; y += directionDeltaY)
                {
                    testPoint.X = x;
                    testPoint.Y = y;

                    if(!IsInCircle(testPoint))
                        bitmap.SetPixel(x, y, Color.Red);

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
                    testPoint.X = x;
                    testPoint.Y = y;

                    if (!IsInCircle(testPoint))
                        bitmap.SetPixel(x, y, Color.Red);

                    error += k;

                    if (error > 0)
                    {
                        y += direction;
                        error--;
                    }
                }
            }
        }

        private static bool IsInRectangle(Point point)
        {

            double line12 = (lineCoordinates1.Y - lineCoordinates2.Y) * point.X + (lineCoordinates2.X - lineCoordinates1.X) * point.Y + (lineCoordinates1.X * lineCoordinates2.Y - lineCoordinates2.X * lineCoordinates1.Y);
            double line23 = (lineCoordinates2.Y - lineCoordinates3.Y) * point.X + (lineCoordinates3.X - lineCoordinates2.X) * point.Y + (lineCoordinates2.X * lineCoordinates3.Y - lineCoordinates3.X * lineCoordinates2.Y);
            double line34 = (lineCoordinates3.Y - lineCoordinates4.Y) * point.X + (lineCoordinates4.X - lineCoordinates3.X) * point.Y + (lineCoordinates3.X * lineCoordinates4.Y - lineCoordinates4.X * lineCoordinates3.Y);
            double line41 = (lineCoordinates4.Y - lineCoordinates1.Y) * point.X + (lineCoordinates1.X - lineCoordinates4.X) * point.Y + (lineCoordinates4.X * lineCoordinates1.Y - lineCoordinates1.X * lineCoordinates4.Y);

            return (line12 >= 0 && line23 >= 0 && line34 >= 0 && line41 >= 0);
        }

        private static bool IsInCircle(Point point)
        {
            return (Math.Pow(point.X - coordinatesRadius.X, 2) + Math.Pow(point.Y - coordinatesRadius.Y, 2) < Math.Pow(radius, 2));
        }


        #region Draw Ellipse
        //public void DrawEllipse(int xCenter, int yCenter, int xRadius, int yRadius, Color color)
        //{
        //    bitmap = new Bitmap(1000, 1000);

        //    int x = 0;
        //    int y = yRadius;

        //    int squareX = (int)Math.Pow(xRadius, 2);
        //    int squareY = (int)Math.Pow(yRadius, 2);

        //    int xm = (int)Math.Round(squareX / Math.Sqrt(squareX + squareY));

        //    int d = (int)(2 * squareY + squareX - 2 * yRadius * squareX);

        //    bitmap.SetPixel(xCenter + x, yCenter + y, color);
        //    bitmap.SetPixel(xCenter + x, yCenter - y, color);
        //    bitmap.SetPixel(xCenter - x, yCenter + y, color);
        //    bitmap.SetPixel(xCenter - x, yCenter - y, color);

        //    while (x < xm)
        //    {


        //        if (d > 0)
        //        {
        //            y--;
        //            d += (4 * squareY * x + 6 * squareY - 4 * squareX * y);
        //        }
        //        else
        //        {
        //            d += (4 * squareY * x + 6 * squareY);
        //        }

        //        x++;

        //        bitmap.SetPixel(xCenter + x, yCenter + y, color);
        //        bitmap.SetPixel(xCenter + x, yCenter - y, color);
        //        bitmap.SetPixel(xCenter - x, yCenter + y, color);
        //        bitmap.SetPixel(xCenter - x, yCenter - y, color);
        //    }

        //    x = xRadius;
        //    y = 0;

        //    d = 2 * squareX + squareY - 2 * xRadius * squareY;

        //    bitmap.SetPixel(xCenter + x, yCenter + y, color);
        //    bitmap.SetPixel(xCenter + x, yCenter - y, color);
        //    bitmap.SetPixel(xCenter - x, yCenter + y, color);
        //    bitmap.SetPixel(xCenter - x, yCenter - y, color);

        //    while (x > xm)
        //    {
        //        if (d > 0)
        //        {
        //            x--;
        //            d += (4 * squareX * y + 6 * squareX - 4 * squareY * x);
        //        }
        //        else
        //        {
        //            d += (4 * squareX * y + 6 * squareX);
        //        }
        //        y++;

        //        bitmap.SetPixel(xCenter + x, yCenter + y, color);
        //        bitmap.SetPixel(xCenter + x, yCenter - y, color);
        //        bitmap.SetPixel(xCenter - x, yCenter + y, color);
        //        bitmap.SetPixel(xCenter - x, yCenter - y, color);
        //    }
        //}
        #endregion

        #region Draw BezierCurve
        //public void DrawBezierCurve(Point p0, Point p1, Point p2, Point p3, Color color)
        //{
        //    bitmap = new Bitmap(1000, 1000);
        //    Point result = new Point();

        //    for (double t = 0; t <= 1; t += 0.000005)
        //    {
        //        result.X = (int)Math.Round((Math.Pow((1 - t), 3) * p0.X + 3 * Math.Pow((1 - t), 2) * t * p1.X + 3 * (1 - t) * Math.Pow(t, 2) * p2.X + Math.Pow(t, 3) * p3.X));
        //        result.Y = (int)Math.Round((Math.Pow((1 - t), 3) * p0.Y + 3 * Math.Pow((1 - t), 2) * t * p1.Y + 3 * (1 - t) * Math.Pow(t, 2) * p2.Y + Math.Pow(t, 3) * p3.Y));
        //        bitmap.SetPixel(result.X, result.Y, color);
        //    }


        //}
        #endregion
    }
}
