using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Tool
{
    public class CircularCloudLayouter : ITagLayouter
    {
        private List<Rectangle> addedRectangles;
        private Spiral spiral;
        private readonly Point center;
        private readonly ITagsCreator creator;

        public CircularCloudLayouter(ITagsCreator creator, Point center = default(Point))
        {
            addedRectangles = new List<Rectangle>();
            spiral = new Spiral(center);
            this.center = center;
            this.creator = creator;
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

        public Result<IEnumerable<PlacedTag>> LayoutTags()
        {
            addedRectangles = new List<Rectangle>();
            spiral = new Spiral(center);
            var result = creator.CreateTags();
            if (!result.IsSuccess)
                return Result.Fail<IEnumerable<PlacedTag>>(result.Error);
            var tags = result.Value;
            return tags.Select(x => new PlacedTag(x, PutNextRectangle(x.Size).Location)).ToList();
        }
    }
}