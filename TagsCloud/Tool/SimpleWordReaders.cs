using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class SimpleWordReaders : IWordReader
    {
        public IEnumerable<string> ReadWords(string path)
        {
            return File.ReadAllLines(path).Select(x => x.Trim());
        }
    }
}
