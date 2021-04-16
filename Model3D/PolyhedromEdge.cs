namespace Model3D
{
    public struct PolyhedromEdge
    {
        public Point3D StartPoint { get; set; }
        public Point3D EndPoint { get; set; }

        public PolyhedromEdge(Point3D startPoint, Point3D endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}
