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
        private double factor;
        private double step;
        private double length = 0;


        public Spiral(Point center, double factor = 2, double step = 0.01)
        {
            this.center = center;
            this.factor = factor;
            this.step = step;
        }

        public void SetFctor(double factor)
        {
            this.factor = factor;
        }

        public void SetStep(double step)
        {
            this.step = step;
        }

        public Point CalculateNewLocation()
        {
            var x = -(int) (length * factor * Math.Cos(length)) + center.X;
            var y = -(int) (length * factor * Math.Sin(length)) + center.Y;
            length += step;
            return new Point(x, y);
        }

        public IEnumerable<Point> GetAllPoints()
        {
            var length = 0d;
            while (true)
            {
                var x = (int) (length * factor * Math.Cos(length)) + center.X;
                var y = (int) (length * factor * Math.Sin(length)) + center.Y;
                length += step;
                yield return new Point(x, y);
            }
        }
    }
}