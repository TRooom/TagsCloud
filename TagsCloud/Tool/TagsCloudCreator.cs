using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool;

namespace TagsCloud.App
{
    public class TagsCloudCreator : ITagsCloudCreator
    {
        private readonly IWordSelector selector;
        private readonly IWordReader reader;
        private readonly ITagsCreator creator;
        private readonly ITagsPainter painter;
        private readonly Settings settings;

        public TagsCloudCreator(IWordReader reader, IWordSelector selector, ITagsCreator creator, ITagsPainter painter,
            Settings settings)
        {
            this.reader = reader;
            this.selector = selector;
            this.creator = creator;
            this.painter = painter;
            this.settings = settings;
        }

        public Bitmap Create()
        {
            var words = reader.ReadWords(settings);
            var rightWord = selector.Select(words);
            var tags = creator.CreateTags(rightWord);
            var image = painter.DrawTagsCloud(tags);
            return image;
        }
    }
}