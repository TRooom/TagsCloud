using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public interface ITagsCloudCreator
    {
        Bitmap Create(IEnumerable<string> words, IPaintingSettings settings, ITagLayouter layouter);
    }
}