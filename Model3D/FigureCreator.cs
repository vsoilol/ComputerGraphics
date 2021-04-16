using System.Collections.Generic;

namespace Model3D
{
    public static class FigureCreator
    {
        public static Figure3D TruncatedPyramid; // Усеченная пирамида
        public static Figure3D Cube; // Куб

        static FigureCreator()
        {
            TruncatedPyramid = new Figure3D();
            CreateTruncatedPyramidVertex();
            TruncatedPyramid.CreateEdgesAndFaces += CreateTruncatedPyramidEdgesAndFaces;

            Cube = new Figure3D();
            CreateCubeVertex();
            Cube.CreateEdgesAndFaces += CreateCubeEdgesAndFaces;
        }

        #region Усеченная пирамида

        /// <summary>
        /// Создание координат вершин фигуры
        /// </summary>
        private static void CreateTruncatedPyramidVertex()
        {
            TruncatedPyramid.InitialVertex = new List<Point3D>{
                new Point3D(-1, -0.5, -1),
                new Point3D(1, -0.5, -1),
                new Point3D(0, -0.5, 2),
                new Point3D(0, 1, 0.8),
                new Point3D(-0.5, 1, -0.5),
                new Point3D(0.5, 1, -0.5)
            };
        }

        /// <summary>
        /// Создание рёбер и граней фигуры
        /// </summary>
        private static void CreateTruncatedPyramidEdgesAndFaces()
        {
            List<Point3D> vertex = TruncatedPyramid.Vertex;

            TruncatedPyramid.Edges = new List<PolyhedromEdge>()
            {
                new PolyhedromEdge(vertex[0], vertex[1]),//0
                new PolyhedromEdge(vertex[2], vertex[1]),//1
                new PolyhedromEdge(vertex[2], vertex[0]),//2

                new PolyhedromEdge(vertex[5], vertex[4]),//3
                new PolyhedromEdge(vertex[5], vertex[3]),//4
                new PolyhedromEdge(vertex[4], vertex[3]),//5

                new PolyhedromEdge(vertex[4], vertex[0]),//6
                new PolyhedromEdge(vertex[5], vertex[1]),//7
                new PolyhedromEdge(vertex[2], vertex[3])//8
            };

            List<PolyhedromEdge> edges = TruncatedPyramid.Edges;

            TruncatedPyramid.Faces = new List<PolyhedronFaces>()
            {
                new PolyhedronFaces(edges[1], edges[0], edges[2]),
                new PolyhedronFaces(edges[4], edges[5], edges[3]),

                new PolyhedronFaces(edges[5], edges[2], edges[8], edges[6]),

                new PolyhedronFaces(edges[7], edges[8], edges[1], edges[4]),

                new PolyhedronFaces(edges[3], edges[0], edges[6], edges[7]),
            };
        }
        #endregion

        #region Куб

        /// <summary>
        /// Создание координат вершин фигуры
        /// </summary>
        private static void CreateCubeVertex()
        {
            Cube.InitialVertex = new List<Point3D>{
                new Point3D(1, 1, 1),
                new Point3D(1, -1, 1),
                new Point3D(-1, 1, 1),
                new Point3D(-1, -1, 1),

                new Point3D(-1, -1, -1),
                new Point3D(1, -1, -1),
                new Point3D(-1, 1, -1),
                new Point3D(1, 1, -1)
            };
        }

        /// <summary>
        /// Создание рёбер и граней фигуры
        /// </summary>
        private static void CreateCubeEdgesAndFaces()
        {
            List<Point3D> vertex = Cube.Vertex;

            Cube.Edges = new List<PolyhedromEdge>()
            {
                new PolyhedromEdge(vertex[0], vertex[1]),//0
                new PolyhedromEdge(vertex[1], vertex[3]),//1
                new PolyhedromEdge(vertex[3], vertex[2]),//2
                new PolyhedromEdge(vertex[2], vertex[0]),//3

                new PolyhedromEdge(vertex[7], vertex[6]),//4
                new PolyhedromEdge(vertex[6], vertex[4]),//5
                new PolyhedromEdge(vertex[4], vertex[5]),//6
                new PolyhedromEdge(vertex[7], vertex[5]),//7

                new PolyhedromEdge(vertex[6], vertex[2]),//8
                new PolyhedromEdge(vertex[7], vertex[0]),//9
                new PolyhedromEdge(vertex[1], vertex[5]),//10
                new PolyhedromEdge(vertex[4], vertex[3])//11
            };

            List<PolyhedromEdge> edges = Cube.Edges;

            Cube.Faces = new List<PolyhedronFaces>()
            {
                new PolyhedronFaces(edges[3], edges[1], edges[0], edges[2]),
                new PolyhedronFaces(edges[4], edges[6], edges[7], edges[5]),

                new PolyhedronFaces(edges[9], edges[3], edges[8], edges[4]),
                new PolyhedronFaces(edges[10], edges[11], edges[6], edges[1]),

                new PolyhedronFaces(edges[8], edges[2], edges[11], edges[5]),
                new PolyhedronFaces(edges[7], edges[10], edges[0], edges[9])
            };
        }
        #endregion
    }
}
