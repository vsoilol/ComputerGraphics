using System.Collections.Generic;

namespace Model3D
{
    public struct PolyhedronFaces
    {
        public List<PolyhedromEdge> Lines { get; set; }

        public PolyhedronFaces(params PolyhedromEdge[] lines)
        {
            Lines = new List<PolyhedromEdge>();

            foreach (var item in lines)
            {
                Lines.Add(item);
            }
        }
    }
}
