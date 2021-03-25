using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        private const int n = 3;
        private Bitmap bitmap = new Bitmap(100 * n, 100 * n);

        public Form1()
        {
            InitializeComponent();

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

            


            DrawLineBresenham(point0, point1);
            DrawLineBresenham(point0, point2);

            DrawLineBresenham(point1, point3);
            DrawLineBresenham(point2, point4);

            DrawLineBresenham(point3, point5);
            DrawLineBresenham(point4, point6);

            DrawLineBresenham(point5, point7);
            DrawLineBresenham(point6, point8);

            DrawLineBresenham(point7, point9);
            DrawLineBresenham(point8, point10);

            DrawLineBresenham(point9, point11);
            DrawLineBresenham(point10, point12);

            DrawLineBresenham(point11, point13);
            DrawLineBresenham(point12, point14);

            DrawLineBresenham(point13, point15);
            DrawLineBresenham(point14, point16);

            DrawLineBresenham(point15, point16);




            //Point point0 = new Point(0, 40);

            //Point point1 = new Point(20, 20);
            //Point point2 = new Point(40, 40);

            //Point point3 = new Point(100, 0);
            //Point point4 = new Point(120, 100);

            //Point point5 = new Point(90, 150);

            //DrawLineBresenham(point0, point1);
            //DrawLineBresenham(point1, point2);
            //DrawLineBresenham(point2, point3);
            //DrawLineBresenham(point3, point4);
            //DrawLineBresenham(point4, point5);
            //DrawLineBresenham(point5, point0);

        }

        private void DrawLineCDA(Point point0, Point point1)
        {
            pictureBox1.Size = new Size(bitmap.Width + 10, bitmap.Height + 10);

            var deltaX = point1.X - point0.X;
            var deltaY = point1.Y - point0.Y;



            if (Math.Abs(deltaY) > Math.Abs(deltaX))
            {
                //int x = point0.X;
                double k = (double)deltaX / deltaY;

                for (int i = 0; i <= point1.Y; i++)
                {
                    int y = i + point0.Y;
                    int x = point0.X + (int)(k * i);

                    bitmap.SetPixel(x, y, Color.Red);
                }
            }
            else
            {
                //int y = point0.Y;
                double k = (double)deltaY / deltaX;

                for (int i = 0; i <= point1.X; i++)
                {
                    int x = i + point0.X;

                    int y = point0.Y + (int)(k * i);

                    bitmap.SetPixel(x, y, Color.Red);

                }
            }

            pictureBox1.BackColor = Color.Black;
            pictureBox1.Image = bitmap;
        }

        private void DrawLineBresenham(Point point0, Point point1)
        {
            pictureBox1.Size = new Size(bitmap.Width + 10, bitmap.Height + 10);

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
                    bitmap.SetPixel(x, y, Color.Red);
                    error += k;

                    if (error > 0)
                    {
                        y += direction;
                        error--;
                    }
                }
            }

            pictureBox1.BackColor = Color.Black;
            pictureBox1.Image = bitmap;
        }
    }
}
