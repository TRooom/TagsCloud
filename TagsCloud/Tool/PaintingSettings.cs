using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class PaintingSettings : IPaintingSettings
    {
        public Font Font { get; set; }
        public IColorProvider ColorProvider { get; set; }
        public Size ImageSize { get; set; }
    }
}