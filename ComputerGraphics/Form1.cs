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

            List<Polygon3D> list = new List<Polygon3D>();

            list.AddRange(TruncatedPyramidMade().Faces);
            list.AddRange(CubeMade().Faces);

            ZBuffer(bmp, list.ToArray(), new Point3D(0, -1, 0));
            pictureBox1.Image = bmp;
        }

        /// <summary>
        /// Основной алгоритм
        /// </summary>
        /// <param name="bmp">Bitmap</param>
        /// <param name="polygons">Список фигур</param>
        /// <param name="LightPoint">Положение точки освещения</param>
        public static void ZBuffer(Bitmap bmp, Polygon3D[] polygons, Point3D LightPoint)
        {
            double[,] ZBuffer = new double[bmp.Width, bmp.Height];

            #region Заполняем ZBuffer минимальными значениями
            for (int y = 0; y < ZBuffer.GetLength(1); y++)
            {
                for (int x = 0; x < ZBuffer.GetLength(0); x++)
                {
                    ZBuffer[x, y] = double.NegativeInfinity;
                }
            }
            #endregion


            for (int polygon = 0; polygon < polygons.Length; polygon++)
            {
                Point3D[] pointsBuf = new Point3D[polygons[polygon].Points.Length + 1];


                polygons[polygon].Points.CopyTo(pointsBuf, 0); // Копируем все значения в массив pointsBuf
                pointsBuf[pointsBuf.Length - 1] = pointsBuf[0]; // Последнему элементу присваиваем первый

                List<Line> CAP = new List<Line>();

                //Так как координаты повернуты странно, то минимальное y для программы это минимальный z для нас
                int ymin = (int)pointsBuf.Min(x => x.Z); // Максимум
                int ymax = (int)pointsBuf.Max(x => x.Z); // Минимум

                #region Высчитываем освещение

                //Высчитываем коээфициенты вектора нормали
                double[] coef = polygons[polygon].CalculateCoefficients(new Point3D(0, 0, 0));
                double[] coef1 = polygons[polygon].CalculateCoefficients(new Point3D(0, 0, 0));

                //Что бы вектор нормали был направлен правильно
                for (int i = 0; i < 4; i++)
                {
                    coef1[i] *= Math.Sign(coef1[3]);
                }

                // Получаем косинус между вектором нормали и вектором который направлен из точки освещения к нормали
                double L = GetCos(new Point3D(coef1[0], coef1[1], coef1[2]), LightPoint);

                // Используя формулу из методички (Диффузное освещение) находим цвета для граней
                int R = (int)(polygons[polygon].Color.R * 1 * L);
                R = R > 0 && R < 255 ? R : R > 0 ? 255 : 0; // Проверяем чтобы не была больше 255 или меньше 0

                int G = (int)(polygons[polygon].Color.G * 1 * L);
                G = G > 0 && G < 255 ? G : G > 0 ? 255 : 0;

                int B = (int)(polygons[polygon].Color.B * 1 * L);
                B = B > 0 && B < 255 ? B : B > 0 ? 255 : 0;
                #endregion

                Color color = Color.FromArgb(R, G, B); // Получаем цвет

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
                            CAP.Add(new Line(new Point3D(pointsBuf[i].X, pointsBuf[i].Z, pointsBuf[i].Y), new Point3D(pointsBuf[i - 1].X, pointsBuf[i - 1].Z, pointsBuf[i - 1].Y)));
                        }
                    }

                    int xmin = Math.Min(CalculateX(CAP[0].Point1, CAP[0].Point2, y), CalculateX(CAP[1].Point1, CAP[1].Point2, y));
                    int xmax = Math.Max(CalculateX(CAP[0].Point1, CAP[0].Point2, y), CalculateX(CAP[1].Point1, CAP[1].Point2, y));
                    #endregion

                    for (int x = xmin; x < xmax; x++)
                    {
                        double z = 0;
                        z = (-(coef[0] * x + coef[2] * y + coef[3]) / coef[1]); // Высчитываем z по коэффициентам

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
        private static int CalculateX(Point2D p1, Point2D p2, double y)
        {
            double k = (p2.X - p1.X) / (p2.Y - p1.Y);
            int res = (int)(p1.X + (y - p1.Y) * k);
            return res;
        }

        /// <summary>
        /// Высчитываем косинус по коэффициента векторов
        /// </summary>
        /// <param name="p1">Коэффициенты первого вектора</param>
        /// <param name="p2">Коэффициенты второго вектора</param>
        private static double GetCos(Point3D p1, Point3D p2)
        {
            double p1Length = Math.Pow((Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2) + Math.Pow(p1.Z, 2)), 0.5);
            double p2Length = Math.Pow((Math.Pow(p2.X, 2) + Math.Pow(p2.Y, 2) + Math.Pow(p2.Z, 2)), 0.5);

            double cos = (p1.X * p2.X + p1.Y * p2.Y + p1.Z * p2.Z) / (p1Length * p2Length);
            return cos;
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
                new Polygon3D(new Point3D[] { A, B, C }) {Color = Color.Green},
                new Polygon3D(new Point3D[] { A, A1, B1, B }) {Color = Color.Green},
                new Polygon3D(new Point3D[] { A, A1, C1, C }) {Color = Color.Green},
                new Polygon3D(new Point3D[] { C, C1, B1, B }) {Color = Color.Green},
                new Polygon3D(new Point3D[] { A1, B1, C1 }) {Color = Color.Green},

            };
            #endregion

            //Создаем 3D модель с гранями и вершинами
            Polyhedron polyhedron = new Polyhedron(polygons, A, B, C, A1, B1, C1);

            #region Вращение вокруг оси OX

            var center2D = new Point2D(polyhedron.Center.Y, polyhedron.Center.Z); // Точка центр фигуры
            var rotatingAngle = -Math.PI * 4 / 3; // Угол вращения

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
            rotatingAngle = -Math.PI / 25;

            foreach (var point in polyhedron.Vertexes)
            {
                var point2d = Grafic.Rotation(center2D, new Point2D(point.X, point.Y), rotatingAngle);
                point.X = point2d.X;
                point.Y = point2d.Y;
            }
            #endregion

            return polyhedron;
        }

        /// <summary>
        /// Создание куба
        /// </summary>
        private Polyhedron CubeMade()
        {
            Point3D A = new Point3D(100, 200, 190);
            Point3D B = new Point3D(100, 0, 190);
            Point3D C = new Point3D(300, 0, 190);
            Point3D D = new Point3D(300, 200, 190);

            Point3D A1 = new Point3D(100, 200, 390);
            Point3D B1 = new Point3D(100, 0, 390);
            Point3D C1 = new Point3D(300, 0, 390);
            Point3D D1 = new Point3D(300, 200, 390);

            Polygon3D[] polygons = new Polygon3D[]
            {
                new Polygon3D(new Point3D[] {  A1, D1, D, A }){Color = Color.Blue},
                new Polygon3D(new Point3D[] { D1, C1, B1, A1 }){Color = Color.Blue},
                new Polygon3D(new Point3D[] { A, B, C, D }){Color = Color.Blue},
                new Polygon3D(new Point3D[] { A, B, B1, A1 }){Color = Color.Blue},
                new Polygon3D(new Point3D[] { B1, C1, C, B }){Color = Color.Blue},
                new Polygon3D(new Point3D[] { C, D, D1, C1 }){Color = Color.Blue},
            };

            Polyhedron polyhedron = new Polyhedron(polygons, A, B, C, D, A1, B1, C1, D1);

            #region Вращение вокруг оси OZ
            var center2D = new Point2D(polyhedron.Center.X, polyhedron.Center.Y);
            double rotatingAngle = -Math.PI / 4;

            foreach (var point in polyhedron.Vertexes)
            {
                var point2d = Grafic.Rotation(center2D, new Point2D(point.X, point.Y), rotatingAngle);
                point.X = point2d.X;
                point.Y = point2d.Y;
            }
            #endregion

            #region Вращение вокруг оси OX
            rotatingAngle = Math.PI / 4;
            center2D = new Point2D(polyhedron.Center.Y, polyhedron.Center.Z);

            foreach (var point in polyhedron.Vertexes)
            {
                var point2d = Grafic.Rotation(center2D, new Point2D(point.Y, point.Z), rotatingAngle);
                point.Y = point2d.X;
                point.Z = point2d.Y;
            }
            #endregion

            return polyhedron;
        }
    }
}
