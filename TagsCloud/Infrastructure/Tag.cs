using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public class Tag
    {
        public readonly Size Size;

        public readonly string Word;

        public Tag(Size size, string word)
        {
            this.Size = size;
            this.Word = word;
        }
    }
}