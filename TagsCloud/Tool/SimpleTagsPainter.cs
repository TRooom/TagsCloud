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
        public Bitmap DrawTagsCloud(IEnumerable<PlacedTag> placedTags, IPaintingSettings settings)
        {
            var actualSize =
                PaintHelper.CalculateImageSize(placedTags.Select(PaintHelper.ToRect));
            var image = new Bitmap(settings.ImageSize.Height, settings.ImageSize.Width);
            var g = Graphics.FromImage(image);
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