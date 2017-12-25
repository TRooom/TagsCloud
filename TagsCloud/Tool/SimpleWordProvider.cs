using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class SimpleWordProvider : IWordProvider
    {
        private readonly IWordReader reader;
        private readonly IWordProcessor processor;

        public SimpleWordProvider(IWordReader reader, IWordProcessor processor)
        {
            this.reader = reader;
            this.processor = processor;
        }

        public IEnumerable<string> GetWords()
        {
            return processor.ProcessWords(reader.ReadWords());
        }
    }
}