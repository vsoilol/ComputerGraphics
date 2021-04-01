using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        Color mainColor = Color.Red;
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        public void Algorithm(IEnumerable<Edge> edges)
        {
            //pictureBox1.BackColor = Color.White;

            List<Edge> activeEdges = new List<Edge>();
            List<Edge> edgesList = edges.ToList();
            List<Edge> solidLines = new List<Edge>();

            var maxEdgeY = edgesList.OrderBy(edge => edge.EndPoint.Y).Last();
            var minEdgeY = edgesList.OrderBy(edge => edge.StartingPoint.Y).First();

            solidLines.AddRange(edgesList.Where(edge => edge.StartingPoint.Y == edge.EndPoint.Y));

            foreach (var item in solidLines)
            {
                for (int x = item.StartingPoint.X; x <= item.EndPoint.X; x++)
                {
                    bitmap.SetPixel(x, item.StartingPoint.Y, mainColor);
                }

                edgesList.Remove(item);
            }

            for (int y = minEdgeY.StartingPoint.Y; y <= maxEdgeY.EndPoint.Y; y++)
            {
                activeEdges.AddRange(edgesList.Where(edge => edge.StartingPoint.Y == y));

                activeEdges.RemoveAll(edge => edge.EndPoint.Y == y);

                List<Point> currentPoints = new List<Point>();

                foreach (var item in activeEdges)
                {
                    int x = LineBresenham(item.StartingPoint, item.EndPoint, y);

                    currentPoints.Add(new Point(x, y));
                }

                currentPoints = currentPoints.OrderBy(point => point.X).ToList();

                int a = 0;

                for (int i = 0; i < currentPoints.Count / 2; i++)
                {
                    for (int x = currentPoints[i + a].X; x <= currentPoints[i + 1 + a].X; x++)
                    {
                        bitmap.SetPixel(x, y, mainColor);
                        pictureBox1.Image = bitmap;
                    }

                    a++;
                }
            }
            pictureBox1.Image = bitmap;
        }


        private int LineBresenham(Point point0, Point point1, int checkY)
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
                    if (y == checkY)
                    {
                        return x;
                    }
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
                    if (y == checkY)
                    {
                        return x;
                    }
                    error += k;

                    if (error > 0)
                    {
                        y += direction;
                        error--;
                    }
                }
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Edge> edges = new List<Edge>();
            switch (listBox1.SelectedItem.ToString())
            {
                case "4 Стрелки":
                    edges = Shapes.FourArrows().ToList();
                    break;
                case "Произвольная фигура":
                    edges = Shapes.CustomPolygon().ToList();
                    break;
                case "Прямоугольник":
                    edges = Shapes.Rectangle().ToList();
                    break;
                case "Параллелограмм":
                    edges = Shapes.Parallelogram().ToList();
                    break;
                case "Перевернутая трапеция":
                    edges = Shapes.InvertedTrapezoid().ToList();
                    break;
                case "Равнобедренный треугольник":
                    edges = Shapes.Triangle().ToList();
                    break;
                case "3 Стрелки":
                    edges = Shapes.ThreeArrows().ToList();
                    break;
                case "Шестиугольник":
                    edges = Shapes.Hexagon().ToList();
                    break;
                case "Рубин":
                    CreateRuby();
                    return;
            }

            Algorithm(edges);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void CreateRuby()
        {
            List<Edge> edges = new List<Edge>();

            edges = Shapes.RubyMainPart().ToList();

            Algorithm(edges);

            edges = Shapes.RubyBottom().ToList();
            mainColor = Color.FromArgb(139, 0, 0);

            Algorithm(edges);

            edges = Shapes.RubyRight().ToList();
            mainColor = Color.FromArgb(178, 34, 34);

            Algorithm(edges);

            mainColor = Color.Red;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
