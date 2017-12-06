using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTagsCloud.Aplication;
using TagsCloud.App;

namespace ConsoleTagsCloud
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = BuildDependency();
            program.Run();
        }

        static ConsoleTagsCloudCreator BuildDependency()
        {
            throw new NotImplementedException();
        }
    }
}