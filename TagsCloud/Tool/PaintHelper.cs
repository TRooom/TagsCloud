using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public static class PaintHelper
    {
        public static Point CalculateCenterLocation(Size actualSize)
        {
            var offset = new Point(actualSize.Width / 2, actualSize.Height / 2);
            return offset;
        }

        public static Size CalculateNewSize(Size size, float factor)
        {
            var width = (int) Math.Round(size.Width * factor);
            var height = (int) Math.Round(size.Height * factor);
            return new Size(width, height);
        }

        public static float CalculateTransformationFactor(Size actual, Size specified)
        {
            var widthDiff = (float) specified.Width / actual.Width;
            var heidthDiff = (float) specified.Height / actual.Height;
            return Math.Min(widthDiff, heidthDiff);
        }

        public static Size CalculateImageSize(IEnumerable<Rectangle> rectangles)
        {
            var height = 0;
            var width = 0;
            foreach (var rectangle in rectangles)
            {
                if (Math.Abs(rectangle.Top) > height)
                    height = Math.Abs(rectangle.Top);
                if (Math.Abs(rectangle.Bottom) > height)
                    height = Math.Abs(rectangle.Bottom);
                if (Math.Abs(rectangle.Right) > width)
                    width = Math.Abs(rectangle.Right);
                if (Math.Abs(rectangle.Left) > width)
                    width = Math.Abs(rectangle.Left);
            }
            return new Size((width + 1) * 2, (height + 1) * 2);
        }

        public static int TryFindEmSize(Size bound, string str, string fontName, Graphics g)
        {
            var emSize = 1;
            var updated = new Font(fontName, emSize);
            while (IsFit(g.MeasureString(str, updated), bound))
            {
                emSize++;
                updated = new Font(fontName, emSize);
            }
            return emSize - 1;
        }

        public static bool IsFit(SizeF inner, Size outer)
        {
            return inner.Width <= outer.Width && inner.Height < outer.Height;
        }

        public static Rectangle ToRect(Tuple<Tag, Point> placedTag)
        {
            var loc = placedTag.Item2;
            var size = placedTag.Item1.Size;
            return new Rectangle(loc, size);
        }
    }
}