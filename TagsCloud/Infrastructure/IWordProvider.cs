using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Infrastructure
{
    public interface IWordProvider
    {
        Result<IEnumerable<string>> GetWords();
    }
}
