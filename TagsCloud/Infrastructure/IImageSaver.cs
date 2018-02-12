using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Tool.ResultOf;

namespace TagsCloud.Infrastructure
{
    public interface IImageSaver
    {
        Result<None> SaveImage(Bitmap image,ImageFormat format, string filename);
    }
}