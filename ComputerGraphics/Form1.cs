using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        static Point coordinatesRadius = new Point(50, 50);

        static int radius = 50;

        static int length = 105;
        static int width = 15;

        static Point lineCoordinates1 = new Point(radius, coordinatesRadius.Y + radius);
        static Point lineCoordinates2 = new Point(radius, coordinatesRadius.Y - width + radius);

        static Point lineCoordinates3 = new Point(length, coordinatesRadius.Y - width + radius);
        static Point lineCoordinates4 = new Point(length, coordinatesRadius.Y + radius);

        static Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();  
        }

        private void FillPolygon(Point startPoint)
        {
            bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            Color borderColor = Color.AliceBlue;
            Color mainColor = Color.Blue;

            CreateFigure(bitmap, borderColor);

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
                    pictureBoxMain.Image = bitmap;
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

            pictureBoxMain.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillPolygon(new Point(50, 50));
        }

        private void CreateFigure(Bitmap bitmap, Color color)
        {

            DrawCircle(coordinatesRadius.X, coordinatesRadius.Y, radius, color);

            DrawLineBresenham(lineCoordinates1, lineCoordinates2, color);
            DrawLineBresenham(lineCoordinates2, lineCoordinates3, color);
            DrawLineBresenham(lineCoordinates3, lineCoordinates4, color);
            DrawLineBresenham(lineCoordinates4, lineCoordinates1, color);
        }

        public void DrawCircle(int xCenter, int yCenter, int radius, Color color)
        {

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

        private void DrawLineBresenham(Point point0, Point point1, Color color)
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

                    if (!IsInCircle(testPoint))
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
                    testPoint.X = x;
                    testPoint.Y = y;

                    if (!IsInCircle(testPoint))
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
    }
}
