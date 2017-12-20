using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class CircularCloudLayouter : ITagLayouter
    {
        private List<Rectangle> addedRectangles;
        private Spiral spiral;
        private readonly Point center;

        public CircularCloudLayouter(Point center, double fator = 2, double step = 0.01)
        {
            addedRectangles = new List<Rectangle>();
            spiral = new Spiral(center, fator, step);
            this.center = center;
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            var location = spiral.CalculateNewLocation();
            var newRect = new Rectangle(location, rectangleSize);
            while (!IsCorrectPlaced(newRect))
                newRect = new Rectangle(spiral.CalculateNewLocation(), rectangleSize);
            addedRectangles.Add(newRect);
            return newRect;
        }

        private bool IsCorrectPlaced(Rectangle rect)
        {
            return addedRectangles.All(addedRec => !addedRec.IntersectsWith(rect));
        }

        public IEnumerable<Tuple<Tag, Point>> LayoutTags(IEnumerable<Tag> tags)
        {
            addedRectangles = new List<Rectangle>();
            spiral = new Spiral(center);
            var placed = tags.Select(x => Tuple.Create(x, PutNextRectangle(x.Size).Location)).ToList();
            return placed;
        }
    }
}