using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public interface IPaintingSettings
    {
        Font Font { get; }
        IColorProvider ColorProvider { get; }
        Size ImageSize { get; }
    }
}