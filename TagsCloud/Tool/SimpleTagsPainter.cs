using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class SimpleTagsPainter : ITagsPainter
    {
        private readonly ITagLayouter layouter;

        public SimpleTagsPainter(ITagLayouter layouter)
        {
            this.layouter = layouter;
        }

        public Bitmap DrawTagsCloud(IPaintingSettings settings)
        {
            var placedTags = layouter.LayoutTags();
            var actualSize =
                PaintHelper.CalculateImageSize(placedTags.Select(PaintHelper.ToRect));
            var image = new Bitmap(settings.ImageSize.Height, settings.ImageSize.Width);
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
                var emSize = PaintHelper.TryFindEmSize(rect.Size, tag.Word, fontName, g);
                g.DrawString(tag.Word, new Font(fontName, emSize),
                    new SolidBrush(settings.ColorProvider.Colorize(tag)), rect);
            }
            return image;
        }
    }
}