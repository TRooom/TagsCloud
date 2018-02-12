using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Common;
using TagsCloud.Infrastructure;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Tool
{
    public class SimpleWordReader : IWordReader
    {
        public string Path { get; set; }

        public Result<IEnumerable<string>> ReadWords()
        {
            var file = Directory.GetFiles(Directory.GetCurrentDirectory());
            return Result.Of(() => File.ReadAllLines(Path).Select(x => x.Trim()));
        }
    }
}