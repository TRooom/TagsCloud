using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Infrastructure
{
    public interface IImageSaver
    {
        void SaveImage(Bitmap image,ImageFormat format, string filename);
    }
}