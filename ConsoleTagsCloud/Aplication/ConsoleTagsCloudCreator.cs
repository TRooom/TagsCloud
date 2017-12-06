using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.App;
using TagsCloud.Tool;

namespace ConsoleTagsCloud.Aplication
{
    public class ConsoleTagsCloudCreator
    {
        private ITagsCloudCreator creator;

        public ConsoleTagsCloudCreator(ITagsCloudCreator creator)
        {
            this.creator = creator;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        private Settings GetSettings()
        {
            throw new NotImplementedException();
        }

        private void SaveImage()
        {
            throw new NotImplementedException();
        }
    }
}