using System;
using System.Collections.Generic;
using System.Linq;

namespace Model3D
{
    public class Figure3D
    {
        public List<Point3D> Vertex { get; set; } // Вершины
        public List<PolyhedromEdge> Edges { get; set; } // Ребра
        public List<PolyhedronFaces> Faces { get; set; } // Грани

        public List<Point3D> InitialVertex { get; set; } // Первоначальные координаты вершин

        private List<PolyhedronFaces> InvisibleEdges; // Невидимые грани

        public event Action CreateEdgesAndFaces; // Событие на задание вершин и рёбер

        /// <summary>
        /// Высчитывает новые координаты вершин для преобразования
        /// </summary>
        public void SetConversions(double scale, Point3D position, double yaw, double pitch, double roll)
        {
            //матрица масштабирования
            var scaleMatrix = Matrix4x4.CreateScale(scale / 2);
            ////матрица вращения
            var rotateMatrix = Matrix4x4.CreateFromYawPitchRoll(yaw, pitch, roll);
            //матрица переноса
            var translateMatrix = Matrix4x4.CreateTranslation(position);

            //результирующая матрица
            var resultMatrix = translateMatrix * scaleMatrix * rotateMatrix;

            Vertex = new List<Point3D>();

            foreach (var vertex in InitialVertex)
            {
                Vertex.Add(resultMatrix * vertex);
            }

            CreateEdgesAndFaces();
        }

        /// <summary>
        /// Удаление невидимых линий
        /// </summary>
        public void DeleteLines()
        {
            CalculateNormals();

            List<PolyhedromEdge> intermediateList = new List<PolyhedromEdge>();

            for (int i = 0; i < InvisibleEdges.Count; i++)
            {
                for (int l = i + 1; l < InvisibleEdges.Count; l++)
                {
                    intermediateList.AddRange(InvisibleEdges[i].Lines.Where(x => InvisibleEdges[l].Lines.Contains(x)));
                }
            }

            foreach (var item in intermediateList)
            {
                Edges.Remove(item);
            }
        }

        /// <summary>
        /// Подсчет нормалей граней
        /// </summary>
        private void CalculateNormals()
        {
            var normal = new double[Faces.Count][];
            InvisibleEdges = new List<PolyhedronFaces>();

            for (int i = 0; i < Faces.Count; i++)
            {
                var t1 = Faces[i].Lines[0].StartPoint;
                var t2 = Faces[i].Lines[0].EndPoint;
                var t3 = Faces[i].Lines[1].StartPoint;

                normal[i] = new double[3]
                {
                    t1.Y * (t2.Z - t3.Z) + t2.Y * (t3.Z - t1.Z) + t3.Y * (t1.Z - t2.Z),
                    t1.Z * (t2.X - t3.X) + t2.Z * (t3.X - t1.X) + t3.Z * (t1.X - t2.X),
                    t1.X * (t2.Y - t3.Y) + t2.X * (t3.Y - t1.Y) + t3.X * (t1.Y - t2.Y)

                };

                if ((normal[i][0] - normal[i][1] - 100 * normal[i][2]) < 0)
                {
                    InvisibleEdges.Add(Faces[i]);
                }
            }
        }
    }
}
