using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.App
{
    public class Settings : IFontProvider, IInputPathProvider, IOutputPathProvider, IColorProvider
    {
        public Font GetFont()
        {
            throw new NotImplementedException();
        }

        public string GetInputPath()
        {
            throw new NotImplementedException();
        }

        public string GetOutputPath()
        {
            throw new NotImplementedException();
        }

        public Color GetColor()
        {
            throw new NotImplementedException();
        }
    }
}