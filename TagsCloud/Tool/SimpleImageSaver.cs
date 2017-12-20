using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;

namespace TagsCloud.Tool
{
    public class SimpleImageSaver :IImageSaver
    {
        public void SaveImage(Bitmap image, ImageFormat format, string filename)
        {
            image.Save(filename,format);
        }
    }
}
