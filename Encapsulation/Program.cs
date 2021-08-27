using System;

namespace Encapsulation
{
    class Point
    {
        public float X { get; }
        public float Y { get; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    class LineSegment
    {
        public Point Start { get; }
        public Point End { get; }

        public LineSegment(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public float Length()
        {
            var xCoordinatesDifference = End.X - Start.X;
            var yCoordinatesDifference = End.Y - Start.Y;
            return (float)Math.Sqrt(
                (xCoordinatesDifference * xCoordinatesDifference) +
                (yCoordinatesDifference * yCoordinatesDifference));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var lineSegment = new LineSegment(new Point(-3, -2), new Point(1, 1));

            Console.WriteLine($"Length of the segment is {lineSegment.Length()}");
            Console.ReadKey();
        }

        //no encapsulation here
        //static float Length(LineSegment lineSegment)
        //{
        //    var xCoordinatesDifference = lineSegment.End.X - lineSegment.Start.X;
        //    var yCoordinatesDifference = lineSegment.End.Y - lineSegment.Start.Y;
        //    return (float)Math.Sqrt(
        //        (xCoordinatesDifference * xCoordinatesDifference) +
        //        (yCoordinatesDifference* yCoordinatesDifference));
        //}
    }
}
