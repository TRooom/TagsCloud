using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public class PlacedTag
    {
        public readonly Tag Tag;
        public readonly Point Location;

        public PlacedTag(Tag tag, Point location)
        {
            this.Tag = tag;
            this.Location = location;
        }
    }
}