using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Tool
{
    public class TagsCloudCreator : ITagsCloudCreator
    {
        private readonly ITagsPainter painter;

        public TagsCloudCreator(ITagsPainter painter)
        {
            this.painter = painter;
        }

        public Result<Bitmap> Create(IPaintingSettings settings)
        {
            return painter.DrawTagsCloud(settings);
        }
    }
}