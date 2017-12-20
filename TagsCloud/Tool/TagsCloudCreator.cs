using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class TagsCloudCreator : ITagsCloudCreator
    {
        private readonly ITagsCreator tagsCreator;
        private readonly ITagsPainter painter;

        public TagsCloudCreator(ITagsCreator creator, ITagsPainter painter)
        {
            this.tagsCreator = creator;
            this.painter = painter;
        }

        public Bitmap Create(IEnumerable<string> words, IPaintingSettings settings, ITagLayouter layouter)
        {
            var tags = tagsCreator.CreateTags(words);
            var placedTags = layouter.LayoutTags(tags);
            var image = painter.DrawTagsCloud(placedTags, settings);
            return image;
        }
    }
}