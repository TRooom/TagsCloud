using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.App
{
    public class TagsCreator : ITagsCreator
    {
        public IEnumerable<Tag> CreateTags(IEnumerable<string> words)
        {
            throw new NotImplementedException();
        }
    }
}