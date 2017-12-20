using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TagsCloud.Tool;

namespace TagsCloud.Tests
{
    [TestFixture]
    public class PaintHelper_Should
    {
        [Test]
        public void CalculateImageCenter()
        {
            var size = new Size(100, 50);

            var center = PaintHelper.CalculateCenterLocation(size);

            center.ShouldBeEquivalentTo(new Point(50, 25));
        }

        [Test]
        public void CalculateАugmentativeFactor()
        {
            var actual = new Size(50, 100);
            var specified = new Size(100, 200);

            var factor = PaintHelper.CalculateTransformationFactor(actual, specified);

            factor.ShouldBeEquivalentTo(2);
        }

        [Test]
        public void CalculateShrinkFactor()
        {
            var actual = new Size(25, 35);
            var specified = new Size(5, 7);

            var factor = PaintHelper.CalculateTransformationFactor(actual, specified);

            factor.Should().BeInRange(0.2f - 0.01f, 0.2f + 0.01f);
        }

        [Test]
        public void CalculateUnproportionalFactor()
        {
            var actual = new Size(100, 50);
            var specified = new Size(20, 25);

            var factor = PaintHelper.CalculateTransformationFactor(actual, specified);

            factor.Should().BeInRange(0.2f - 0.01f, 0.2f + 0.01f);
        }

        [Test]
        public void CalculateNewSize()
        {
            var oldS = new Size(10, 15);
            var factor = 3f;

            var newS = PaintHelper.CalculateNewSize(oldS, factor);

            newS.ShouldBeEquivalentTo(new Size(30, 45));
        }

        [Test]
        public void CalculateCanvasSize()
        {
            var rectangles = new List<Rectangle>
            {
                new Rectangle(new Point(10, 10), new Size(10, 10)),
                new Rectangle(new Point(-10, 10), new Size(10, 10)),
                new Rectangle(new Point(10, -10), new Size(10, 10))
            };

            var size = PaintHelper.CalculateImageSize(rectangles);

            size.ShouldBeEquivalentTo(new Size(40, 40));
        }

        [Test]
        public void ComplexMoveRectangles()
        {
            var rectangles = Generate().ToList();
            var imageS = PaintHelper.CalculateImageSize(rectangles);
            var offset = PaintHelper.CalculateCenterLocation(imageS);

            var moved = rectangles.Select(x => new Rectangle(new Point(x.X + offset.X, x.Y + offset.Y), x.Size));

            moved.All(x => OnPicture(imageS, x)).Should().BeTrue();
        }

        private IEnumerable<Rectangle> Generate()
        {
            var rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                var l = new Point(rnd.Next(1000) * GetRandomSing(), rnd.Next(1000) * GetRandomSing());
                var s = new Size(rnd.Next(1000) * GetRandomSing(), rnd.Next(1000) * GetRandomSing());
                yield return new Rectangle(l, s);
            }
        }

        private bool OnPicture(Size size, Rectangle rectangle)
        {
            return rectangle.Top > 0
                   && rectangle.Bottom <=size.Height
                   && rectangle.Left > 0
                   && rectangle.Right < size.Width;
        }

        private int GetRandomSing()
        {
            var v = new Random().Next(100);
            return v > 80 ? -1 : 1;
        }
    }
}