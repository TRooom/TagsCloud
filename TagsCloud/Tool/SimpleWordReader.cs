using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class SimpleWordReader : IWordReader
    {
        public string Path { get; set; }

        public IEnumerable<string> ReadWords()
        {
            var words = File.ReadAllLines(Path).Select(x => x.Trim());
            return words;
        }
    }
}