using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud.Infrastructure
{
    public interface IColorProvider
    {
        Color Colorize(Tag tag);
    }
}