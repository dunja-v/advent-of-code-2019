using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Wires
    {
        public static void CalculateResult()
        {
            string inputFile = @"";
            string text = File.ReadAllText(inputFile);

            string[] wires = text.Split('\n');
            Wire wire1 = LoadWire(wires[0]);
            Wire wire2 = LoadWire(wires[1]);

            Console.WriteLine(FindNearestIntersection(wire1, wire2));
        }

        public static Wire LoadWire(string wireCode)
        {
            string[] segments = wireCode.Split(',');
            List<WireSegment> wireSegments = new List<WireSegment>();

            int currentX = 0;
            int currentY = 0;
            int currentLength = 0;

            foreach (var segment in segments)
            {
                wireSegments.Add(ParseWireSegment(segment, currentLength, ref currentX, ref currentY, out int distance));
                currentLength += distance;
            }

            return new Wire(wireSegments);
        }

        public static WireSegment ParseWireSegment(string segmentStr, int currentLength, ref int currentX, ref int currentY, out int distance)
        {
            char direction = segmentStr[0];
            distance = Int32.Parse(segmentStr.Substring(1, segmentStr.Length - 1));

            int nextX = currentX;
            int nextY = currentY;

            if (direction == (char)Directions.Right)
            {
                nextX += distance;
            }
            if (direction == (char)Directions.Left)
            {
                nextX -= distance;
            }
            if (direction == (char)Directions.Up)
            {
                nextY += distance;
            }
            if (direction == (char)Directions.Down)
            {
                nextY -= distance;
            }

            WireSegment wireSegment = new WireSegment(currentX, currentY, nextX, nextY, currentLength);
            currentX = nextX;
            currentY = nextY;

            return wireSegment;
        }

        public static int FindNearestIntersection(Wire wire1, Wire wire2)
        {
            var segments1 = wire1.Segments;
            var segments2 = wire2.Segments;

            return FindIntersection(segments1, segments2);
        }

        public static int FindIntersection(List<WireSegment> segments1, List<WireSegment> segments2)
        {
            int x;
            int y;
            int distance = Int32.MaxValue;
            bool areFirstSegments = true;

            foreach(var segment1 in segments1)
            {
                foreach(var segment2 in segments2)
                {
                    if (areFirstSegments)
                    {
                        areFirstSegments = false;
                        continue;
                    }
                    if (segment1.Intersects(segment2))
                    {
                        segment1.getIntersection(segment2, out int newX, out int newY);

                        int newDistance = segment1.DistanceTo + segment2.DistanceTo;
                        newDistance += Math.Abs(segment1.RealStartX - newX) + Math.Abs(segment2.RealStartX - newX)
                            + Math.Abs(segment1.RealStartY - newY) + Math.Abs(segment2.RealStartY - newY);

                        if (newDistance == 0)
                        {
                            continue;
                        }

                        if(newDistance < distance)
                        {
                            distance = newDistance;
                            x = newX;
                            y = newY;
                        }
                    }
                }
            }
            return distance;
        }
    }

    enum Directions
    {
        Right = 'R',
        Left = 'L',
        Down = 'D',
        Up = 'U'
    }


    class Wire
    {
        public Wire(List<WireSegment> wireSegments)
        {
            this.Segments = wireSegments;
        }

        public List<WireSegment> Segments { get; set; }
    }


    class WireSegment
    {
        public WireSegment(int XStart, int YStart, int XEnd, int YEnd, int distanceTo)
        {
            this.RealStartX = XStart;
            this.RealStartY = YStart;

            if(XStart < XEnd || YStart < YEnd)
            {
                this.XStart = XStart;
                this.YStart = YStart;
                this.XEnd = XEnd;
                this.YEnd = YEnd;
            }
            else
            {
                this.XStart = XEnd;
                this.YStart = YEnd;
                this.XEnd = XStart;
                this.YEnd = YStart;
            }
            this.DistanceTo = distanceTo;
            
        }

        public bool Intersects(WireSegment other)
        {
            if(((this.XStart >= other.XStart && this.XStart <= other.XEnd) ||
                (this.XEnd >= other.XStart && this.XEnd <= other.XEnd) || 
                (this.XStart <= other.XStart && this.XEnd >= other.XEnd) ||
                (other.XStart <= this.XStart && other.XEnd >= this.XEnd))&&
                ((this.YStart >= other.YStart && this.YStart <= other.YEnd) ||
                (this.YEnd >= other.YStart && this.YEnd <= other.YEnd) ||
                (this.YStart <= other.YStart && this.YEnd >= other.YEnd) ||
                (other.YStart <= this.YStart && other.YEnd >= this.YEnd)))
            {
                return true;
            }
            return false;
        }

        internal void getIntersection(WireSegment other, out int x, out int y)
        {
            x = XStart == XEnd ? XStart : other.XStart;
            y = YStart == YEnd ? YStart : other.YStart;
        }

        public int XStart { get; set; }
        public int YStart { get; set; }
        public int XEnd { get; set; }
        public int YEnd { get; set; }

        public int RealStartX { get; set; }
        public int RealStartY { get; set; }

        public int DistanceTo { get; set; }
    }

}
