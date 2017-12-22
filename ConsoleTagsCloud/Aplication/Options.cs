using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace ConsoleTagsCloud
{
    public class Options
    {
        [Option('t', "text", Required = true)]
        public string InputFile { get; set; }

        [Option('p', "picture", Required = true)]
        public string OutputFile { get; set; }

        [Option('c', "color")]
        public IEnumerable<string> Colors { get; set; }

        [Option('f', "font", DefaultValue = "Arial")]
        public string Font { get; set; }

        [Option('a', "algoritm")]
        public string Alg { get; set; }

        [Option('n', "number", DefaultValue = 100)]
        public int Number { get; set; }

        [Option('h', "height", DefaultValue = 1000)]
        public int Height { get; set; }

        [Option('w', "width", DefaultValue = 1000)]
        public int Width { get; set; }

        [Option('s', "step", Required = false, DefaultValue = 0.01)]
        public double Step { get; set; }

        [Option('f', "factor", Required = false, DefaultValue = 2)]
        public double Factor { get; set; }
    }
}