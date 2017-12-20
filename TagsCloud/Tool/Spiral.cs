using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Tool
{
    internal class Spiral
    {
        private readonly Point center;
        private readonly double a;
        private readonly double step;
        private double length = 0;


        public Spiral(Point center, double a = 2, double step = 0.01)
        {
            this.center = center;
            this.a = a;
            this.step = step;
        }

        public Point CalculateNewLocation()
        {
            var x = -(int) (length * a * Math.Cos(length)) + center.X;
            var y = -(int) (length * a * Math.Sin(length)) + center.Y;
            length += step;
            return new Point(x, y);
        }

        public IEnumerable<Point> GetAllPoints()
        {
            var length = 0d;
            while (true)
            {
                var x = (int) (length * a * Math.Cos(length)) + center.X;
                var y = (int) (length * a * Math.Sin(length)) + center.Y;
                length += step;
                yield return new Point(x, y);
            }
        }
    }
}