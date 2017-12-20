using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class SimpleColorProvider : IColorProvider
    {
        private List<Color> colors;

        private int pointer;

        public SimpleColorProvider(IEnumerable<string> colorsName)
        {
            colors = colorsName.Select(Color.FromName).ToList();
        }

        public Color Colorize(Tag tag)
        {
            pointer++;
            pointer %= colors.Count;
            return colors[pointer];
        }
    }
}