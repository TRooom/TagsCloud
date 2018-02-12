using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Infrastructure
{
    public interface ITagsCreator
    {
        Result<IEnumerable<Tag>> CreateTags(int maxCount = 100);
    }
}