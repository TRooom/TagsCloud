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
        private readonly IWordProcessor processor;

        public string Path { get; set; }

        public SimpleWordReaders(IWordProcessor processor)
        {
            this.processor = processor;
        }

        public IEnumerable<string> ReadWords()
        {
            var words = File.ReadAllLines(Path).Select(x => x.Trim());
            return processor.ProcessWords(words);
        }
    }
}