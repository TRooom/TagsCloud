using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Tool
{
    public class SimpleImageSaver :IImageSaver
    {
        public Result<None> SaveImage(Bitmap image, ImageFormat format, string filename)
        {
            return Result.OfAction(() =>image.Save(filename,format), null);
        }
    }
}
