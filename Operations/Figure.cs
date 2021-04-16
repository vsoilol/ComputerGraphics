using Algorithm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public static class Figure
    {
        /// <summary>
        /// Поворот фигуры
        /// </summary>
        /// <param name="angle">Угол поворота</param>
        /// <param name="figure">Фигура</param>
        /// <returns>Повёрнутая фигура</returns>
        public static IEnumerable<Edge> RotateFigure(double angle, IEnumerable<Edge> figure)
        {
            List<Edge> mainFigure = figure.ToList();

            var maxPointY = mainFigure.OrderBy(edge => edge.EndPoint.Y).Last().EndPoint.Y;
            var minPointY = mainFigure.OrderBy(edge => edge.StartingPoint.Y).First().StartingPoint.Y;

            var maxPointX = mainFigure.OrderBy(edge => edge.EndPoint.X).Last().EndPoint.X;
            var minPointX = mainFigure.OrderBy(edge => edge.StartingPoint.X).First().StartingPoint.X;

            var halfY = (maxPointY - minPointY) / 2;
            var halfX = (maxPointX - minPointX) / 2;

            Point centerPoint = new Point(halfX + minPointX, halfY + minPointY);

            double[][] matrix = new double[][]
            {
                new double[] { Math.Round(Math.Cos(angle * Math.PI / 180), 5), -Math.Round(Math.Sin(angle * Math.PI / 180), 5), 0 },
                new double[] { Math.Round(Math.Sin(angle * Math.PI / 180), 5), Math.Round(Math.Cos(angle * Math.PI / 180), 5), 0 },
            };

            for (int i = 0; i < mainFigure.Count(); i++)
            {
                Edge edge = mainFigure[i];
                edge.StartingPoint = Matrix.Multiply(matrix[0], matrix[1], edge.StartingPoint, centerPoint);
                edge.EndPoint = Matrix.Multiply(matrix[0], matrix[1], edge.EndPoint, centerPoint);
                mainFigure[i] = edge;
            }

            return mainFigure;
        }

        /// <summary>
        /// Растяжение фигуру
        /// </summary>
        /// <param name="coefficient">Коэффициент растяжения, первый элемент растяжение по X, второй коэффициент растяжение по Y</param>
        /// <param name="figure">Фигура</param>
        /// <returns>Растянутая фигура</returns>
        public static IEnumerable<Edge> StretchingImage(double[] coefficient, IEnumerable<Edge> figure)
        {
            Point centerPoint = new Point(0, 0);
            List<Edge> mainFigure = figure.ToList();

            double[][] matrix = new double[][]
            {
                new double[] {coefficient[0], 0,0 },
                new double[] {0, coefficient[1], 0 },
            };

            for (int i = 0; i < mainFigure.Count(); i++)
            {
                Edge edge = mainFigure[i];
                edge.StartingPoint = Matrix.Multiply(matrix[0], matrix[1], edge.StartingPoint, centerPoint);
                edge.EndPoint = Matrix.Multiply(matrix[0], matrix[1], edge.EndPoint, centerPoint);
                mainFigure[i] = edge;
            }

            return mainFigure;
        }

        /// <summary>
        /// Движение фигуры
        /// </summary>
        /// <param name="movePoint">Координаты на которые нужно передвинуть фигуру</param>
        /// <param name="figure">Фигура</param>
        /// <returns>Подвинутая фигура</returns>
        public static IEnumerable<Edge> MoveImage(Point movePoint, IEnumerable<Edge> figure)
        {
            Point centerPoint = new Point(0, 0);
            List<Edge> mainFigure = figure.ToList();

            double[][] matrix = new double[][]
            {
                new double[] {1, 0, movePoint.X },
                new double[] {0, 1, movePoint.Y },
            };

            for (int i = 0; i < mainFigure.Count(); i++)
            {
                Edge edge = mainFigure[i];
                edge.StartingPoint = Matrix.Multiply(matrix[0], matrix[1], edge.StartingPoint, centerPoint);
                edge.EndPoint = Matrix.Multiply(matrix[0], matrix[1], edge.EndPoint, centerPoint);
                mainFigure[i] = edge;
            }

            return mainFigure;
        }

        /// <summary>
        /// Сжатие фигуру
        /// </summary>
        /// <param name="coefficient">Коэффициент сжатия, первый элемент сжатие по X, второй коэффициент сжатие по Y</param>
        /// <param name="figure">Фигура</param>
        /// <returns>Сжатая фигура</returns>
        public static IEnumerable<Edge> CompressionImage(double[] coefficient, IEnumerable<Edge> figure)
        {
            Point centerPoint = new Point(0, 0);
            List<Edge> mainFigure = figure.ToList();

            double[][] matrix = new double[][]
            {
                new double[] {(1/coefficient[0]), 0,0 },
                new double[] {0, (1/coefficient[1]), 0 },
            };

            for (int i = 0; i < mainFigure.Count(); i++)
            {
                Edge edge = mainFigure[i];
                edge.StartingPoint = Matrix.Multiply(matrix[0], matrix[1], edge.StartingPoint, centerPoint);
                edge.EndPoint = Matrix.Multiply(matrix[0], matrix[1], edge.EndPoint, centerPoint);
                mainFigure[i] = edge;
            }

            return mainFigure;
        }
    }
}
