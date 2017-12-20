using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using Random = System.Random;

namespace TagsCloud.Tool
{
    public class RandomColorProvider : IColorProvider
    {
        private readonly IEnumerator<byte> randomizer;

        public RandomColorProvider()
        {
            this.randomizer = Randomizer().GetEnumerator();
        }

        public Color Colorize(Tag tag)
        {
            var c1 = GetNext(randomizer);
            var c2 = GetNext(randomizer);
            var c3 = GetNext(randomizer);
            return Color.FromArgb(c1, c2, c3);
        }

        public IEnumerable<byte> Randomizer()
        {
            var rnd = new Random(1);
            while (true)
                yield return (byte) rnd.Next(256);
        }

        public byte GetNext(IEnumerator<byte> bytes)
        {
            bytes.MoveNext();
            return bytes.Current;
        }
    }
}