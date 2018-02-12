using System.Collections.Generic;
using System.Drawing;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Infrastructure
{
    public interface IColorProvider
    {
        Color Colorize(Tag tag);
    }
}