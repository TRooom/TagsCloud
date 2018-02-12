using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Tool
{
    public class SimpleTagsPainter : ITagsPainter
    {
        private readonly ITagLayouter layouter;

        public SimpleTagsPainter(ITagLayouter layouter)
        {
            this.layouter = layouter;
        }
        public Result<Bitmap> DrawTagsCloud(IPaintingSettings settings)
        {
            var lauouterResult = layouter.LayoutTags();
            if (!lauouterResult.IsSuccess)
                return Result.Fail<Bitmap>(lauouterResult.Error);
            var placedTags = lauouterResult.Value;
            var actualSize =
                PaintHelper.CalculateImageSize(placedTags.Select(PaintHelper.ToRect));
            var image = new Bitmap(settings.ImageSize.Height, settings.ImageSize.Width);
            if (!IsFit(actualSize, settings.ImageSize))
                return Result.Fail<Bitmap>("Actual image size is bigger then given");
            var g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.HighQuality;
            var offset = PaintHelper.CalculateCenterLocation(actualSize);
            foreach (var placedTag in placedTags)
            {
                var tag = placedTag.Tag;
                var location = placedTag.Location;
                var newL = new Point(location.X + offset.X, location.Y + offset.Y);
                var rect = new Rectangle(newL, tag.Size);
                var fontName = settings.Font.Name;
                var emSize = PaintHelper.FindFontSize(rect.Size, tag.Word, fontName, g);
                g.DrawString(tag.Word, new Font(fontName, emSize),
                    new SolidBrush(settings.ColorProvider.Colorize(tag)), rect);
            }
            return Result.Ok(image);
        }

        private bool IsFit(Size actual, Size given)
        {
            return actual.Height <= given.Height && actual.Width <= given.Width;
        }
    }
}