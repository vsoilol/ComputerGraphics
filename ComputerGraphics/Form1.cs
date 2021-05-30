using GraficLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bool IsRotating = true; // Если поставить false вращения не будет

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Polyhedron figurePolyhedron = TruncatedPyramidMade();
            Vector lightPosition = new Vector(0, -1, 0);
            int p = 1; // Показатель полировки (МЕТОДИЧКА)

            // Вращение
            Task.Factory.StartNew(() =>
            {
                do
                {
                    bmp = new Bitmap(bmp.Width, bmp.Height);
                    DrawPolyhedronByPhong(bmp, figurePolyhedron, lightPosition, p);
                    pictureBox1.Image = bmp;

                    var rotatingAngle = -Math.PI / 4;
                    var center2D = new Point2D(figurePolyhedron.Center.Y, figurePolyhedron.Center.Z);

                    foreach (var point in figurePolyhedron.Vertexes)
                    {
                        var point2d = Grafic.Rotation(center2D, new Point2D(point.Y, point.Z), rotatingAngle);
                        point.Y = point2d.X;
                        point.Z = point2d.Y;
                    }

                    center2D = new Point2D(figurePolyhedron.Center.X, figurePolyhedron.Center.Y);
                    rotatingAngle = Math.PI / 18;

                    foreach (var point in figurePolyhedron.Vertexes)
                    {
                        var point2d = Grafic.Rotation(center2D, new Point2D(point.X, point.Y), rotatingAngle);
                        point.X = point2d.X;
                        point.Y = point2d.Y;
                    }

                    rotatingAngle = Math.PI / 4;
                    center2D = new Point2D(figurePolyhedron.Center.Y, figurePolyhedron.Center.Z);

                    foreach (var point in figurePolyhedron.Vertexes)
                    {
                        var point2d = Grafic.Rotation(center2D, new Point2D(point.Y, point.Z), rotatingAngle);
                        point.Y = point2d.X;
                        point.Z = point2d.Y;
                    }

                } while (IsRotating);
            });
        }

        /// <summary>
        /// Основной алгоритм
        /// </summary>
        /// <param name="bmp">Bitmap</param>
        /// <param name="polyhedron">Фигура</param>
        /// <param name="lightPoint">Положение источника света</param>
        /// <param name="p">Показатель полировки</param>
        private void DrawPolyhedronByPhong(Bitmap bmp, Polyhedron polyhedron, Vector lightPoint, double p)
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

                // Точки которые находятся в САР
                Point3D[] pointsBuf = new Point3D[polyhedron.Faces[polygon].Points.Length + 1];

                polyhedron.Faces[polygon].Points.CopyTo(pointsBuf, 0); // Копируем все значения в массив pointsBuf
                pointsBuf[pointsBuf.Length - 1] = pointsBuf[0]; // Последнему элементу присваиваем первый

                Vector[] VforPoints = new Vector[pointsBuf.Length];

                // Находим нормали в вершинах и заносим их в VforPoints
                for (int i = 0; i < VforPoints.Length - 1; i++)
                {
                    // Находим все грани которые содержат точки находящиеся в САР
                    var polygons = polyhedron.Faces.ToList().FindAll(x => x.Points.Contains(pointsBuf[i]));
                    Vector normal = new Vector();

                    for (int k = 0; k < polygons.Count; k++)
                    {
                        int index = polyhedron.Faces.ToList().IndexOf(polygons[k]);
                        normal.X += polyhedron.BodyMatrix[0, index];
                        normal.Y += polyhedron.BodyMatrix[1, index];
                        normal.Z += polyhedron.BodyMatrix[2, index];
                    }

                    normal.X /= polygons.Count;
                    normal.Y /= polygons.Count;
                    normal.Z /= polygons.Count;

                    VforPoints[i] = normal;
                }

                VforPoints[VforPoints.Length - 1] = VforPoints[0];
                List<Tuple<Point3D, Point3D, Vector, Vector>> CAP = new List<Tuple<Point3D, Point3D, Vector, Vector>>();

                //Так как координаты повернуты странно, то минимальное y для программы это минимальный z для нас
                int ymin = (int)Math.Round(pointsBuf.Min(point => point.Z));
                int ymax = (int)Math.Round(pointsBuf.Max(point => point.Z));

                for (int y = ymin; y < ymax; y++)
                {
                    CAP.Clear();

                    #region Здесь говорите преподу что выполняется алгоритм САР
                    for (int i = 1; i < pointsBuf.Length; i++)
                    {
                        int a = (int)Math.Min(pointsBuf[i].Z, pointsBuf[i - 1].Z);
                        int b = (int)Math.Max(pointsBuf[i].Z, pointsBuf[i - 1].Z);

                        bool IsActive = a < y && b >= y && a != b;

                        if (IsActive)
                        {
                            CAP.Add(new Tuple<Point3D, Point3D, Vector, Vector>(pointsBuf[i], pointsBuf[i - 1], VforPoints[i], VforPoints[i - 1]));
                        }
                    }
                    #endregion

                    try
                    {
                        #region Высчитываются значения (МЕТОДИЧКА)
                        int xmin = Math.Min(CalculateX(CAP[0].Item1, CAP[0].Item2, y), CalculateX(CAP[1].Item1, CAP[1].Item2, y));
                        int xmax = Math.Max(CalculateX(CAP[0].Item1, CAP[0].Item2, y), CalculateX(CAP[1].Item1, CAP[1].Item2, y));

                        double Ya, Yb, Yc, Yd;
                        Vector Va, Vb, Vc, Vd;

                        Tuple<Point3D, Point3D, Vector, Vector> left = CAP[1];
                        Tuple<Point3D, Point3D, Vector, Vector> right = CAP[0];

                        if (CalculateX(CAP[0].Item1, CAP[0].Item2, y) < CalculateX(CAP[1].Item1, CAP[1].Item2, y))
                        {
                            left = CAP[0];
                            right = CAP[1];
                        }

                        Ya = right.Item1.Z;
                        Va = right.Item3;
                        Yb = right.Item2.Z;
                        Vb = right.Item4;
                        Yd = left.Item1.Z;
                        Vd = left.Item3;
                        Yc = left.Item2.Z;
                        Vc = left.Item4;

                        Vector V1 = Vd + (Vc - Vd) * (y - Yd) / (Yc - Yd);
                        Vector V2 = Va + (Vb - Va) * (y - Ya) / (Yb - Ya);
                        #endregion

                        for (int x = xmin; x < xmax; x++)
                        {
                            Vector V = V1 + (V2 - V1) * (x - xmin) / (xmax - xmin);

                            double I = Math.Pow(GetCos(V, lightPoint), p); // Интенсивность для зеркального освещения

                            // Высчитываем цвет освещения
                            int R = (int)(polyhedron.Faces[polygon].Color.R * I + 40);
                            R = R > 0 && R < 255 ? R : R > 0 ? 255 : 0; // Проверяем чтобы не была больше 255 или меньше 0

                            int G = (int)(polyhedron.Faces[polygon].Color.G * I + 40);
                            G = G > 0 && G < 255 ? G : G > 0 ? 255 : 0;

                            int B = (int)(polyhedron.Faces[polygon].Color.B * I + 40);
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
                    catch (Exception)
                    {

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
