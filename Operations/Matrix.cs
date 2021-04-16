using System.Drawing;

namespace Operations
{
    public static class Matrix
    {
        /// <summary>
        /// Меняем координаты точки зная коэффициенты
        /// </summary>
        /// <param name="transformativeOne">Первая строка матрицы содержащая коэффициенты для переобразования</param>
        /// <param name="transformativeTwo">Вторая строка матрицы содержащая коэффициенты для переобразования</param>
        /// <param name="mainPoint">Точка для которой нужно расчитать новые координаты</param>
        /// <param name="centerPoint">Координаты центра фигуры</param>
        /// <returns>Новые координаты для точки</returns>
        public static Point Multiply(double[] transformativeOne, double[] transformativeTwo, Point mainPoint, Point centerPoint)
        {
            Point result = new Point
            {
                X = (int)(centerPoint.X + transformativeOne[0] * (mainPoint.X - centerPoint.X) + transformativeOne[1] * (mainPoint.Y - centerPoint.Y) + transformativeOne[2]),
                Y = (int)(centerPoint.Y + transformativeTwo[0] * (mainPoint.X - centerPoint.X) + transformativeTwo[1] * (mainPoint.Y - centerPoint.Y) + transformativeTwo[2])
            };

            return result;
        }
    }
}
