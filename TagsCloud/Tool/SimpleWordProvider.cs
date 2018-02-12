using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool.ResultOf;

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

        public Result<IEnumerable<string>> GetWords()
        {
            return processor.ProcessWords(reader.ReadWords());
        }
    }
}