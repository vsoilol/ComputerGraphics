using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public static class TriangleColor
    {
        private static PointF VertexR, VertexG, VertexB;

        private static double THeight;

        private const double Rad60 = Math.PI / 3;

        private static readonly double Tan60, Sin60;

        private static int Sqwidth;

        static TriangleColor()
        {
            Tan60 = Math.Tan(Rad60);
            Sin60 = Math.Sin(Rad60);
        }

        public static void DrawColorTriangle(PictureBox pictureBox, bool bright)
        {
            Sqwidth = pictureBox.Width;//Размер треугольника

            THeight = (Sqwidth / 2) * Tan60;//Высота треугольника

            pictureBox.Height = (int)Math.Round(THeight);

            var TriangleImage = new Bitmap(pictureBox.Width, pictureBox.Height);

            VertexR = new PointF(Sqwidth, (float)THeight);
            VertexG = new PointF(Sqwidth / 2, 0);
            VertexB = new PointF(0, (float)THeight);

            Point TestPoint = new Point();

            for (int y = 0; y < TriangleImage.Height; y++)
            {
                for (int x = 0; x < TriangleImage.Width; x++)
                {
                    TestPoint.X = x;
                    TestPoint.Y = y;

                    if (IsInTriangle(TestPoint))
                    {
                        if (bright)
                            TriangleImage.SetPixel(x, y, GetBrightGradedColorAtPoint(TestPoint));
                        else
                            TriangleImage.SetPixel(x, y, GetGradedColorAtPoint(TestPoint));
                    }

                }
            }

            pictureBox.Image = TriangleImage;
        }

        public static Color GetGradedColorAtPoint(Point point)
        {

            double G = (THeight - point.Y) / THeight;
            double R = (Sin60 * (point.X - (G * THeight) / Tan60)) / THeight;
            double B = Math.Abs(1 - R - G);

            return Color.FromArgb((int)Math.Round(R * 255), (int)Math.Round(G * 255), (int)Math.Round(B * 255));
        }

        public static Color GetBrightGradedColorAtPoint(Point point)
        {
            double G = (THeight - point.Y) / THeight;
            double R = (Sin60 * (point.X - (G * THeight) / Tan60)) / THeight;
            double B = Math.Abs(1 - R - G);

            double maxRGB = 1 / Math.Max(Math.Max(R, B), G);
            double NewR = maxRGB * R;
            double NewB = maxRGB * B;
            double NewG = maxRGB * G;

            return Color.FromArgb((int)Math.Round(NewR * 255), (int)Math.Round(NewG * 255), (int)Math.Round(NewB * 255));
        }

        private static bool IsInTriangle(Point point)
        {
            //Используем преобразования уравнение прямой проходящей по двум точкам - (y-y1)/(y2-y1) = (x-x1)/(x2-x1)
            //Находим 3 уравнения прямых по двум точкам каждой стороны треугольника, подставляем координаты проверяемой точки
            //Если точка выше - значение будет больше нуля, если ниже - меньше нуля, если равно на прямой
            //Следует учитывать что уравнение прямой от точки A к В не совсем то же, что от точки В к А, это своего рода инверсия,
            //поэтому следует учитывать ориентацию прямых (в каком порядке идут точки), либо делать 2 проверки

            double GR = (VertexG.Y - VertexR.Y) * point.X + (VertexR.X - VertexG.X) * point.Y + (VertexG.X * VertexR.Y - VertexR.X * VertexG.Y);
            double RB = (VertexR.Y - VertexB.Y) * point.X + (VertexB.X - VertexR.X) * point.Y + (VertexR.X * VertexB.Y - VertexB.X * VertexR.Y);
            double BG = (VertexB.Y - VertexG.Y) * point.X + (VertexG.X - VertexB.X) * point.Y + (VertexB.X * VertexG.Y - VertexG.X * VertexB.Y);

            return (GR >= 0 && RB >= 0 && BG >= 0);
        }
    }
}
