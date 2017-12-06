using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.App
{
    public class SimpleWordSelector : IWordSelector
    {
        public IEnumerable<string> Select(IEnumerable<string> words)
        {
            throw new NotImplementedException();
        }
    }
}