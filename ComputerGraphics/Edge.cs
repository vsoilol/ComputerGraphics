using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    public struct Edge
    {
        public Point EndPoint { get; set; }
        public Point StartingPoint { get; set; }

        public Edge(Point startingPoint, Point endPoint)
        {
            if(startingPoint.Y > endPoint.Y)
            {
                StartingPoint = endPoint;
                EndPoint = startingPoint;
            }
            else if(startingPoint.Y == endPoint.Y)
            {
                if(startingPoint.X > endPoint.X)
                {
                    StartingPoint = endPoint;
                    EndPoint = startingPoint;
                }
                else
                {
                    StartingPoint = startingPoint;
                    EndPoint = endPoint;
                }
            }
            else
            {
                StartingPoint = startingPoint;
                EndPoint = endPoint;
            }
        }
    }
}
