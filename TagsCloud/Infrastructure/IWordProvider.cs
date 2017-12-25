using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public interface IWordProvider
    {
        IEnumerable<string> GetWords();
    }
}
