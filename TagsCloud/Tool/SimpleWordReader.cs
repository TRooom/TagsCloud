using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.App
{
    public class SimpleWordReader : IWordReader
    {
        public IEnumerable<string> ReadWords(IInputPathProvider pathProvider)
        {
            throw new NotImplementedException();
        }
    }
}