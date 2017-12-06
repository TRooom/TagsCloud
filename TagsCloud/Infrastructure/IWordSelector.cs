using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public interface IWordSelector
    {
        IEnumerable<string> Select(IEnumerable<string> words);
    }
}