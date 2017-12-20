using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public interface IWordProcessor
    {
        void AddExcludingRule(Predicate<string> boringWords);
        IEnumerable<string> ProcessWords(IEnumerable<string> words);
        Func<string, string> Convertion { set; }
    }
}