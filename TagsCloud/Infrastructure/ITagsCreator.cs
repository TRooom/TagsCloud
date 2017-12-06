using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public interface ITagsCreator
    {
        IEnumerable<Tag> CreateTags(IEnumerable<string> words);
    }
}