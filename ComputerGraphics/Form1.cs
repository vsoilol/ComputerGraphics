using GraficLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            DrawPolyhedronByGuro(bmp, TruncatedPyramidMade(), new Vector(-1, -1, -1));
            pictureBox1.Image = bmp;
        }

        /// <summary>
        /// Основной алгоритм
        /// </summary>
        /// <param name="bmp">Bitmap</param>
        /// <param name="polyhedron">фигура</param>
        /// <param name="lightPoint">Положение точки освещения</param>
        private void DrawPolyhedronByGuro(Bitmap bmp, Polyhedron polyhedron, Vector lightPoint)
        {
            // Сбрасываем матрицу преобразований (ПРЕПОДУ ЭТО НЕ ГОВОРИТЕ)
            polyhedron.ResetBodyMatrix(polyhedron.Center);

            double[,] ZBuffer = new double[bmp.Width, bmp.Height];

            #region Заполняем ZBuffer минимальными значениями
            for (int y = 0; y < ZBuffer.GetLength(1) - 1; y++)
            {
                for (int x = 0; x < ZBuffer.GetLength(0) - 1; x++)
                {
                    ZBuffer[x, y] = double.NegativeInfinity;
                }
            }
            #endregion

            // Проходимся по фигуре
            for (int polygon = 0; polygon < polyhedron.Faces.Length; polygon++)
            {
                // Высчитываем коэффициенты плоскости грани
                double[] coef = polyhedron.Faces[polygon].CalculateCoefficients(new Point3D(0, 0, 0));

                Point3D[] pointsBuf = new Point3D[polyhedron.Faces[polygon].Points.Length + 1];

                polyhedron.Faces[polygon].Points.CopyTo(pointsBuf, 0); // Копируем все значения в массив pointsBuf
                pointsBuf[pointsBuf.Length - 1] = pointsBuf[0]; // Последнему элементу присваиваем первый

                double[] IforPoints = new double[pointsBuf.Length];

                //Находим нормали в вершинах (определяется усреднением нормалей примыкающих граней)
                for (int i = 0; i < IforPoints.Length - 1; i++)
                {
                    // Находим все нрани которые содержат точки находящиеся в САР
                    var polygons = polyhedron.Faces.ToList().FindAll(x => x.Points.Contains(pointsBuf[i]));

                    #region Высчитываем вектора нормалей для каждой вершмны

                    Vector normal = new Vector();
                    for (int k = 0; k < polygons.Count; k++)
                    {
                        int index = polyhedron.Faces.ToList().IndexOf(polygons[k]);
                        normal.X += polyhedron.BodyMatrix[0, index];
                        normal.Y += polyhedron.BodyMatrix[1, index];
                        normal.Z += polyhedron.BodyMatrix[2, index];
                    }

                    #endregion

                    normal.X /= polygons.Count;
                    normal.Y /= polygons.Count;
                    normal.Z /= polygons.Count;

                    // Находим косинус между нормалью и вектором который направлен из точки освещения к нормали
                    IforPoints[i] = GetCos(normal, lightPoint);
                }

                IforPoints[IforPoints.Length - 1] = IforPoints[0];

                List<Tuple<Point3D, Point3D, double, double>> CAP = new List<Tuple<Point3D, Point3D, double, double>>();

                //Так как координаты повернуты странно, то минимальное y для программы это минимальный z для нас
                int ymin = (int)pointsBuf.Min(point => point.Z); // Максимум
                int ymax = (int)pointsBuf.Max(point => point.Z); // Минимум

                for (int y = ymin + 1; y < ymax; y++)
                {
                    CAP.Clear();

                    #region Здесь говорите преподу что выполняется алгоритм САР
                    for (int i = 1; i < pointsBuf.Length; i++)
                    {
                        int a = (int)Math.Min(pointsBuf[i].Z, pointsBuf[i - 1].Z);
                        int b = (int)Math.Max(pointsBuf[i].Z, pointsBuf[i - 1].Z);

                        if (a < y && b >= y && a != b)
                        {
                            CAP.Add(new Tuple<Point3D, Point3D, double, double>(pointsBuf[i], pointsBuf[i - 1], IforPoints[i], IforPoints[i - 1]));
                        }
                    }

                    int xmin = Math.Min(CalculateX(CAP[0].Item1, CAP[0].Item2, y), CalculateX(CAP[1].Item1, CAP[1].Item2, y));
                    int xmax = Math.Max(CalculateX(CAP[0].Item1, CAP[0].Item2, y), CalculateX(CAP[1].Item1, CAP[1].Item2, y));
                    #endregion

                    #region Высчитываем интенсивность освещения (читайте в методичке)
                    double Ya, Ia, Yb, Ib, Yc, Ic, Yd, Id;

                    Tuple<Point3D, Point3D, double, double> left = CAP[1];
                    Tuple<Point3D, Point3D, double, double> right = CAP[0];

                    if (CalculateX(CAP[0].Item1, CAP[0].Item2, y) < CalculateX(CAP[1].Item1, CAP[1].Item2, y))
                    {
                        left = CAP[0];
                        right = CAP[1];
                    }

                    Ya = right.Item2.Z;
                    Ia = right.Item4;
                    Yb = right.Item1.Z;
                    Ib = right.Item3;
                    Yc = left.Item1.Z;
                    Ic = left.Item3;
                    Yd = left.Item2.Z;
                    Id = left.Item4;

                    double I1 = Id + (Ic - Id) * (y - Yd) / (Yc - Yd);
                    double I2 = Ia + (Ib - Ia) * (y - Ya) / (Yb - Ya);
                    #endregion

                    for (int x = xmin; x < xmax; x++)
                    {
                        // Высчитываем интенсивность в точке
                        double I = I1 + (I2 - I1) * (x - xmin) / (xmax - xmin);

                        // Высчитываем цвет освещения
                        int R = (int)(polyhedron.Faces[polygon].Color.R * I + 10);
                        R = R > 0 && R < 255 ? R : R > 0 ? 255 : 0; // Проверяем чтобы не была больше 255 или меньше 0

                        int G = (int)(polyhedron.Faces[polygon].Color.G * I + 10);
                        G = G > 0 && G < 255 ? G : G > 0 ? 255 : 0;

                        int B = (int)(polyhedron.Faces[polygon].Color.B * I + 10);
                        B = B > 0 && B < 255 ? B : B > 0 ? 255 : 0;

                        Color color = Color.FromArgb(R, G, B);
                        double z = 0;

                        z = (-(coef[0] * x + coef[2] * y + coef[3]) / coef[1]);

                        if (x > 0 && y > 0 && x < bmp.Width && y < bmp.Height)
                        {
                            #region А здесь проверяется ZBuffer (как он работает почитайте в методичке)
                            if (z > ZBuffer[x, bmp.Height - y])
                            {
                                ZBuffer[x, bmp.Height - y] = z;
                                bmp.SetPixel(x, bmp.Height - y, color);
                            }
                            #endregion
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получаем координуту X зная начало и конец линии и пересечение с прямой Y
        /// </summary>
        /// <param name="p1">Начало линии</param>
        /// <param name="p2">Конец линии</param>
        /// <param name="y">Прямая</param>
        private static int CalculateX(Point3D p1, Point3D p2, int y)
        {
            double k = (double)(p2.X - p1.X) / (p2.Z - p1.Z);
            int res = (int)(p1.X + (y - p1.Z) * k);
            return res;
        }

        /// <summary>
        /// Высчитываем косинус по векторам
        /// </summary>
        private double GetCos(Vector v1, Vector v2)
        {
            return Vector.ScalarMultiplying(v1, v2) / (v1.Length * v2.Length);
        }

        /// <summary>
        /// Создание усеченной пирамиды
        /// </summary>
        private Polyhedron TruncatedPyramidMade()
        {
            #region Задание точек
            Point3D A = new Point3D(200, 100, 590);
            Point3D B = new Point3D(100, 100, 290);
            Point3D C = new Point3D(300, 100, 290);

            Point3D A1 = new Point3D(200, 300, 490);
            Point3D B1 = new Point3D(100, 300, 290);
            Point3D C1 = new Point3D(300, 300, 290);
            #endregion

            #region Задание граней
            Polygon3D[] polygons = new Polygon3D[]
            {
                new Polygon3D(new Point3D[] { A, B, C }) {Color = Color.AliceBlue},
                new Polygon3D(new Point3D[] { A, A1, B1, B }) {Color = Color.AliceBlue},
                new Polygon3D(new Point3D[] { A, A1, C1, C }) {Color = Color.AliceBlue},
                new Polygon3D(new Point3D[] { C, C1, B1, B }) {Color = Color.AliceBlue},
                new Polygon3D(new Point3D[] { A1, B1, C1 }) {Color = Color.AliceBlue},

            };
            #endregion

            //Создаем 3D модель с гранями и вершинами
            Polyhedron polyhedron = new Polyhedron(polygons, A, B, C, A1, B1, C1);

            #region Вращение вокруг оси OX

            var center2D = new Point2D(polyhedron.Center.Y, polyhedron.Center.Z); // Точка центр фигуры
            var rotatingAngle = -Math.PI * 8 / 3; // Угол вращения

            foreach (var point in polyhedron.Vertexes)
            {
                var point2d = Grafic.Rotation(center2D, new Point2D(point.Y, point.Z), rotatingAngle); // Задаем вращение

                // Меняем координаты
                point.Y = point2d.X;
                point.Z = point2d.Y;
            }
            #endregion

            #region Вращение вокруг оси OZ
            center2D = new Point2D(polyhedron.Center.X, polyhedron.Center.Y);
            rotatingAngle = Math.PI;

            foreach (var point in polyhedron.Vertexes)
            {
                var point2d = Grafic.Rotation(center2D, new Point2D(point.X, point.Y), rotatingAngle);
                point.X = point2d.X;
                point.Y = point2d.Y;
            }
            #endregion

            return polyhedron;
        }
    }
}
