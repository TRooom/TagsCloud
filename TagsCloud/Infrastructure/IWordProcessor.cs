using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Infrastructure
{
    public interface IWordProcessor
    {
        void AddExcludingRule(Predicate<string> boringWords);
        Result<IEnumerable<string>> ProcessWords(Result<IEnumerable<string>> words);
        Func<string, string> Convertion { set; }
    }
}